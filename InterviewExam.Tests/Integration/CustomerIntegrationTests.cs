using InterviewExam.Infrastructure.Data.Context;

namespace InterviewExam.Tests.Integration
{
    public class CustomerIntegrationTests
    {
        private readonly InterviewExamContext _context;
        public CustomerIntegrationTests(InterviewExamContext context)
        {
            _context = context;
        }

        [Fact]
        public void Test1()
        {
            var a = "";
        }
    }
}