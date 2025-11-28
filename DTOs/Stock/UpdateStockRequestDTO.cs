using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace net8API.DTOs.Stock
{
    public class UpdateStockRequestDTO
    {
        [Required]
        [MinLength(4,ErrorMessage ="Symbol must be 4 characters")]
        [MaxLength(8,ErrorMessage ="Symbol cannot be over 8 characters")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        public string CompanyName { get; set; } = string.Empty;
        [Range(1,1000000000)]
        public decimal Purchase { get; set; }
        public decimal LastDiv {get;set;}
        public string Industry {get;set;}= string.Empty;
        public long MarketCap {get;set;}        
    }
}