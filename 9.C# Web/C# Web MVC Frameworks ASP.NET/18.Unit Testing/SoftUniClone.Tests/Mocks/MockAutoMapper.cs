using AutoMapper;
using SoftUniClone.Web.Mapping;

namespace SoftUniClone.Tests.Mocks
{

    //Mocks are fake object which we use for testing only !!!
    //We just initialize the AutoMapper and return an instance of it
    public static class MockAutoMapper
    {
        public static IMapper GetMapper()
        {
            //configurirame mappera
            Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());

            //suzdavame instanciq na mapper za da go podlzvame v testovete
            return Mapper.Instance;
        }
    }
}
