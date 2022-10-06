namespace University.ApplicationCore.Exceptions;

public class NotEmptyGroupException : Exception
{
    public NotEmptyGroupException(int groupId)
            : base($"Cant delete group (Id = {groupId}) with existing students") 
    {
    }
}
