using PlayerApplication.Enums;
using PlayerApplication.Models;

namespace PlayerApplication.DTOs
{
 
    public record RegisterDto(string Email, string Password, string Class, string Race);

    public record RegisterAdminDto(string Email, string Password);
    public record LoginDto(string Email, string Password);
    public record AuthResponseDto(string Token, string Email, UserRole Role);

    public record RegisterResponseDto(string Email, UserRole Role);



    class ItemDTO
    {

        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public ItemDTO(Item item)
        {
            Id = item.Id;
            Name = item.Name;
            Description = item.Description;
            Price = item.Price;
        }

    }


    class InventoryDTO
    {

        public string Id { get; set; }

        public List<ItemDTO> Items { get; set; } = new List<ItemDTO>();

        public InventoryDTO(Inventory inventory)
        {
            Id = inventory.Id;
            
            foreach(Item it in inventory.Items)
            {
                Items.Add( new ItemDTO(it) );
            }
        }

    }

    class PlayerDTO
    {

        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Class { get; set; }

        public string Race {  get; set; }

        public int Exp { get; set; }

        public int Hp { get; set; }

        public float Money { get; set; }

        public InventoryDTO Inventory { get; set; }

        public PlayerDTO(Player player)
        {
            Id = player.Id;
            UserName = player.UserName;
            Email = player.Email;
            Class = player.Class.ToString();
            Race = player.Race.ToString();
            Exp = player.Exp;
            Hp = player.Hp;
            Money = player.Money;
            Inventory = new InventoryDTO(player.Inventory);
        }

    }

    class ShopDTO
    {

        public string Id { get; set; }

        public string Name { get; set; }


        public InventoryDTO Inventory { get; set; }

        public ShopDTO(Shop shop)
        {
            Id = shop.Id;
            Name = shop.Name;
            Inventory = new InventoryDTO(shop.Inventory);
        }

    }


    class MessageDTO
    {

        public string PlayerId { get; set; }

        public string ChatId { get; set; }

        public string UserName { get; set; }    

        public string Text { get; set; }

        public string DateTime { get; set; }

        public MessageDTO(Message message)
        {
            PlayerId = message.PlayerId;
            ChatId = message.ChatId;
            UserName = message.Player.UserName;
            Text = message.Text;
            DateTime = message.PostDate.ToString();
        }

    }

    class ChatDTO
    {

        public string Id { get; set; }

        public string Channel { get; set; }

        public List<MessageDTO> Messages { get; set; } = new List<MessageDTO>();

        public ChatDTO(Chat chat)
        {
            Id = chat.Id;
            Channel = chat.Channel;
            foreach(Message msg in chat.Messages)
            {
                Messages.Add(new MessageDTO(msg));
            }
        }

    }


}
