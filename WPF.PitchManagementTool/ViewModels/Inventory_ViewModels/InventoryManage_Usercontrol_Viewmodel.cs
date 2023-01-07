using Domain.PitchManagementTool;
using Domain.PitchManagementTool.Services.Commodities_Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF.PitchManagementTool.ViewModels.Inventory_ViewModels
{
    public class InventoryManage_Usercontrol_Viewmodel : BaseViewModel
    {
        #region INVENTORYMANAGE_USERCONTROL BINDING
        #region DATA
        // selected COMMODITIES
        private COMMODITy _selectedCommodities;
        public COMMODITy selectedCommodities { get => _selectedCommodities; set { _selectedCommodities = value; OnPropertyChanged(); } }

        //RECEIPTDETAILCOMMODITIESLISTFILTER
        private ObservableCollection<COMMODITy> _COMMODITIESLISTFILTER;
        public ObservableCollection<COMMODITy> COMMODITIESLISTFILTER { get => _COMMODITIESLISTFILTER; set { _COMMODITIESLISTFILTER = value; OnPropertyChanged(); } }

        //RECEIPTDETAILCOMMODITIESLIST
        private List<COMMODITy> _COMMODITIESLIST;
        public List<COMMODITy> COMMODITIESLIST { get => _COMMODITIESLIST; set { _COMMODITIESLIST = value; OnPropertyChanged(); } }
        
        #endregion
        #region COMMAND
        public ICommand btnConfirmEditCommoditiesDetailReceiptCommand { get; set; }
        public ICommand btnDeleteCommoditiesDetailReceiptCommand { get; set; }
        #endregion 
        #endregion
        public InventoryManage_Usercontrol_Viewmodel()
        {
            SetupDataCommoditiesListDTG();
        }

        public void SetupDataCommoditiesListDTG()
        {
            COMMODITIESLIST = new List<COMMODITy>();
            COMMODITIESLISTFILTER = new ObservableCollection<COMMODITy>();

            CommoditiesService commoditiesService = new CommoditiesService();
            COMMODITIESLIST = commoditiesService.GetListCommodities();
            foreach(var item in COMMODITIESLIST)
            {
                COMMODITIESLISTFILTER.Add(item);
            }    
        }
    }
}
