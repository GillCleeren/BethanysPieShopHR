using System;

namespace BethanysPieShopHRM.Shared
{
    public class BenefitModel: ITableModel
    {
        public int BenefitId { get; set; }

        public bool Selected { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Premium { get; set; }

        public bool HighLightRow 
        { 
            get 
            { 
                return Premium;
            } 
        }

        public bool ShowChildTemplate 
        { 
            get
            {
                return false;
            }
        }
    }
}
