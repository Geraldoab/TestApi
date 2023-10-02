using InterviewExam.CrossCutting.IoC.Graphql;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewExam.CrossCutting.IoC.Providers
{
    public static class GraphqlContainer
    {
        public static void Register(IServiceCollection services)
        {
            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddFiltering();
        }
    }
}
