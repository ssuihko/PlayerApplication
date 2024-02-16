using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace PlayerApplication.Models
{
    [Table("inventories")]
    public class Inventory
    {
        [Column("id")]
        public string Id { get; set; }

        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
