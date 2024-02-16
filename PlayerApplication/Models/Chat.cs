using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerApplication.Models
{
    [Table("chat")]
    public class Chat
    {
        [Column("id")]
        public string Id { get; set; }

        [Column("channel")]
        public string Channel { get; set; }

        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
