using practice.Dto;
using practice.Models;
using AutoMapper;

namespace practice.Automapper
{
    public class ProjectMapping : Profile
    {
        public ProjectMapping()
        {
            CreateMap<Product, Productdto>().ReverseMap(); // reverse map use to convert p to pdto, then pdto to p
            CreateMap<Customer, Customerdto>().ReverseMap();
            CreateMap<Order, Orderdto>().ReverseMap();
        }
    }
}
