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

        string _selectedRegionEndpoint;

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

        string _summonerName = null;
        public bool summonerChanged = false;

        [Parameter]
        public string SummonerName
        {
            get
            {
                return _summonerName;
            }
            set
            {
                _summonerName = value;
                summonerChanged = true;
            }

        }

        protected async override Task OnInitializedAsync()
        {
            SelectedRegion = await ConvertStringToRegion(_selectedRegionEndpoint);
        }

        private Task<RiotSharp.Misc.Region> ConvertStringToRegion(string regionString)
        {
            RiotSharp.Misc.Region region = (RiotSharp.Misc.Region)Enum.Parse(typeof(RiotSharp.Misc.Region), regionString, true); // case insensitive
            return Task.FromResult(region);
        }
    }
}
