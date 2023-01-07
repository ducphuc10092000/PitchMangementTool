using Domain.PitchManagementTool;
using Domain.PitchManagementTool.Services.Booking_Services;
using Domain.PitchManagementTool.Services.Pitch_Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF.PitchManagementTool.Views.Booking_Views;

namespace WPF.PitchManagementTool.ViewModels.Booking_ViewModels
{
    public class BookingManage_Usercontrol_ViewModel : BaseViewModel
    {
        //Logged Account
        private USER _loggedInAccount;
        public USER loggedInAccount { get => _loggedInAccount; set { _loggedInAccount = value; OnPropertyChanged(); } }

        //PITCHTYPELISTCOMBOBOX
        private ObservableCollection<string> _PITCHTYPELISTCOMBOBOX;
        public ObservableCollection<string> PITCHTYPELISTCOMBOBOX { get => _PITCHTYPELISTCOMBOBOX; set { _PITCHTYPELISTCOMBOBOX = value; OnPropertyChanged(); } }

        //STATUSBOOKINGLISTCOMBOBOX
        private ObservableCollection<string> _STATUSBOOKINGLISTCOMBOBOX;
        public ObservableCollection<string> STATUSBOOKINGLISTCOMBOBOX { get => _STATUSBOOKINGLISTCOMBOBOX; set { _STATUSBOOKINGLISTCOMBOBOX = value; OnPropertyChanged(); } }
        

        //BOOKINGLIST-DATAGRID
        private ObservableCollection<BOOKING> _BOOKINGLISTFILTER;
        public ObservableCollection<BOOKING> BOOKINGLISTFILTER { get => _BOOKINGLISTFILTER; set { _BOOKINGLISTFILTER = value; OnPropertyChanged(); } }

        //BOOKINGLIST
        private List<BOOKING> _BOOKINGLIST;
        public List<BOOKING> BOOKINGLIST { get => _BOOKINGLIST; set { _BOOKINGLIST = value; OnPropertyChanged(); } }

        //Selected Booking In DataGRID
        private BOOKING _selectedBooking;
        public BOOKING selectedBooking { get => _selectedBooking; set { _selectedBooking = value; OnPropertyChanged(nameof(selectedBooking)); } }


        //Selected item in combobox PitchType
        private string _selectedPitchType;
        public string selectedPitchType { get => _selectedPitchType; set { _selectedPitchType = value; OnPropertyChanged(nameof(selectedPitchType)); } }

        //Selected checkinTime
        private string _checkInTimeFilter;
        public string checkInTimeFilter { get => _checkInTimeFilter; set { _checkInTimeFilter = value; OnPropertyChanged(nameof(checkInTimeFilter)); } }
        //Selected checkoutTime
        private string _checkOutTimeFilter;
        public string checkOutTimeFilter { get => _checkOutTimeFilter; set { _checkOutTimeFilter = value; OnPropertyChanged(nameof(checkOutTimeFilter)); } }
        //bookingDate
        private string _bookingDate;
        public string bookingDate { get => _bookingDate; set { _bookingDate = value; OnPropertyChanged(nameof(bookingDate)); } }

        //Selected STATUS BOOKING
        private string _selectedStatusBooking;
        public string selectedStatusBooking { get => _selectedStatusBooking; set { _selectedStatusBooking = value; OnPropertyChanged(nameof(selectedStatusBooking)); } }



        #region COMMAND
        public ICommand btnOpenAddNewBookingWindow { get; set; }

        public ICommand btnFilterBookingDefaultCommand { get; set; }

        public ICommand btnFilterBookingCommand { get; set; }

        public ICommand btnEditBookingCommand { get; set; }
        #endregion


        public BookingManage_Usercontrol_ViewModel()
        {
            SetUpDataPitchTypeCombobox();
            ClearData();

            btnEditBookingCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                EditBooking_Window editBooking_Window = new EditBooking_Window();

                var editBooking_Window_VM = editBooking_Window.DataContext as AddNewBooking_Window_ViewModel;
                editBooking_Window_VM.loggedInAccount = loggedInAccount;
                editBooking_Window_VM.SetUpDataEditBookingWindow();
                editBooking_Window.ShowDialog();
            });

            btnOpenAddNewBookingWindow = new RelayCommand<Window>((p) =>
             {
                 return true;
             }, (p) =>
             {
                 AddNewBooking_Window addNewBooking_Window = new AddNewBooking_Window();

                 var addNewBooking_Window_VM = addNewBooking_Window.DataContext as AddNewBooking_Window_ViewModel;
                 addNewBooking_Window_VM.loggedInAccount = loggedInAccount;
                 addNewBooking_Window.ShowDialog();
             });

            btnFilterBookingCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                if(CheckAttributeFilter() == false)
                {
                    return;
                }    
                FilterBookingList();
            });
            btnFilterBookingDefaultCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                ClearData();
            });
        }

        public void SetUpDataPitchTypeCombobox()
        {


            //Setup Data PITCH_TYPE in COMBOBOX PITCHTYPE
            PITCHTYPELISTCOMBOBOX = new ObservableCollection<string>();
            PitchType_Service pitchType_Service = new PitchType_Service();
            foreach (PITCH_TYPE pitchTypeTemp in pitchType_Service.GetListPitchType())
            {
                PITCHTYPELISTCOMBOBOX.Add(pitchTypeTemp.NAME_PITCH_TYPE);
            }
            //Setup Default Selected Item Combobox PitchTypeList
            selectedPitchType = "Sân 5 người";

            STATUSBOOKINGLISTCOMBOBOX = new ObservableCollection<string>();
            STATUSBOOKINGLISTCOMBOBOX.Add("Tất cả");
            STATUSBOOKINGLISTCOMBOBOX.Add("Đã hoàn thành");
            STATUSBOOKINGLISTCOMBOBOX.Add("Chưa hoàn thành");

            selectedStatusBooking = "Tất cả";
        }

        public void ClearData()
        {
            selectedStatusBooking = "Tất cả";
            selectedPitchType = "Sân 5 người";
            checkInTimeFilter = "";
            checkOutTimeFilter = "";
            bookingDate = "";
            BOOKINGLISTFILTER = new ObservableCollection<BOOKING>();
        }
        public bool CheckAttributeFilter()
        {
            bool success = true;

            if (string.IsNullOrEmpty(checkInTimeFilter))
            {
                MessageBox.Show("Vui lòng chọn thời gian bắt đầu để lọc!"); success = false; return success;
            }
            if (string.IsNullOrEmpty(checkOutTimeFilter))
            {
                MessageBox.Show("Vui lòng chọn thời gian kết thúc để lọc!"); success = false; return success;
            }
            if (string.IsNullOrEmpty(bookingDate))
            {
                MessageBox.Show("Vui lòng chọn ngày để lọc!"); success = false; return success;
            }

            int resultCheckTimeFilter = TimeSpan.Compare(Convert.ToDateTime(checkInTimeFilter).TimeOfDay, Convert.ToDateTime(checkOutTimeFilter).TimeOfDay);


            if (resultCheckTimeFilter >= 0)
            {
                MessageBox.Show("Thời gian kết thúc không được nhỏ hơn thời gian bắt đầu, vui lòng nhập lại!!!", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error); success = false; return success;
            }

            TimeSpan resultCheckTimeFilter_TimeSpan = Convert.ToDateTime(checkOutTimeFilter) - Convert.ToDateTime(checkInTimeFilter);

            if (resultCheckTimeFilter_TimeSpan.Ticks < 36000000000)
            {
                MessageBox.Show("Thời gian kết thúc phải cách thời gian bắt đầu hơn 1 tiếng, vui lòng nhập lại!!!", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error); success = false; return success;
            }
            return success;

        }

        public void FilterBookingList()
        {
            bool isOverDate(DateTime nowDate, DateTime dateBooking)
            {
                bool success = false;

                int result = DateTime.Compare(nowDate, dateBooking);

                if (result >= 0)
                {
                    success = true;
                }

                return success;

            }

            bool isOverTime(DateTime nowTime, DateTime bookingCheckOutTime)
            {
                bool success = false;

                int result = DateTime.Compare(nowTime, bookingCheckOutTime);

                if(result >= 0)
                {
                    success = true;
                }

                return success;

            }

            BOOKINGLISTFILTER = new ObservableCollection<BOOKING>();

            BOOKINGLIST = new List<BOOKING>();

            BookingService bookingService = new BookingService();

            BOOKINGLIST = bookingService.GetListBookingByDateBooking(checkInTimeFilter, checkOutTimeFilter, bookingDate, selectedPitchType);

            foreach(var tempBooking in BOOKINGLIST)
            {
                if (isOverDate(Convert.ToDateTime(DateTime.UtcNow.AddHours(7).ToString("dd/MM/yyyy")),Convert.ToDateTime(tempBooking.DATE_BOOKING)) == true)
                {
                    BOOKING neededUpdateBooking = new BOOKING();
                    neededUpdateBooking = DataProvider.Ins.DB.BOOKINGs.Where(x => x.ID_BOOKING == tempBooking.ID_BOOKING).FirstOrDefault();
                    neededUpdateBooking.IS_DONE = "Đã hoàn thành";
                    DataProvider.Ins.DB.SaveChanges();
                }    
                else
                {
                    if (isOverTime(Convert.ToDateTime(DateTime.UtcNow.AddHours(7).ToString("HH/mm")), Convert.ToDateTime(tempBooking.CHECK_OUT_TIME)) == true)
                    {
                        BOOKING neededUpdateBooking = new BOOKING();
                        neededUpdateBooking = DataProvider.Ins.DB.BOOKINGs.Where(x => x.ID_BOOKING == tempBooking.ID_BOOKING).FirstOrDefault();
                        neededUpdateBooking.IS_DONE = "Đã hoàn thành";
                        DataProvider.Ins.DB.SaveChanges();
                    }
                }
            }    

            if (BOOKINGLIST.Count() == 0)
            {
                MessageBox.Show("Không có lịch đặt sân trong khoảng thời gian này, xin nhập lại và bấm lọc!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {

                if (selectedStatusBooking == "Tất cả")
                {
                    foreach (var tempBooking in BOOKINGLIST)
                    {    
                        BOOKINGLISTFILTER.Add(tempBooking);
                    }
                }

                if(selectedStatusBooking == "Đã hoàn thành")
                {
                    foreach (var tempBooking in BOOKINGLIST)
                    {
                        if(tempBooking.IS_DONE == "Đã hoàn thành")
                        {
                            BOOKINGLISTFILTER.Add(tempBooking);
                        }    
                    }
                }
                if (selectedStatusBooking == "Chưa hoàn thành")
                {
                    foreach (var tempBooking in BOOKINGLIST)
                    {
                        if (tempBooking.IS_DONE == "Chưa hoàn thành")
                        {
                            BOOKINGLISTFILTER.Add(tempBooking);
                        }
                    }
                }

            }
        }

    }
}
