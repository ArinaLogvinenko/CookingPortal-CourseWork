namespace Application.Services
{
    using AutoMapper;
    using Interfaces;

    public class Service : IService
    {
        protected readonly IMapper Mapper;

        public Service(IMapper mapper)
        {
            this.Mapper = mapper;
        }
    }
}
