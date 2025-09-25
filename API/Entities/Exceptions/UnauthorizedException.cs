namespace API.Entities.Exceptions;

public class UnauthorizedException : Exception
{
    public UnauthorizedException() 
    : base("You do not have permission to access this resource.")
    {
    }
}