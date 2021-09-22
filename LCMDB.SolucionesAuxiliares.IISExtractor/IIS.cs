using LCMDB.IISExtractor.Modelos.v1_0;
using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCMDB.SolucionesAuxiliares.IISExtractor
{
    public class IIS
    {
        private string IP;
        private List<AplicacionPool> ListaPools;
        private List<SitioWeb> ListaSitiosWeb;
        private ServidorIIS servidorIIS;
        public IIS(string NombreHost)
        {
            IP = NombreHost;
        }
        //ServidorIIS
        public ServidorIIS ObtenerDatosServidor()
        {        
            using (ServerManager ResultadoServidor = ServerManager.OpenRemote(IP))
            {
                ListaPools = new List<AplicacionPool>();
                foreach (var pool in ResultadoServidor.ApplicationPools)
                {
                    AplicacionPool aplicacionPool = new AplicacionPool();
                    aplicacionPool.Nombre = pool.Name;
                    aplicacionPool.CLR = pool.ManagedRuntimeVersion;
                    aplicacionPool.Estado = ((Estado)((int)pool.State));
                    aplicacionPool.THTWOBits = pool.Enable32BitAppOnWin64;
                    aplicacionPool.ManagedPipeline = pool.ManagedPipelineMode.ToString();
                    aplicacionPool.Usuario = pool.ProcessModel.UserName;
                    aplicacionPool.Contrasenia = pool.ProcessModel.Password;
                    aplicacionPool.FechaHoraRegistro = DateTime.Now;
                    ListaPools.Add(aplicacionPool);
                }
                ListaSitiosWeb = new List<SitioWeb>();
                foreach (var Sitio in ResultadoServidor.Sites)
                {
                    SitioWeb sitioWeb = new SitioWeb();
                    sitioWeb.Nombre = Sitio.Name;
                    sitioWeb.IdOnIIS = Sitio.Id;
                    sitioWeb.Estado = ((Estado)((int)Sitio.State));
                    //sitioWeb.NombrePool=Sitio
                    sitioWeb.FechaHoraRegistro = DateTime.Now;
                    sitioWeb.Aplicaciones = new List<Aplicacion>();
                    foreach (var App in Sitio.Applications)
                    {
                        Aplicacion aplicacion = new Aplicacion();
                        if (App.Path == "/")
                        {
                            sitioWeb.RutaFisica = App.VirtualDirectories[0].PhysicalPath;
                            sitioWeb.NombrePool = App.ApplicationPoolName;
                        }
                        aplicacion.RutaFisica = App.VirtualDirectories[0].PhysicalPath;
                        aplicacion.Nombre = App.Path;
                        aplicacion.FechaHoraRegistro = DateTime.Now;
                        aplicacion.FechaRegistro = DateTime.Now;
                        aplicacion.NombrePool = App.ApplicationPoolName;
                        sitioWeb.Aplicaciones.Add(aplicacion);
                    }
                    sitioWeb.Vinculantes = new List<Vinculante>();
                    foreach (var binding in Sitio.Bindings)
                    {
                        Vinculante vinculante = new Vinculante();
                        vinculante.FechaHoraRegistro = DateTime.Now;
                        vinculante.FechaRegistro = DateTime.Now;
                        vinculante.FirmaCertificado = binding.CertificateHash != null ? binding.Attributes["certificateHash"].Value.ToString().ToLower() : null;
                        vinculante.Host = binding.Host;
                        if (binding.EndPoint != null)
                        {
                            vinculante.IpVinculante = binding.EndPoint.Address.ToString();
                            vinculante.Puerto = binding.EndPoint.Port.ToString();
                        }
                        vinculante.TipoEsquema = binding.Protocol;
                        sitioWeb.Vinculantes.Add(vinculante);
                    }
                    ListaSitiosWeb.Add(sitioWeb);
                }
                servidorIIS = new ServidorIIS();
                servidorIIS.AplicacionesPools = ObtenerAplicacionPools();
                servidorIIS.SitiosWeb = ObtenerSitiosWeb();
                return servidorIIS;
            }
        }

        public List<AplicacionPool> ObtenerAplicacionPools()
        {
            return ListaPools;
        }
        public List<SitioWeb> ObtenerSitiosWeb()
        {
            return ListaSitiosWeb;
        }

    }
}
