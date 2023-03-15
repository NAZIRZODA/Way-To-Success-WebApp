namespace WTSuccess.Application.RequestModels.StudentRequestModels;

public abstract class StudentRequestModel: BaseRequestModel
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}