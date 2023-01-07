using Domain.PitchManagementTool;
using Domain.PitchManagementTool.Services.Receipt_Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF.PitchManagementTool.Views.Receipt_Views;

namespace WPF.PitchManagementTool.ViewModels.Receipt_ViewModels
{
    public class ReceiptManage_Usercontrol_Viewmodel : BaseViewModel
    {  //Logged Account
        private USER _loggedInAccount;
        public USER loggedInAccount { get => _loggedInAccount; set { _loggedInAccount = value; OnPropertyChanged(); } }


        #region BINDING ReceiptManage_Window

        #region COMMAND BINDING
        public ICommand btnFilterReceiptCommand { get; set; }
        public ICommand btnFilterReceiptDefaultCommand { get; set; }
        public ICommand btnEditReceiptCommand { get; set; }
        #endregion

        #region TEXT BINDING 
        //RECEIPTLIST FROM DTB
        private List<CUSTOMER_PAYMENT_RECEIPT> _RECEIPTLIST;
        public List<CUSTOMER_PAYMENT_RECEIPT> RECEIPTLIST{ get => _RECEIPTLIST; set { _RECEIPTLIST = value; OnPropertyChanged(); } }

        //RECEIPTLISTFILTER 
        private ObservableCollection<CUSTOMER_PAYMENT_RECEIPT> _RECEIPTLISTFILTER;
        public ObservableCollection<CUSTOMER_PAYMENT_RECEIPT> RECEIPTLISTFILTER { get => _RECEIPTLISTFILTER; set { _RECEIPTLISTFILTER = value; OnPropertyChanged(); } }
        //Selected Receipt to EDIT
        private string _receiptDateFilter;
        public string receiptDateFilter { get => _receiptDateFilter; set { _receiptDateFilter = value; OnPropertyChanged(nameof(receiptDateFilter)); } }

        //STATUSRECEIPTISTCOMBOBOX
        private ObservableCollection<string> _STATUSRECEIPTLISTCOMBOBOX;
        public ObservableCollection<string> STATUSRECEIPTLISTCOMBOBOX { get => _STATUSRECEIPTLISTCOMBOBOX; set { _STATUSRECEIPTLISTCOMBOBOX = value; OnPropertyChanged(); } }

        //Selected Pitch TO BOOKING
        private CUSTOMER_PAYMENT_RECEIPT _selectedReceipt;
        public CUSTOMER_PAYMENT_RECEIPT selectedReceipt { get => _selectedReceipt; set { _selectedReceipt = value; OnPropertyChanged(); } }

        private string _selectedStatusReceipt;
        public string selectedStatusReceipt { get => _selectedStatusReceipt; set { _selectedStatusReceipt = value; OnPropertyChanged(nameof(selectedStatusReceipt)); } }

        //PITCHTYPELIST COMBOBOX
        private ObservableCollection<string> _PITCHTYPELISTCOMBOBOX;
        public ObservableCollection<string> PITCHTYPELISTCOMBOBOX { get => _PITCHTYPELISTCOMBOBOX; set { _PITCHTYPELISTCOMBOBOX = value; OnPropertyChanged(); } }
        //Selected item in combobox PitchType
        private string _selectedPitchType;
        public string selectedPitchType { get => _selectedPitchType; set { _selectedPitchType = value; OnPropertyChanged(nameof(selectedPitchType)); } }
        #endregion


        #endregion
        public ReceiptManage_Usercontrol_Viewmodel()
        {
            SetupDataCombobox();
            btnFilterReceiptCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                FilterReceiptList();
            });

            btnEditReceiptCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {

                EditReceipt_Window editReceipt_Window = new EditReceipt_Window();
                var editReceipt_Window_VM = editReceipt_Window.DataContext as EditReceipt_Window_ViewModel;
                editReceipt_Window_VM.selectedReceipt = (CUSTOMER_PAYMENT_RECEIPT)p;
                editReceipt_Window_VM.loggedInAccount = loggedInAccount;

                editReceipt_Window_VM.usedCostPitch = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", Convert.ToDouble(selectedReceipt.COST_USED_PITCH));

                editReceipt_Window_VM.totalCostReceipt = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", Convert.ToDouble(selectedReceipt.TOTAL_COST));

                editReceipt_Window_VM.paidCostReceipt = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", Convert.ToDouble(selectedReceipt.COST_PAID));

                editReceipt_Window_VM.unpaidCostReceipt = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", Convert.ToDouble(selectedReceipt.COST_UNPAID));

                editReceipt_Window_VM.SetupDataReceiptByIDReceiptPayment(selectedReceipt.ID_CUSTOMER_PAYMENT_RECEIPT);

                if (Convert.ToInt64 (selectedReceipt.COST_UNPAID) > 0)
                {
                    editReceipt_Window_VM.isNeededToPay = true;
                }

                editReceipt_Window.ShowDialog();
            });
        }

        public void FilterReceiptList()
        {
            ReceiptService receiptServive = new ReceiptService();

            RECEIPTLIST = new List<CUSTOMER_PAYMENT_RECEIPT>();
            RECEIPTLIST = receiptServive.GetListRececiptForFilter(receiptDateFilter, selectedPitchType, selectedStatusReceipt);

            RECEIPTLISTFILTER = new ObservableCollection<CUSTOMER_PAYMENT_RECEIPT>();

            foreach (var item in RECEIPTLIST)
            {
                RECEIPTLISTFILTER.Add(item);
            }

        }

        public void SetupDataCombobox()
        {
            STATUSRECEIPTLISTCOMBOBOX = new ObservableCollection<string>();
            STATUSRECEIPTLISTCOMBOBOX.Add("Tất cả");
            STATUSRECEIPTLISTCOMBOBOX.Add("Chưa hoàn thành");
            STATUSRECEIPTLISTCOMBOBOX.Add("Đã hoàn thành");
            selectedStatusReceipt = "Tất cả";

            PITCHTYPELISTCOMBOBOX = new ObservableCollection<string>();
            PITCHTYPELISTCOMBOBOX.Add("Tất cả");
            PITCHTYPELISTCOMBOBOX.Add("Sân 5 người");
            PITCHTYPELISTCOMBOBOX.Add("Sân 7 người");
            PITCHTYPELISTCOMBOBOX.Add("Sân 11 người");
            selectedPitchType = "Tất cả";

        }
    }
}
