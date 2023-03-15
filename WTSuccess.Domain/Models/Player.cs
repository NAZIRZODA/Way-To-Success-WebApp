namespace WTSuccess.Domain.Models
{
    public class Player:EntityBase
    {
        public ulong StudentId { get; set; }
        public bool TrueAnswer { get; set; }
        public bool FalseAnswer { get; set; }
    }
}
