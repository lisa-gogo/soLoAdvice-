namespace Advice.ServiceErrors;
using ErrorOr;

public static class Errors
{
    public static class Advice
    {
        public static Error NotFound => Error.NotFound(
            code: "Advice.NotFound",
            description: "Advice Not Found"
        );
    }
}