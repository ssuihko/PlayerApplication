using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;
using PlayerApplication.Enums;

namespace PlayerApplication.Models
{

    [Table("players")]

    public class Player : IdentityUser
    {

        [Column("role")]
        public UserRole Role { get; set; }

        [Column("race")]
        public UserRace Race { get; set; }


        [Column("class")]
        public UserClass Class { get; set; }

        [Column("exp")]
        public int Exp { get; set; }

        [Column("hp")]
        public int Hp { get; set; }

        [Column("money")]
        public float Money { get; set; }


        [Column("inventory_id")]
        public string InventoryId { get; set; }
        public Inventory Inventory{ get; set; }

        public ICollection<Message> Messages { get; set; } = new List<Message>();


    }

}
