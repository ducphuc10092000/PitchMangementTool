using System;
using System.Collections.Generic;
using LiveCharts;
using LiveCharts.Wpf;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts.Defaults;
using Domain.PitchManagementTool;
using Domain.PitchManagementTool.Services.Receipt_Services;
using System.Windows.Input;
using System.Globalization;
using System.Windows;

namespace WPF.PitchManagementTool.ViewModels.Debt_ViewModels
{

    public class DebtManage_Usercontrol_Viewmodel : BaseViewModel
    {

        //RECEIPTDETAILCOMMODITIESLIST
        private List<CUSTOMER_PAYMENT_RECEIPT> _RECEIPTLISTFROMDTB;
        public List<CUSTOMER_PAYMENT_RECEIPT> RECEIPTLISTFROMDTB { get => _RECEIPTLISTFROMDTB; set { _RECEIPTLISTFROMDTB = value; OnPropertyChanged(); } }

        //RECEIPTDETAILCOMMODITIESLIST
        private List<CUSTOMER_PAYMENT_RECEIPT> _RECEIPTLISTFORFILTER;
        public List<CUSTOMER_PAYMENT_RECEIPT> RECEIPTLISTFORFILTER { get => _RECEIPTLISTFORFILTER; set { _RECEIPTLISTFORFILTER = value; OnPropertyChanged(); } }

        //Date filter
        private string _fromDate;
        public string fromDate { get => _fromDate; set { _fromDate = value; OnPropertyChanged(); } }

        private string _toDate;
        public string toDate { get => _toDate; set { _toDate = value; OnPropertyChanged(); } }


        //Collection for Chart
        private SeriesCollection _PaymentCollection;
        public SeriesCollection PaymentCollection { get => _PaymentCollection; set { _PaymentCollection = value; OnPropertyChanged(); } }

        private SeriesCollection _CartesianChartCollection;
        public SeriesCollection CartesianChartCollection { get => _CartesianChartCollection; set { _CartesianChartCollection = value; OnPropertyChanged(); } }


        //Data for Chart
        private double _costFromUsedPitch;
        public double costFromUsedPitch { get => _costFromUsedPitch; set { _costFromUsedPitch = value; OnPropertyChanged(); } }

        private double _costFromCommodities;
        public double costFromCommodities { get => _costFromCommodities; set { _costFromCommodities = value; OnPropertyChanged(); } }

        private string _costTotalTextbox;
        public string costTotalTextbox { get => _costTotalTextbox; set { _costTotalTextbox = value; OnPropertyChanged(); } }
        private string _costFromUsedPitchTextbox;
        public string costFromUsedPitchTextbox { get => _costFromUsedPitchTextbox; set { _costFromUsedPitchTextbox = value; OnPropertyChanged(); } }
        private string _costFromCommoditiesTextbox;
        public string costFromCommoditiesTextbox { get => _costFromCommoditiesTextbox; set { _costFromCommoditiesTextbox = value; OnPropertyChanged(); } }



        #region COMMAND
        public ICommand btnFilterChartPaymentCommand { get; set; }

        public ICommand btnFilterDefaultChartPaymentCommand { get; set; }
        #endregion

        public DebtManage_Usercontrol_Viewmodel()
        {
            fromDate = DateTime.Today.ToString("dd/MM/yyyy");
            toDate = DateTime.Today.ToString("dd/MM/yyyy");
            SetupDataChartCost();
            SetupDataReceipt();
            FilterForChart();

            btnFilterChartPaymentCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                FilterForChart();
            });
        }


        public void SetupDataFilter()
        {
            RECEIPTLISTFORFILTER = new List<CUSTOMER_PAYMENT_RECEIPT>();
            bool checkTime(DateTime createAt, DateTime from, DateTime to)
            {
                bool success = false;

                int result1 = DateTime.Compare(createAt, from);
                int result2 = DateTime.Compare(to, createAt);

                if ((result1 * result2) >= 0)
                {
                    success = true;
                    return success;
                }

                return success;
            }

            foreach (var item in RECEIPTLISTFROMDTB)
            {
                string tempCreate_At = item.CREATE_AT.ToString("dd/MM/yyyy");
                if (checkTime(Convert.ToDateTime(tempCreate_At), Convert.ToDateTime(fromDate), Convert.ToDateTime(toDate)))
                {
                    RECEIPTLISTFORFILTER.Add(item);
                }
            }
        }
        public void SetupDataReceipt()
        {
            RECEIPTLISTFROMDTB = new List<CUSTOMER_PAYMENT_RECEIPT>();

            ReceiptService receipt_Service = new ReceiptService();

            RECEIPTLISTFROMDTB = receipt_Service.GetListReceipt();



        }

        public void FilterForChart()
        {
            SetupDataFilter();
            if (RECEIPTLISTFORFILTER.Count == 0)
            {
                costFromUsedPitch = 0;
                costFromCommodities = 0;
            }
            else
            {
                costFromUsedPitch = 0;
                costFromCommodities = 0;
                foreach (var tempReceipt in RECEIPTLISTFORFILTER)
                {
                    costFromUsedPitch += Convert.ToDouble(tempReceipt.COST_USED_PITCH);
                    costFromCommodities += Convert.ToDouble(tempReceipt.COST_COMMODITIES_SERVICE);
                }
            }
            costTotalTextbox = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", Convert.ToDouble(costFromUsedPitch + costFromCommodities));
            costFromUsedPitchTextbox = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", Convert.ToDouble(costFromUsedPitch));
            costFromCommoditiesTextbox = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", Convert.ToDouble(costFromCommodities));
            SetupDataChartCost();
        }
        public void SetupDataChartCost()
        {
            PaymentCollection = new SeriesCollection()
            {
                new PieSeries
                {
                    Title="Cho thuê sân",
                    FontSize=20,
                    Values=new ChartValues<ObservableValue> {new ObservableValue(costFromUsedPitch) },
                    DataLabels=true
                },

                new PieSeries
                {
                    Title="Dịch vụ đi kèm",
                    FontSize=20,
                    Values=new ChartValues<ObservableValue> {new ObservableValue(costFromCommodities) },
                    DataLabels=true
                },
            };

            CartesianChartCollection = new SeriesCollection()
            {
                new ColumnSeries
                {
                    Title="Doanh thu",
                    FontSize=20,
                    Values=new ChartValues<ObservableValue> {new ObservableValue(1500000) },
                    DataLabels=true
                },

                new ColumnSeries
                {
                    Title="Lợi nhuận",
                    FontSize=20,
                    Values=new ChartValues<ObservableValue> {new ObservableValue(1000000) },
                    DataLabels=true
                },

                new ColumnSeries
                {
                    Title="Tổng chi",
                    FontSize=20,
                    Values=new ChartValues<ObservableValue> {new ObservableValue(500000) },
                    DataLabels=true
                },
            };
        }
    }
}
