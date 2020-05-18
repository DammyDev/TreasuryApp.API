using System.ComponentModel.DataAnnotations;

namespace TreasuryApp.API.Resources
{
    public class SaveCategoryResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}