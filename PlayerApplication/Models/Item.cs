using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerApplication.Models
{
    [Table("items")]
    public class Item
    {
        [Column("id")]
        public string Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("price")]
        public float Price { get; set; }

        [Column("inventory_id")]
        public string InventoryId { get; set; }
        public Inventory Inventory { get; set; }


    }
}
