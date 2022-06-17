using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Dtos.Requests
{
    public class AddBookRequest
    {
        [Required(ErrorMessage = "Kitap adı zorunludur")]
        public string Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public decimal? Price { get; set; }
        public double? DiscountRate { get; set; }
        public int? Stock { get; set; }

    }
}
