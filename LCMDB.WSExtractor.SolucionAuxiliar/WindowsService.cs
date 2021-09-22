using LCMDB.WSExtractor.Modelos.v1_0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace LCMDB.WSExtractor.SolucionAuxiliar
{
    public class WindowsService
    {
        private List<ServicioWindows> _ServiciosWindows;
        private string _NombreHost;
        public WindowsService (string NombreHost)
        {
            _NombreHost = NombreHost;
        }
        public void ExtraerServicios()
        {
            ServiceController[] services = ServiceController.GetServices(_NombreHost); // This will get the services from the current machine.

            // try to find service name
            foreach (ServiceController service in services)
            {
                var servicio=service;
            }

        }
        public List<ServicioWindows> ExtraerServiciosWMI()
        {
            ManagementObjectSearcher BuscadorWS = new ManagementObjectSearcher("\\\\"+_NombreHost+"\\root\\cimv2", "select * from Win32_Service");
            ManagementObjectCollection ServiciosWindows = BuscadorWS.Get();
            _ServiciosWindows = new List<ServicioWindows>();
            foreach (ManagementObject Servicio in ServiciosWindows)
            {
                ServicioWindows servicioWindows = new ServicioWindows();
                servicioWindows.Nombre=Servicio["Name"].ToString();
                int IdProceso =0;
                int.TryParse(Servicio["ProcessID"].ToString(), out IdProceso);
                servicioWindows.IdProceso = IdProceso;
                servicioWindows.Descripcion= Servicio["Description"]!=null?Servicio["Description"].ToString():null;
                servicioWindows.Estado = Servicio["State"] != null ? Servicio["State"].ToString():null;
                servicioWindows.ModoInicio = Servicio["StartMode"]!=null? Servicio["StartMode"].ToString():null;
                servicioWindows.NombreCompleto = Servicio["DisplayName"] != null ? Servicio["DisplayName"].ToString():null;
                servicioWindows.RutaFisica = Servicio["PathName"] != null ? Servicio["PathName"].ToString():null;
                servicioWindows.TipoProceso = Servicio["ServiceType"] != null ? Servicio["ServiceType"].ToString():null;
                servicioWindows.Usuario = Servicio["StartName"]!=null?Servicio["StartName"].ToString():null;
                servicioWindows.FechaHoraRegistro=DateTime.Now;
                _ServiciosWindows.Add(servicioWindows);
            }
            return _ServiciosWindows;
        }
    }
}
