namespace Advice.Services.Advices;
using Advice.Services.Advices;
using Advice.Models;
using ErrorOr;
using Advice.ServiceErrors;
public class AdviceService : IAdviceService
{
    private static readonly Dictionary<Guid, EachAdvice> _advice = new Dictionary<Guid, EachAdvice>();
    public void CreateAdvice(EachAdvice advice)
    {
        _advice.Add(advice.Id, advice);
    }

    public List<EachAdvice> GetAllAdvices()
    {
        List<EachAdvice> advices = new List<EachAdvice>(_advice.Values);
        return advices;
    }

    public ErrorOr<EachAdvice> GetAdvice(Guid id)
    {
        if (_advice.TryGetValue(id, out var advice))
        {
            return advice;
        }

        return Errors.Advice.NotFound;
    }

    public EachAdvice UpsertAdvice(EachAdvice advice)
    {
        _advice[advice.Id] = advice;
        return advice;
    }

    public void DeleteAdvice(Guid id)
    {
        _advice.Remove(id);
    }
}