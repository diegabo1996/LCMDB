using AutoMapper;
using LCMDB.BD.Contextos.LCMDB.Modelos.v1_0;

namespace LCMDB.WorkerServices.ServidoresExtractor
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Servidor, ServidoresHistorico>();
            CreateMap<ServidoresHistorico, Servidor>();
            CreateMap<PuertosServidores, PuertoServidoresHistorico>();
            CreateMap<SO, SOHistorico>();
        }
    }
}