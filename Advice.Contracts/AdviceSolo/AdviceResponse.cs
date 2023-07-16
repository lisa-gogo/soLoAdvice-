namespace Advice.Contracts.AdviceSolo;

public record AdviceResponse(
    Guid id,
    string Name,
    string Place,
    string Description,
    List<string> tags

 );
