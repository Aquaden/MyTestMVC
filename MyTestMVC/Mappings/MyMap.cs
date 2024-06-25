using AutoMapper;
using MyTestMVC.Datas.Entities;
using MyTestMVC.Models;

namespace MyTestMVC.Mappings
{
    public class MyMap : Profile
    {
        public MyMap() 
        {
            CreateMap<Events, EventsViewModel>();
            CreateMap<EventsViewModel,Events>().ForMember(x => x.Id,opt => opt.Ignore());
            
        }
    }
}
