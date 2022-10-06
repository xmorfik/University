namespace University.ApplicationCore.Exceptions;

public class NotEmptyCourseException : Exception
{
    public NotEmptyCourseException(int courseId)
            : base($"Cant delete course (Id = {courseId}) with existing groups") 
    {
    }
}
