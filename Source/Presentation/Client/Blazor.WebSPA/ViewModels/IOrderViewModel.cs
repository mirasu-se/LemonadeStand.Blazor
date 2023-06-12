using System.ComponentModel.DataAnnotations;

namespace Blazor.WebSPA.ViewModels
{
    public interface IOrderViewModel
    {
        [Required]
        int Id { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "The order number cannot be 0. A maximum of 100 glasses is allowed per order!")]
        int OrderQuantity { get; set; }

        [Required]
        [Range(1, 1500, ErrorMessage = "The received money amount cannot be 0. The maximum cash allowance is 1500 SEK!")]
        int MoneyAmountReceived { get; set; }
    }
}
