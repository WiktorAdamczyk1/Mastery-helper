using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RiotSharp;
namespace Mastery_Helper.Data
{
    public class RegionModel : ComponentBase
    {
        RiotSharp.Misc.Region _selectedRegion;
        public RiotSharp.Misc.Region SelectedRegion 
        {
            get { return _selectedRegion; }
            set 
            {
                _selectedRegion = value;
                if(SelectedRegionEndpoint != value.ToString()) SelectedRegionEndpoint = value.ToString();
            }
        }

        string _selectedRegionEndpoint = "EUNE";

        [Parameter]
        public string SelectedRegionEndpoint 
        { 
            get 
            { 
                return _selectedRegionEndpoint; 
            } 
            set 
            {
                _selectedRegionEndpoint = value;
                if(value != null && SelectedRegion != (RiotSharp.Misc.Region)Enum.Parse(typeof(RiotSharp.Misc.Region), value, true)) SelectedRegion = (RiotSharp.Misc.Region)Enum.Parse(typeof(RiotSharp.Misc.Region), value, true);
            } 
        
        }

        protected async override Task OnInitializedAsync()
        {
            SelectedRegion = await ConvertStringToRegion(SelectedRegionEndpoint);
        }

        private Task<RiotSharp.Misc.Region> ConvertStringToRegion(string regionString)
        {
            RiotSharp.Misc.Region region = (RiotSharp.Misc.Region)Enum.Parse(typeof(RiotSharp.Misc.Region), regionString, true); // case insensitive
            return Task.FromResult(region);
        }
    }
}
