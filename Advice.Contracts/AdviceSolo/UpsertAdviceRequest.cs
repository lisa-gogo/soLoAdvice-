namespace Advice.Contracts.AdviceSolo;

public record UpsertAdviceRequest(
    string Name,
    string Place,
    string Description,
    List<string> tags

 );