using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerApplication.Models
{
    [Table("messages")]
    public class Message
    {
        [Column("player_id")]
        public string PlayerId { get; set; }
        public Player Player { get; set; }


        [Column("chat_id")]
        public string ChatId { get; set; }
        public Chat Chat { get; set; }


        [Column("text")]
        public string Text { get; set; }


        [Column("post_date")]
        public DateTime PostDate { get; set; }
    }
}
