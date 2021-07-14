using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IAnswerSubmissionService
    {
        Task<IO.Swagger.Model.AnswerResponse> SubmitAsync();
    }
}
