using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShopHRM.Server.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.Server.Components
{
    public class BenefitSelectorBase: ComponentBase
    {
        [Parameter]
        public int EmployeeId { get; set; }

        public bool SaveButtonDisabled { get; set; } = true;
        public IEnumerable<BenefitModel> Benefits { get; set; }

        [Parameter]
        public EventCallback<bool> OnPremiumToggle { get; set; }

        [Inject]
        public IBenefitDataService BenefitDataService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Benefits = await BenefitDataService.GetForEmployee(EmployeeId);     
        }

        public async Task CheckBoxChanged(ChangeEventArgs e, BenefitModel benefit)
        {
            var newValue = (bool)e.Value;
            benefit.Selected = newValue;
            SaveButtonDisabled = false;

            if (newValue)
            {
                benefit.StartDate = DateTime.Now;
                benefit.EndDate = DateTime.Now.AddYears(1);
            }
            await OnPremiumToggle.InvokeAsync(Benefits.Any(b => b.Premium && b.Selected));
        }

        public void SaveClick()
        {
            BenefitDataService.UpdateForEmployee(EmployeeId, Benefits);
            SaveButtonDisabled = true;
        }
    }
}
