using System.ComponentModel.DataAnnotations.Schema;

namespace WTSuccess.Domain.Models
{
    public class EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong Id { get; set; }

        public DateTime CreateAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
