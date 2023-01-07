using Domain.PitchManagementTool;
using Domain.PitchManagementTool.Services.Commodities_Services;
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
    public class EditReceipt_Window_ViewModel : BaseViewModel
    {
        //Logged Account
        private USER _loggedInAccount;
        public USER loggedInAccount { get => _loggedInAccount; set { _loggedInAccount = value; OnPropertyChanged(); } }


        #region CONFIRM PAYMENT WINDOW 
        // totalCostCommoditiesReceipt paidCostReceipt
        private string _costInConfirmPaymentWindow;
        public string costInConfirmPaymentWindow { get => _costInConfirmPaymentWindow; set { _costInConfirmPaymentWindow = value; OnPropertyChanged(); } }



        #region COMMAND
        public ICommand btnConfirmPaymentReceipt { get; set; }
        #endregion
        #endregion





        #region EDITCOMMODITIESDETAILS_WINDOW
        #region COMMAND
        public ICommand btnConfirmEditCommoditiesDetailReceiptCommand { get; set; }
        public ICommand btnDeleteCommoditiesDetailReceiptCommand { get; set; }
        #endregion
        #region DATA
        private int _quantityCommoditiesEditCommoditiesDetailReceipt;
        public int quantityCommoditiesEditCommoditiesDetailReceipt { get => _quantityCommoditiesEditCommoditiesDetailReceipt; set { _quantityCommoditiesEditCommoditiesDetailReceipt = value; OnPropertyChanged(); } }

        private Int32 _totalCostCommoditiesEditCommoditiesDetailReceipt;
        public Int32 totalCostCommoditiesEditCommoditiesDetailReceipt { get => _totalCostCommoditiesEditCommoditiesDetailReceipt; set { _totalCostCommoditiesEditCommoditiesDetailReceipt = value; OnPropertyChanged(); } }
        #endregion
        #endregion



        #region BINDING ADDCOMMODITIESTORECEIPT

        #region DATA
        private string _quantityCommoditiesAddToReceipt;
        public string quantityCommoditiesAddToReceipt { get => _quantityCommoditiesAddToReceipt; set { _quantityCommoditiesAddToReceipt = value; OnPropertyChanged(); } }

        private string _totalCostCommoditiesAddToReceipt;
        public string totalCostCommoditiesAddToReceipt { get => _totalCostCommoditiesAddToReceipt; set { _totalCostCommoditiesAddToReceipt = value; OnPropertyChanged(); } }
        #endregion
        #region COMMAND
        public ICommand btnAddCommoditiesToReceiptCommand { get; set; }
        #endregion
        #endregion


        #region EDITRECEIPT_WINDOW

        #region DATA BINDING isNeededToPay

        // bit to enable PaymentBUTTON
        private bool _isNeededToPay;
        public bool isNeededToPay { get => _isNeededToPay; set { _isNeededToPay = value; OnPropertyChanged(); } }



        // selected COMMODITIES
        private COMMODITy _selectedCommodities;
        public COMMODITy selectedCommodities { get => _selectedCommodities; set { _selectedCommodities = value; OnPropertyChanged(); } }

        //RECEIPTDETAILCOMMODITIESLISTFILTER
        private ObservableCollection<COMMODITy> _COMMODITIESLISTFILTER;
        public ObservableCollection<COMMODITy> COMMODITIESLISTFILTER { get => _COMMODITIESLISTFILTER; set { _COMMODITIESLISTFILTER = value; OnPropertyChanged(); } }

        //RECEIPTDETAILCOMMODITIESLIST
        private List<COMMODITy> _COMMODITIESLIST;
        public List<COMMODITy> COMMODITIESLIST { get => _COMMODITIESLIST; set { _COMMODITIESLIST = value; OnPropertyChanged(); } }

        // totalCostCommoditiesReceipt paidCostReceipt
        private string _totalCostCommoditiesReceipt;
        public string totalCostCommoditiesReceipt { get => _totalCostCommoditiesReceipt; set { _totalCostCommoditiesReceipt = value; OnPropertyChanged(); } }

        private string _usedCostPitch;
        public string usedCostPitch { get => _usedCostPitch; set { _usedCostPitch = value; OnPropertyChanged(); } }

        private string _totalCostReceipt;
        public string totalCostReceipt { get => _totalCostReceipt; set { _totalCostReceipt = value; OnPropertyChanged(); } }

        private string _paidCostReceipt;
        public string paidCostReceipt { get => _paidCostReceipt; set { _paidCostReceipt = value; OnPropertyChanged(); } }

        private string _unpaidCostReceipt;
        public string unpaidCostReceipt { get => _unpaidCostReceipt; set { _unpaidCostReceipt = value; OnPropertyChanged(); } }

        //Selected Pitch TO BOOKINg
        private CUSTOMER_PAYMENT_RECEIPT _selectedReceipt;
        public CUSTOMER_PAYMENT_RECEIPT selectedReceipt { get => _selectedReceipt; set { _selectedReceipt = value; OnPropertyChanged(); } }

        // selectedReceiptCommoditiesDetail
        private CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES _selectedReceiptCommoditiesDetail;
        public CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES selectedReceiptCommoditiesDetail { get => _selectedReceiptCommoditiesDetail; set { _selectedReceiptCommoditiesDetail = value; OnPropertyChanged(); } }

        //RECEIPTDETAILCOMMODITIESLISTFILTER
        private ObservableCollection<CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES> _RECEIPTDETAILCOMMODITIESLIST;
        public ObservableCollection<CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES> RECEIPTDETAILCOMMODITIESLIST { get => _RECEIPTDETAILCOMMODITIESLIST; set { _RECEIPTDETAILCOMMODITIESLIST = value; OnPropertyChanged(); } }

        //RECEIPTDETAILCOMMODITIESLIST
        private List<CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES> _RECEIPTDETAILCOMMODITIESLISTFROMDTB;
        public List<CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES> RECEIPTDETAILCOMMODITIESLISTFROMDTB { get => _RECEIPTDETAILCOMMODITIESLISTFROMDTB; set { _RECEIPTDETAILCOMMODITIESLISTFROMDTB = value; OnPropertyChanged(); } }

        #endregion
        #region COMMAND BINDING
        public ICommand btnQuitEditReceiptCommand { get; set; }
        public ICommand btnEditBookingCommand { get; set; }

        public ICommand btnSelectCommoditiesCommand { get; set; }

        public ICommand btnEditReceiptCommoditesDetailCommand { get; set; }

        public ICommand btnPaymentReceipt { get; set; }

        public ICommand btnFilterCommoditiesTypeCommand { get; set; }

        public ICommand btnFilterCommoditiesDefaultCommand { get; set; }
        #endregion

        #endregion
        public EditReceipt_Window_ViewModel()
        {
            SetupDataCommodities();
            //SetupDataReceipt();
            btnPaymentReceipt = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                ConfirmPaymentReceipt_Window confirmPaymentReceipt_Window = new ConfirmPaymentReceipt_Window();
                costInConfirmPaymentWindow = "";
                confirmPaymentReceipt_Window.ShowDialog();
                //CUSTOMER_PAYMENT_RECEIPT tempReceipt = new CUSTOMER_PAYMENT_RECEIPT();
                //tempReceipt = DataProvider.Ins.DB.CUSTOMER_PAYMENT_RECEIPT.Where(x=>x.ID_CUSTOMER_PAYMENT_RECEIPT == selectedReceipt.ID_CUSTOMER_PAYMENT_RECEIPT).FirstOrDefault();
                //tempReceipt.IS_DONE = "Đã hoàn thành";
                //DataProvider.Ins.DB.SaveChanges();
                //MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                //p.Close();

                //ReceiptManage_UserControl receiptManage_UserControl = new ReceiptManage_UserControl();
                //var receiptManage_UserControl_VM = receiptManage_UserControl.DataContext as ReceiptManage_Usercontrol_Viewmodel;
                //receiptManage_UserControl_VM.FilterReceiptList();
            });
            btnQuitEditReceiptCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                p.Close();
                ReceiptManage_UserControl receiptManage_UserControl = new ReceiptManage_UserControl();
                var receiptManage_UserControl_VM = receiptManage_UserControl.DataContext as ReceiptManage_Usercontrol_Viewmodel;
                receiptManage_UserControl_VM.FilterReceiptList();
            });
            btnEditReceiptCommoditesDetailCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                if(isNeededToPay == false)
                {
                    MessageBox.Show("Hóa đơn đã thanh toán, không thể chỉnh sửa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }    
                else
                {
                    EditCommoditiesDetailReceipt_Window editCommoditiesToReceipt_Window = new EditCommoditiesDetailReceipt_Window();
                    quantityCommoditiesEditCommoditiesDetailReceipt = selectedReceiptCommoditiesDetail.QUANTITY;
                    editCommoditiesToReceipt_Window.ShowDialog();
                }    
            });

            btnSelectCommoditiesCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (isNeededToPay == false)
                {
                    MessageBox.Show("Hóa đơn đã thanh toán, không thể chỉnh sửa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    AddCommoditiesToReceipt_Window addCommoditiesToReceipt_Window = new AddCommoditiesToReceipt_Window();
                    addCommoditiesToReceipt_Window.ShowDialog();
                }
            });



            #region ADDCOMMODITIESTORECEIPT COMMAND HANDLING

            //this btn Create New CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES
            btnAddCommoditiesToReceiptCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                Receipt_Detail_Commodities_Service_Service receipt_Detail_Commodities_Service_Service = new Receipt_Detail_Commodities_Service_Service();

                //LIST IS EMPTY
                if (RECEIPTDETAILCOMMODITIESLISTFROMDTB.Count() == 0)
                {
                    CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES newDetail_Commodities = new CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES();
                    newDetail_Commodities.CUSTOMER_PAYMENT_RECEIPT = selectedReceipt;
                    newDetail_Commodities.COMMODITy = selectedCommodities;
                    newDetail_Commodities.QUANTITY = Convert.ToInt32(quantityCommoditiesAddToReceipt);
                    newDetail_Commodities.TOTAL_COST_ACCOMPANIED_SERVICE = (newDetail_Commodities.QUANTITY * Convert.ToInt32(newDetail_Commodities.COMMODITy.SELL_PRICE)).ToString();
                    if (receipt_Detail_Commodities_Service_Service.AddNewReceipt_Detail_Commodities(newDetail_Commodities) == true)
                    {
                        MessageBox.Show("Thêm dịch vụ vào hóa đơn thành công khi chưa có gì nè!");
                        ClearDataAddCommoditiesToReceiptWindow();
                        UpdateCostReceipt(newDetail_Commodities.TOTAL_COST_ACCOMPANIED_SERVICE);
                        SubQuantityCommoditiesOnDTB(newDetail_Commodities.COMMODITy, newDetail_Commodities.QUANTITY);
                        SetupDataReceipt();
                        p.Close();
                        is_ChangedReceipt();
                        return;
                    }
                }

                else
                {
                    CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES existedCommoditiesDetail = RECEIPTDETAILCOMMODITIESLISTFROMDTB.Where(x => x.ID_COMMODITIES == selectedCommodities.ID_COMMODITIES).FirstOrDefault();

                    if (existedCommoditiesDetail != null)
                    {
                        Int64 pastCost = 0;
                        Int64 subCost = 0;

                        Int32 pastQuantity = 0;
                        Int32 subQuantity = 0;

                        pastCost = Convert.ToInt64(existedCommoditiesDetail.TOTAL_COST_ACCOMPANIED_SERVICE);
                        pastQuantity = existedCommoditiesDetail.QUANTITY;

                        existedCommoditiesDetail.QUANTITY += Convert.ToInt32(quantityCommoditiesAddToReceipt);

                        existedCommoditiesDetail.TOTAL_COST_ACCOMPANIED_SERVICE = (existedCommoditiesDetail.QUANTITY * Convert.ToInt32(existedCommoditiesDetail.COMMODITy.SELL_PRICE)).ToString();

                        subCost = Convert.ToInt64(existedCommoditiesDetail.TOTAL_COST_ACCOMPANIED_SERVICE) - pastCost;
                        subQuantity = existedCommoditiesDetail.QUANTITY - pastQuantity;

                        UpdateCostReceipt(subCost.ToString());

                        if (receipt_Detail_Commodities_Service_Service.UpdateReceipt_Detail_Commodities(existedCommoditiesDetail))
                        {
                            MessageBox.Show("Thêm số lượng dịch vụ vào hóa đơn thành công!");
                            ClearDataAddCommoditiesToReceiptWindow();
                            SetupDataReceipt();
                            SubQuantityCommoditiesOnDTB(existedCommoditiesDetail.COMMODITy, subQuantity);
                            p.Close();
                            is_ChangedReceipt();
                            return;
                        }
                    }
                    else
                    {
                        CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES newDetail_Commodities = new CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES();
                        newDetail_Commodities.CUSTOMER_PAYMENT_RECEIPT = selectedReceipt;
                        newDetail_Commodities.COMMODITy = selectedCommodities;
                        newDetail_Commodities.QUANTITY = Convert.ToInt32(quantityCommoditiesAddToReceipt);
                        newDetail_Commodities.TOTAL_COST_ACCOMPANIED_SERVICE = (newDetail_Commodities.QUANTITY * Convert.ToInt32(newDetail_Commodities.COMMODITy.SELL_PRICE)).ToString();
                        if (receipt_Detail_Commodities_Service_Service.AddNewReceipt_Detail_Commodities(newDetail_Commodities) == true)
                        {
                            MessageBox.Show("Thêm dịch vụ vào hóa đơn thành công!");
                            ClearDataAddCommoditiesToReceiptWindow();
                            UpdateCostReceipt(newDetail_Commodities.TOTAL_COST_ACCOMPANIED_SERVICE);
                            SubQuantityCommoditiesOnDTB(newDetail_Commodities.COMMODITy, newDetail_Commodities.QUANTITY);
                            SetupDataReceipt();
                            p.Close();
                            is_ChangedReceipt();
                            return;
                        }
                    }
                }
            });
            #endregion

            #region EDITCOMMODITIES COMMAND HANDLING
            btnDeleteCommoditiesDetailReceiptCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dịch vụ khỏi hóa đơn?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {

                    string deleteCostCommodities;
                    Receipt_Detail_Commodities_Service_Service receipt_Detail_Commodities_Service_Service = new Receipt_Detail_Commodities_Service_Service();

                    CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES existedCommoditiesDetail = RECEIPTDETAILCOMMODITIESLISTFROMDTB.Where(x => x.ID_COMMODITIES == selectedReceiptCommoditiesDetail.ID_COMMODITIES).FirstOrDefault();

                    quantityCommoditiesEditCommoditiesDetailReceipt = -quantityCommoditiesEditCommoditiesDetailReceipt;
                    deleteCostCommodities = ((-Convert.ToInt64(existedCommoditiesDetail.TOTAL_COST_ACCOMPANIED_SERVICE)).ToString());
                    p.Close();
                    SubQuantityCommoditiesOnDTB(existedCommoditiesDetail.COMMODITy, quantityCommoditiesEditCommoditiesDetailReceipt);
                    receipt_Detail_Commodities_Service_Service.DeleteReceipt_Detail_Commodities(existedCommoditiesDetail);
                    UpdateCostReceipt(deleteCostCommodities);
                    SetupDataReceipt();
                    is_ChangedReceipt();
                }
                else
                {
                    return;
                }
            });

            btnConfirmEditCommoditiesDetailReceiptCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                Receipt_Detail_Commodities_Service_Service receipt_Detail_Commodities_Service_Service = new Receipt_Detail_Commodities_Service_Service();
                CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES existedCommoditiesDetail = RECEIPTDETAILCOMMODITIESLISTFROMDTB.Where(x => x.ID_COMMODITIES == selectedReceiptCommoditiesDetail.ID_COMMODITIES).FirstOrDefault();


                Int64 pastCost = 0;
                Int64 subCost = 0;

                Int32 pastQuantity = 0;
                Int32 subQuantity = 0;

                pastCost = Convert.ToInt64(existedCommoditiesDetail.TOTAL_COST_ACCOMPANIED_SERVICE);
                pastQuantity = existedCommoditiesDetail.QUANTITY;

                if ((quantityCommoditiesEditCommoditiesDetailReceipt - existedCommoditiesDetail.QUANTITY) > existedCommoditiesDetail.COMMODITy.QUANTITY_ON_HAND)
                {
                    MessageBox.Show("Số lượng thêm vào không thể vượt quá số lượng tồn", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (quantityCommoditiesEditCommoditiesDetailReceipt == pastQuantity)
                {
                    MessageBoxResult result = MessageBox.Show("Số lượng không thay đổi, bạn chắc chắc muốn thoát?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        p.Close();
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
                if (quantityCommoditiesEditCommoditiesDetailReceipt < pastQuantity)
                {
                    quantityCommoditiesEditCommoditiesDetailReceipt = quantityCommoditiesEditCommoditiesDetailReceipt - pastQuantity;
                }
                if (quantityCommoditiesEditCommoditiesDetailReceipt > pastQuantity)
                {
                    quantityCommoditiesEditCommoditiesDetailReceipt = quantityCommoditiesEditCommoditiesDetailReceipt - existedCommoditiesDetail.QUANTITY;
                }
                existedCommoditiesDetail.QUANTITY += Convert.ToInt32(quantityCommoditiesEditCommoditiesDetailReceipt);

                existedCommoditiesDetail.TOTAL_COST_ACCOMPANIED_SERVICE = (existedCommoditiesDetail.QUANTITY * Convert.ToInt32(existedCommoditiesDetail.COMMODITy.SELL_PRICE)).ToString();

                subCost = Convert.ToInt64(existedCommoditiesDetail.TOTAL_COST_ACCOMPANIED_SERVICE) - pastCost;
                subQuantity = existedCommoditiesDetail.QUANTITY - pastQuantity;

                UpdateCostReceipt(subCost.ToString());

                if (receipt_Detail_Commodities_Service_Service.UpdateReceipt_Detail_Commodities(existedCommoditiesDetail))
                {
                    MessageBox.Show("Chỉnh sửa số lượng dịch vụ vào hóa đơn thành công!");
                    ClearDataAddCommoditiesToReceiptWindow();
                    SetupDataReceipt();
                    SubQuantityCommoditiesOnDTB(existedCommoditiesDetail.COMMODITy, subQuantity);
                    p.Close();
                    is_ChangedReceipt();
                    return;
                }
            });
            #endregion

            #region CONFIRMPAYMENTRECEIP COMMAND HANDLING
            btnConfirmPaymentReceipt = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                MessageBoxResult result = MessageBox.Show("Xác nhận hoàn tất thanh toán", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    CUSTOMER_PAYMENT_RECEIPT tempReceipt = new CUSTOMER_PAYMENT_RECEIPT();
                    tempReceipt = DataProvider.Ins.DB.CUSTOMER_PAYMENT_RECEIPT.Where(x => x.ID_CUSTOMER_PAYMENT_RECEIPT == selectedReceipt.ID_CUSTOMER_PAYMENT_RECEIPT).FirstOrDefault();

                    bool checkCost()
                    {
                        bool success = false;
                        Int64 longTotalCostReceipt = Convert.ToInt64(tempReceipt.TOTAL_COST);
                        Int64 longPaidCostReceipt = Convert.ToInt64(tempReceipt.COST_PAID);
                        Int64 longUnpaidCostReceipt = Convert.ToInt64(tempReceipt.COST_UNPAID);
                        Int64 longConfirmPaymentCostReceipt = Convert.ToInt64(costInConfirmPaymentWindow);

                        if(longConfirmPaymentCostReceipt > longUnpaidCostReceipt)
                        {
                            MessageBox.Show("Số tiền thanh toán không được lớn hơn số tiền cần thanh toán", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                            success = false;
                            return success;
                        }    

                        if(longConfirmPaymentCostReceipt < longUnpaidCostReceipt)
                        {
                            tempReceipt.COST_PAID = (longPaidCostReceipt +longConfirmPaymentCostReceipt).ToString();

                            longPaidCostReceipt = Convert.ToInt64(tempReceipt.COST_PAID);

                            tempReceipt.COST_UNPAID = (longTotalCostReceipt - longPaidCostReceipt).ToString();
                            tempReceipt.UPDATE_AT = DateTime.UtcNow.AddHours(7);
                            tempReceipt.USER1 = loggedInAccount;

                            MessageBox.Show("Thanh toán thành công nhưng chưa thanh toán đủ \nTrạng thái hóa đơn sẽ không được cập nhật", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                            success = true;
                            return success;
                        }    

                        if(longConfirmPaymentCostReceipt == longUnpaidCostReceipt)
                        {
                            tempReceipt.COST_PAID = tempReceipt.TOTAL_COST;
                            tempReceipt.IS_DONE = "Đã hoàn thành";
                            tempReceipt.COST_UNPAID = "0";
                            tempReceipt.UPDATE_AT = DateTime.UtcNow.AddHours(7);
                            tempReceipt.USER1 = loggedInAccount;
                            success = true;
                            MessageBox.Show("Thanh toán thành công\nĐã thanh toán đủ tổng tiền hóa đơn \nTrạng thái hóa đơn sẽ được cập nhật", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                            isNeededToPay = false;
                            return success;
                        }    
                        
                        return success;
                    }
                   
                    if(checkCost() == true)
                    {
                        DataProvider.Ins.DB.SaveChanges();
                        p.Close();
                        ReceiptManage_UserControl receiptManage_UserControl = new ReceiptManage_UserControl();
                        var receiptManage_UserControl_VM = receiptManage_UserControl.DataContext as ReceiptManage_Usercontrol_Viewmodel;
                        receiptManage_UserControl_VM.FilterReceiptList();
                        SetupDataReceipt();
                        UpdateCostReceiptWithoutParameter();
                    }    
                }
            });
            #endregion
        }

        public void is_ChangedReceipt()
        {
            CUSTOMER_PAYMENT_RECEIPT tempReceipt = new CUSTOMER_PAYMENT_RECEIPT();
            tempReceipt = DataProvider.Ins.DB.CUSTOMER_PAYMENT_RECEIPT.Where(x => x.ID_CUSTOMER_PAYMENT_RECEIPT == selectedReceipt.ID_CUSTOMER_PAYMENT_RECEIPT).FirstOrDefault();
            if (tempReceipt.IS_DONE == "Đã hoàn thành")
            {
                tempReceipt.IS_DONE = "Chưa hoàn thành";
                DataProvider.Ins.DB.SaveChanges();
            }
            if(tempReceipt.IS_DONE == "Đã hoàn thành")
            {
                isNeededToPay = false;
            }    
            else
            {
                isNeededToPay = true;
            }    
        }
        public void SubQuantityCommoditiesOnDTB(COMMODITy subQuantityCommodities, int quantity)
        {
            COMMODITy tempCommodities = new COMMODITy();
            tempCommodities = DataProvider.Ins.DB.COMMODITIES.Where(x => x.ID_COMMODITIES == subQuantityCommodities.ID_COMMODITIES).FirstOrDefault();
            tempCommodities.QUANTITY_ON_HAND -= quantity;
            DataProvider.Ins.DB.SaveChanges();
            SetupDataCommodities();
        }
        public void UpdateCostReceipt(string costCommodities)
        {

            CUSTOMER_PAYMENT_RECEIPT tempReceipt = new CUSTOMER_PAYMENT_RECEIPT();
            tempReceipt = DataProvider.Ins.DB.CUSTOMER_PAYMENT_RECEIPT.Where(x => x.ID_CUSTOMER_PAYMENT_RECEIPT == selectedReceipt.ID_CUSTOMER_PAYMENT_RECEIPT).FirstOrDefault();

            Int64 pastTotalCostCommodities = Convert.ToInt64(tempReceipt.COST_COMMODITIES_SERVICE);

            tempReceipt.COST_COMMODITIES_SERVICE = (Convert.ToInt64(costCommodities) + Convert.ToInt64(tempReceipt.COST_COMMODITIES_SERVICE)).ToString();
            tempReceipt.TOTAL_COST = (Convert.ToInt64(tempReceipt.TOTAL_COST) + Convert.ToInt64(tempReceipt.COST_COMMODITIES_SERVICE) - pastTotalCostCommodities).ToString();
            DataProvider.Ins.DB.SaveChanges();

            selectedReceipt.COST_UNPAID = (Convert.ToInt64(selectedReceipt.TOTAL_COST) - Convert.ToInt64(selectedReceipt.COST_PAID)).ToString();

            totalCostReceipt = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", Convert.ToDouble(selectedReceipt.TOTAL_COST));
            paidCostReceipt = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", Convert.ToDouble(selectedReceipt.COST_PAID));
            unpaidCostReceipt = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", Convert.ToDouble(selectedReceipt.COST_UNPAID));
        }

        public void UpdateCostReceiptWithoutParameter()
        {
            CUSTOMER_PAYMENT_RECEIPT tempReceipt = new CUSTOMER_PAYMENT_RECEIPT();
            tempReceipt = DataProvider.Ins.DB.CUSTOMER_PAYMENT_RECEIPT.Where(x => x.ID_CUSTOMER_PAYMENT_RECEIPT == selectedReceipt.ID_CUSTOMER_PAYMENT_RECEIPT).FirstOrDefault();

            totalCostReceipt = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", Convert.ToDouble(selectedReceipt.TOTAL_COST));
            paidCostReceipt = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", Convert.ToDouble(selectedReceipt.COST_PAID));
            unpaidCostReceipt = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", Convert.ToDouble(selectedReceipt.COST_UNPAID));
        }


        public void SetupDataReceipt()
        {

            RECEIPTDETAILCOMMODITIESLIST = new ObservableCollection<CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES>();
            RECEIPTDETAILCOMMODITIESLISTFROMDTB = new List<CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES>();

            Receipt_Detail_Commodities_Service_Service receipt_Detail_Commodities_Service_Service = new Receipt_Detail_Commodities_Service_Service();

            RECEIPTDETAILCOMMODITIESLISTFROMDTB = receipt_Detail_Commodities_Service_Service.GetListCommoditiesDetailByIDReceipt(selectedReceipt.ID_CUSTOMER_PAYMENT_RECEIPT);


            Int64 tempCostCommodities = 0;

            foreach (var receiptCommoditiesDetail in RECEIPTDETAILCOMMODITIESLISTFROMDTB)
            {
                RECEIPTDETAILCOMMODITIESLIST.Add(receiptCommoditiesDetail);
                tempCostCommodities += Convert.ToInt64(receiptCommoditiesDetail.TOTAL_COST_ACCOMPANIED_SERVICE);
            }
            totalCostCommoditiesReceipt = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", Convert.ToDouble(tempCostCommodities));

        }

        public void SetupDataReceiptByIDReceiptPayment(int idSelectedReceipt)
        {

            RECEIPTDETAILCOMMODITIESLIST = new ObservableCollection<CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES>();
            RECEIPTDETAILCOMMODITIESLISTFROMDTB = new List<CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES>();

            Receipt_Detail_Commodities_Service_Service receipt_Detail_Commodities_Service_Service = new Receipt_Detail_Commodities_Service_Service();

            RECEIPTDETAILCOMMODITIESLISTFROMDTB = receipt_Detail_Commodities_Service_Service.GetListCommoditiesDetailByIDReceipt(idSelectedReceipt);


            Int64 tempCostCommodities = 0;

            foreach (var receiptCommoditiesDetail in RECEIPTDETAILCOMMODITIESLISTFROMDTB)
            {
                RECEIPTDETAILCOMMODITIESLIST.Add(receiptCommoditiesDetail);
                tempCostCommodities += Convert.ToInt64(receiptCommoditiesDetail.TOTAL_COST_ACCOMPANIED_SERVICE);
            }
            totalCostCommoditiesReceipt = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", Convert.ToDouble(tempCostCommodities));
        }

        public void ClearDataAddCommoditiesToReceiptWindow()
        {
            quantityCommoditiesAddToReceipt = "";
            selectedCommodities = null;
        }
        public void SetupDataCommodities()
        {
            COMMODITIESLIST = new List<COMMODITy>();
            COMMODITIESLISTFILTER = new ObservableCollection<COMMODITy>();

            CommoditiesService commoditiesService = new CommoditiesService();
            COMMODITIESLIST = commoditiesService.GetListCommodities();

            foreach (var tempCommodities in COMMODITIESLIST)
            {
                COMMODITIESLISTFILTER.Add(tempCommodities);
            }
        }
    }
}
