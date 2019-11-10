using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BethanysPieShopHRM.Shared
{
    public class Benefit
    {
        public int BenefitId { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public bool Premium { get; set; }
    }
}
