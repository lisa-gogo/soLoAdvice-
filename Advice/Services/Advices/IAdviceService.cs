namespace Advice.Services.Advices;
using Advice.Models;
using ErrorOr;

public interface IAdviceService
{
    void CreateAdvice(EachAdvice advice);

    List<EachAdvice> GetAllAdvices();
    ErrorOr<EachAdvice> GetAdvice(Guid id);

    EachAdvice UpsertAdvice(EachAdvice advice);
    void DeleteAdvice(Guid id);
}