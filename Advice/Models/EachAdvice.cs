namespace Advice.Models;

public class EachAdvice
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Place { get; set; }
    public string Description { get; set; }
    public List<string> Tags { get; set; }

    public EachAdvice(
           Guid Id,
          string Name,
          string Place,
          string Description,
          List<string> Tags)
    {
        Id = Id;
        Name = Name;
        Place = Place;
        Description = Description;
        Tags = Tags;

    }

}