using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestForASPCORE.Models
{
    public class Purchase
    {
        [Key]
        public string billNo { get; set; }

        [Required(ErrorMessage = "Required")]
        [Key]
        public int supplierId { get; set; }

        [Required(ErrorMessage = "Required")]

        public int productId { get; set; }

        [Required(ErrorMessage = "Required")]

        public int quantity { get; set; }

        [Required(ErrorMessage = "Required")]
        public double unitPrice { get; set; }

        [Required(ErrorMessage = "Required")]
        public double total { get; set; }

        [Required(ErrorMessage = "Required")]
        public string supplierName { get; set; }

        [Required(ErrorMessage = "Required")]
        public string productName { get; set; }

        [Required(ErrorMessage = "Required")]
        public DateTime purchaseDate  { get; set; }
}
}

