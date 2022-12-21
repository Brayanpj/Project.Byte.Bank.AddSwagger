using AutoMapper;
using Project.Byte.Bank;

namespace Project.Byte.Bank_.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {

            CreateMap<ListaDeUsuáriosETransaçõesCadastradas, UsuarioKey>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Cpf))
                .ForMember(x => x.NomeCompleto, y => y.MapFrom(z => z.DataDeNascimento.ToString()));

            CreateMap<CreateUsuarioDto, UsuarioKey>();
            #region ViewModelToMain  
            #endregion
        }
    }
}
