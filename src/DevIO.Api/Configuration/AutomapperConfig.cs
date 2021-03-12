using AutoMapper;
using DevIO.Api.ViewModels;
using DevIO.Business.Models;

namespace DevIO.Api.Configuration
{
    //Classe necessário para gerar os de-paras entre model e DTO
    //Não é necessário importar essa classe em nenhum local, pois como ela herda de Profile
    //Na configuração  em startup já o suficiente para o AutoMapper buscar por todo mundo que implementa esta classe
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            //de model para fornecedorViewModel
            //reverseMap -> faz o mapeamento acima, só que na ordem inversa
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<ProdutoViewModel, Produto>();

            CreateMap<ProdutoImagemViewModel, Produto>().ReverseMap();

            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(dest => dest.NomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.Nome));
        }
    }
}