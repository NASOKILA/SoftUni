using AutoMapper;
using SoftUniClone.Data;

namespace SoftUniClone.Services
{
    public abstract class BaseEFService
    {
        protected BaseEFService(
            SoftUniCloneContext dbContext,
            IMapper mapper)
        {
            this.DbContext = dbContext;
            this.Mapper = mapper;
        }

        protected SoftUniCloneContext DbContext { get; private set; }

        protected IMapper Mapper { get; private set; }
    }
}
