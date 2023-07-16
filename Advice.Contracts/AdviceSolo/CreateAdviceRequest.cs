namespace Advice.Contracts.AdviceSolo;

public record CreateAdviceRequest(
    string Name,
    string Place,
    string Description,
    List<string> tags

 );

