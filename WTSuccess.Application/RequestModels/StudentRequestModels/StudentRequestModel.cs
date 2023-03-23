namespace WTSuccess.Application.RequestModels.StudentRequestModels;

public abstract class StudentRequestModel: BaseRequestModel
{
    public ulong Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}