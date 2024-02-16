using System.ComponentModel.DataAnnotations;
using PlayerApplication.Enums;

namespace PlayerApplication.DTOs
{
    public record MessageUpdatePayload(string? Text);
    public record MessagePostPayload
    {
        [Required(ErrorMessage = "Text is required")]
        public string Text { get; init; }

        [Required(ErrorMessage = "ChatID is required")]
        public string ChatId { get; init; }

        public MessagePostPayload(string text, string chatid)
        {
            Text = text;
            ChatId = chatid;
        }
    }


    public record ShopUpdatePayload(string? Name);
    public record ShopPostPayload
    {
        [Required(ErrorMessage = "Text is required")]
        public string Name { get; init; }


        public ShopPostPayload(string name)
        {
            Name = name;
        }
    }


    public record ItemUpdatePayload(string? Name, string? Description, float? Price);
    public record ItemPostPayload
    {
        [Required(ErrorMessage = "Text is required")]
        public string Name { get; init; }


        [Required(ErrorMessage = "Description is required")]
        public string Description { get; init; }


        [Required(ErrorMessage = "Price is required")]
        public float Price { get; init; }

        public ItemPostPayload(string name, string description, float price)
        {
            Name = name;
            Description = description;
            Price = price;
        }
    }
    

    public record ChatPostPayload
    {
        [Required(ErrorMessage = "Channel name is required")]
        public string Channel { get; init; }


        public ChatPostPayload(string channel)
        {
            Channel = channel;
        }
    }

    public record InventoryUpdatePayload(string? Name, string? Description, float? Price);
  
}
