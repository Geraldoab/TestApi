using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewExam.CrossCutting.IoC.Providers
{
    internal static class AutoMapperContainer
    {
        internal static void Register(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddMaps(new[] { $"InterviewExam.Api" });
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
