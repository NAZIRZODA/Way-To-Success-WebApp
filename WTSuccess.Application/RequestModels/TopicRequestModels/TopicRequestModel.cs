namespace WTSuccess.Application.RequestModels.TopicRequestModels
{
    public abstract class TopicRequestModel: BaseRequestModel
    {
        public string Theme { get; set; }
        public string Teory { get; set; }
    }
}
