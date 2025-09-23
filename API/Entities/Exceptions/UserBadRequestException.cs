namespace API.Entities.Exceptions;

public class UserBadRequestException : BadRequestException
{
    public UserBadRequestException() : base("Problem with accessing a user occured.")
    {
    }
}