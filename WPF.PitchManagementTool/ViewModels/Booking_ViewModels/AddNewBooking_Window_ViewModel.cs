using Domain.PitchManagementTool;
using Domain.PitchManagementTool.Services.Booking_Services;
using Domain.PitchManagementTool.Services.Pitch_Services;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF.PitchManagementTool.Views.Booking_Views;

namespace WPF.PitchManagementTool.ViewModels.Booking_ViewModels
{
    public class AddNewBooking_Window_ViewModel : BaseViewModel
    {


        //Logged Account
        private USER _loggedInAccount;
        public USER loggedInAccount { get => _loggedInAccount; set { _loggedInAccount = value; OnPropertyChanged(); } }



        #region EDITBOOKINGWINDOW

        #region Command

        public ICommand btnConfirmEditBookingCommand { get; set; }

        public ICommand btnQuitConfirmEditWindowCommand { get; set; }



        public ICommand btnEditBookingCommand { get; set; }

        public ICommand btnDefaultAttributeCommand_EditBooking_Window { get; set; }

        public ICommand btnQuit_EditWindow_Command { get; set; }

        public ICommand btnFilterPitch_EditBooking_Window_Command { get; set; }

        public ICommand btnFilterBookingDefaultCommand_EDITBOOKINGWINDOW { get; set; }

        public ICommand btnCheck_CheckInTime_EditBookingWindow { get; set; }
        public ICommand btnCheck_CheckOutTime_EditBookingWindow { get; set; }

        public ICommand btnEditBooking_SelectPitchCommand { get; set; }
        #endregion

        #region DataBinding

        private string _customerPhoneNumber_EditBookingWindow;
        public string customerPhoneNumber_EditBookingWindow { get => _customerPhoneNumber_EditBookingWindow; set { _customerPhoneNumber_EditBookingWindow = value; OnPropertyChanged(nameof(customerPhoneNumber_EditBookingWindow)); } }
        private string _checkInTime_EditBookingWindow;
        public string checkInTime_EditBookingWindow { get => _checkInTime_EditBookingWindow; set { _checkInTime_EditBookingWindow = value; OnPropertyChanged(nameof(checkInTime_EditBookingWindow)); } }
        private string _checkOutTime_EditBookingWindow;
        public string checkOutTime_EditBookingWindow { get => _checkOutTime_EditBookingWindow; set { _checkOutTime_EditBookingWindow = value; OnPropertyChanged(nameof(checkOutTime_EditBookingWindow)); } }
        private string _bookingDate_EditBookingWindow;
        public string bookingDate_EditBookingWindow { get => _bookingDate_EditBookingWindow; set { _bookingDate_EditBookingWindow = value; OnPropertyChanged(nameof(bookingDate_EditBookingWindow)); } }
        private string _customerName_EditBookingWindow;
        public string customerName_EditBookingWindow { get => _customerName_EditBookingWindow; set { _customerName_EditBookingWindow = value; OnPropertyChanged(nameof(customerName_EditBookingWindow)); } }

        private BOOKING _selectedBooking;
        public BOOKING selectedBooking { get => _selectedBooking; set { _selectedBooking = value; OnPropertyChanged(nameof(selectedBooking)); } }

        private PITCH _selectedPitch_EditBookingWindow;
        public PITCH selectedPitch_EditBookingWindow { get => _selectedPitch_EditBookingWindow; set { _selectedPitch_EditBookingWindow = value; OnPropertyChanged(nameof(selectedPitch_EditBookingWindow)); } }
        #endregion
        #endregion

        #region Binding TEXT WINDOW ADDNEWBOOKING


        //LISTPITCH FILTERED
        private ObservableCollection<PITCH> _PITCHLISTBYFILTER;
        public ObservableCollection<PITCH> PITCHLISTBYFILTER { get => _PITCHLISTBYFILTER; set { _PITCHLISTBYFILTER = value; OnPropertyChanged(); } }

        // LISTPITCH GET BY SERVICE FOR FILTER
        private List<PITCH> _PITCHLISTWITHTYPE;
        public List<PITCH> PITCHLISTWITHTYPE { get => _PITCHLISTWITHTYPE; set { _PITCHLISTWITHTYPE = value; OnPropertyChanged(); } }

        // LISTPITCH
        private List<PITCH> _PITCHLIST;
        public List<PITCH> PITCHLIST { get => _PITCHLIST; set { _PITCHLIST = value; OnPropertyChanged(); } }

        //PITCHTYPELISTCOMBOBOX
        private ObservableCollection<string> _PITCHTYPELISTCOMBOBOX;
        public ObservableCollection<string> PITCHTYPELISTCOMBOBOX { get => _PITCHTYPELISTCOMBOBOX; set { _PITCHTYPELISTCOMBOBOX = value; OnPropertyChanged(); } }

        //Selected Pitch TO BOOKING
        private PITCH _selectedPitch;
        public PITCH selectedPitch { get => _selectedPitch; set { _selectedPitch = value; OnPropertyChanged(); } }

        //Selected item in combobox PitchType
        private string _selectedPitchType;
        public string selectedPitchType { get => _selectedPitchType; set { _selectedPitchType = value; OnPropertyChanged(nameof(selectedPitchType)); } }

        //Selected checkinTime
        private string _checkInTime;
        public string checkInTime { get => _checkInTime; set { _checkInTime = value; OnPropertyChanged(nameof(checkInTime)); } }
        //Selected checkoutTime
        private string _checkOutTime;
        public string checkOutTime { get => _checkOutTime; set { _checkOutTime = value; OnPropertyChanged(nameof(checkOutTime)); } }

        //Selected checkinTime
        private string _checkInTimeFilter;
        public string checkInTimeFilter { get => _checkInTimeFilter; set { _checkInTimeFilter = value; OnPropertyChanged(nameof(checkInTimeFilter)); } }
        //Selected checkoutTime
        private string _checkOutTimeFilter;
        public string checkOutTimeFilter { get => _checkOutTimeFilter; set { _checkOutTimeFilter = value; OnPropertyChanged(nameof(checkOutTimeFilter)); } }

        //bookingDate
        private string _bookingDate;
        public string bookingDate { get => _bookingDate; set { _bookingDate = value; OnPropertyChanged(nameof(bookingDate)); } }
        //CustomerName
        private string _customerName;
        public string customerName { get => _customerName; set { _customerName = value; OnPropertyChanged(nameof(customerName)); } }
        //CustomerPhoneNuumber
        private string _customerPhoneNumber;
        public string customerPhoneNumber { get => _customerPhoneNumber; set { _customerPhoneNumber = value; OnPropertyChanged(nameof(customerPhoneNumber)); } }

        //
        private string _usedCostPitch;
        public string usedCostPitch { get => _usedCostPitch; set { _usedCostPitch = value; OnPropertyChanged(); } }


        //
        public DateTime _checkInTime_timeFormat;
        public DateTime checkInTime_timeFormat { get => _checkInTime_timeFormat; set { _checkInTime_timeFormat = value; OnPropertyChanged(nameof(checkInTime_timeFormat)); } }

        public DateTime _todayDate;
        public DateTime todayDate { get => _todayDate; set { _todayDate = value; OnPropertyChanged(nameof(todayDate)); } }


        //Data Price Of Pitch
        private string _priceOf_5Pitch;
        public string priceOf_5Pitch { get => _priceOf_5Pitch; set { _priceOf_5Pitch = value; OnPropertyChanged(); } }
        private string _priceOf_7Pitch;
        public string priceOf_7Pitch { get => _priceOf_7Pitch; set { _priceOf_7Pitch = value; OnPropertyChanged(); } }
        private string _priceOf_11Pitch;
        public string priceOf_11Pitch { get => _priceOf_11Pitch; set { _priceOf_11Pitch = value; OnPropertyChanged(); } }



        //Enable Binding Btn Check - Btn AddNew
        private bool _isValidCheckInTime;
        public bool isValidCheckInTime { get => _isValidCheckInTime; set { _isValidCheckInTime = value; OnPropertyChanged(); } }

        private bool _isValidCheckOutTime;
        public bool isValidCheckOutTime { get => _isValidCheckOutTime; set { _isValidCheckOutTime = value; OnPropertyChanged(); } }

        private bool _isValidBothTime;
        public bool isValidBothTime { get => _isValidBothTime; set { _isValidBothTime = value; OnPropertyChanged(); } }

        private bool _isFilteredPitch;
        public bool isFilteredPitch { get => _isFilteredPitch; set { _isFilteredPitch = value; OnPropertyChanged(); } }


        private bool _isAddedBooking;
        public bool isAddedBooking { get => _isAddedBooking; set { _isAddedBooking = value; OnPropertyChanged(); } }



        //FILTER DATA
        // LISTPITCH
        private List<BOOKING> _BOOKINGLISTEXISTED;
        public List<BOOKING> BOOKINGLISTEXISTED { get => _BOOKINGLISTEXISTED; set { _BOOKINGLISTEXISTED = value; OnPropertyChanged(); } }


        #endregion

        #region Binding COMMAND  WINDOW ADDNEWBOOKING
        public ICommand btnQuitConfirmWindowCommand { get; set; }
        public ICommand btnQuitCommand { get; set; }
        public ICommand btnFilterPitchBaseTypeCommand { get; set; }
        public ICommand btnFilterBookingDefaultCommand { get; set; }
        public ICommand btnDefaultAttributeCommand { get; set; }
        public ICommand btnAddNewBookingCommand { get; set; }
        public ICommand PitchTypeListChangedCommand { get; set; }

        public ICommand btnSelectPitchCommand { get; set; }


        //Btn CheckTime
        public ICommand btnCheck_CheckInTime { get; set; }
        public ICommand btnCheck_CheckOutTime { get; set; }


        //Btn ConfirmBooking
        public ICommand btnConfirmBookingCommand { get; set; }
        #endregion
        public AddNewBooking_Window_ViewModel()
        {
            #region EDITBOOKING_WINDOW SETUPDATA
            
            #endregion

            #region ADDNEWBOOKING_WINDOW SETUPDATA
            SetupDataBindingEnableBtn();
            SetUpDataPitchTypeCombobox();
            SetUpDataPitchList();
            #endregion

            #region ADDNEWBOOKING_WINDOW HANDLING COMMAND 
            btnCheck_CheckInTime = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (checkInTime != null)
                {
                    if (checkInTimeFilter != null && checkOutTimeFilter != null)
                    {

                        TimeSpan checkInTime_checkOutTimeFilter = Convert.ToDateTime(checkOutTimeFilter) - Convert.ToDateTime(checkInTime);

                        if (checkInTime_checkOutTimeFilter.Ticks < 36000000000)
                        {
                            MessageBox.Show("Thời gian bắt đầu không thể cách thời gian kết thúc đã lọc nhỏ hơn 1 tiếng!", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                            isValidCheckInTime = false;
                            isValidBothTime = isValidCheckInTime && isValidCheckOutTime;
                            return;
                        }

                        int resultCheckInTime_withCheckInTimeFilter = TimeSpan.Compare(Convert.ToDateTime(checkInTime).TimeOfDay, Convert.ToDateTime(checkInTimeFilter).TimeOfDay);


                        int resultCheckInTime_withCheckOutTimeFilter = TimeSpan.Compare(Convert.ToDateTime(checkOutTimeFilter).TimeOfDay, Convert.ToDateTime(checkInTime).TimeOfDay);



                        if (resultCheckInTime_withCheckInTimeFilter >= 0 && resultCheckInTime_withCheckOutTimeFilter >= 0)
                        {
                            isValidCheckInTime = true;
                            isValidBothTime = isValidCheckInTime && isValidCheckOutTime;
                            MessageBox.Show("Thời gian checkIn hợp lệ");
                        }
                        else
                        {
                            if (resultCheckInTime_withCheckInTimeFilter < 0)
                            {
                                MessageBox.Show("Thời gian checkIn không thể trước thời gian đã lọc!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                                isValidCheckInTime = false;
                                isValidBothTime = isValidCheckInTime && isValidCheckOutTime;
                                return;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn thời gian bắt đầu thuê sân!");
                }
            });
            btnCheck_CheckOutTime = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (checkOutTime != null)
                {

                    if (checkInTimeFilter != null && checkOutTimeFilter != null)
                    {

                        int resultCheckOutTime_CheckOutTimeFilter = TimeSpan.Compare(Convert.ToDateTime(checkOutTimeFilter).TimeOfDay, Convert.ToDateTime(checkOutTime).TimeOfDay);


                        TimeSpan resultCheckOutTime_checkInTime = Convert.ToDateTime(checkOutTime) - Convert.ToDateTime(checkInTime);

                        TimeSpan resultCheckOutTime_checkInTimeFilter = Convert.ToDateTime(checkOutTime) - Convert.ToDateTime(checkInTimeFilter);



                        if (resultCheckOutTime_checkInTime.Ticks < 36000000000)
                        {
                            MessageBox.Show("Thời gian cho thuê tối thiểu sân là 1 tiếng", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                            isValidCheckOutTime = false;
                            isValidBothTime = isValidCheckInTime && isValidCheckOutTime;
                            return;
                        }
                        else if (resultCheckOutTime_checkInTimeFilter.Ticks < 36000000000)
                        {
                            MessageBox.Show("Thời gian checkOut không thể cách thời gian đã lọc trước 1 tiếng!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                            isValidCheckOutTime = false;
                            isValidBothTime = isValidCheckInTime && isValidCheckOutTime;
                            return;
                        }
                        else
                        {
                            if (resultCheckOutTime_CheckOutTimeFilter >= 0)
                            {
                                isValidCheckOutTime = true;
                                isValidBothTime = isValidCheckInTime && isValidCheckOutTime;
                                MessageBox.Show("Thời gian checkOut hợp lệ");
                            }
                            else
                            {
                                MessageBox.Show("Thời gian kết thúc thuê sân không thể nằm ngoài thời gian kết thúc đã lọc", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                                isValidCheckOutTime = false;
                                isValidBothTime = isValidCheckInTime && isValidCheckOutTime;
                                return;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn thời gian kết thúc thuê sân!");
                }

            });
            btnQuitCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    ClearData();
                    DefaultAtrribute();
                    p.Close();
                }

            });
            btnQuitConfirmWindowCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    p.Close();
                }

            });
            btnFilterBookingDefaultCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                ClearData();
            });
            btnAddNewBookingCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                isAddedBooking = false;
                if (CheckAttribute() == true)
                {
                    TimeSpan tempTime = Convert.ToDateTime(checkOutTime) - Convert.ToDateTime(checkInTime);
                    double tempCost = Convert.ToDouble(tempTime.Ticks / 36000000000) * Convert.ToInt64(selectedPitch.PITCH_TYPE.PRICE);
                    usedCostPitch = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", tempCost);

                    AddNewBookingPitch_Window addNewBookingPitch_Window = new AddNewBookingPitch_Window();
                    addNewBookingPitch_Window.ShowDialog();
                }

                if(isAddedBooking == true)
                {
                    p.Close();
                }    
            });
            btnConfirmBookingCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                TimeSpan tempTime = Convert.ToDateTime(checkOutTime) - Convert.ToDateTime(checkInTime);
                double tempCost = Convert.ToDouble(tempTime.Ticks / 36000000000) * Convert.ToInt64(selectedPitch.PITCH_TYPE.PRICE);

                BookingService bookingService = new BookingService();

                BOOKING newBOOKING = new BOOKING();

                newBOOKING.PITCH = selectedPitch;
                newBOOKING.USER = loggedInAccount;
                newBOOKING.CHECK_IN_TIME = checkInTime;
                newBOOKING.CHECK_OUT_TIME = checkOutTime;
                newBOOKING.CUSTOMER_NAME = customerName;
                newBOOKING.CUSTOMER_PHONE_NUMBER = customerPhoneNumber;
                newBOOKING.DATE_BOOKING = bookingDate;
                newBOOKING.CREATE_AT = DateTime.UtcNow.AddHours(7);
                newBOOKING.IS_DELETED = false;
                newBOOKING.COST = tempCost.ToString();
                newBOOKING.IS_DONE = "Chưa hoàn thành";
                if (bookingService.AddNewBooking(newBOOKING) == true)
                {
                    MessageBox.Show("Thêm mới lịch đặt sân thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    isAddedBooking = true;
                    ClearData();
                    p.Close();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra, không thể thêm mới lịch đặt sân!");
                }

            });
            btnSelectPitchCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                selectedPitch = DataProvider.Ins.DB.PITCHes.Where(x => x.ID_PITCH.ToString() == p.ToString()).FirstOrDefault();
            });

            btnFilterPitchBaseTypeCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {

                if (CheckAttributeFilter() == false)
                {
                    ClearDataGrid();
                    return;
                }


                FilterPitchList();
                isFilteredPitch = true;
            });
            PitchTypeListChangedCommand = new RelayCommand<ComboBox>((p) =>
            { return p == null ? false : true; }, (p) =>
            {
                selectedPitchType = p.SelectedItem.ToString();
            });
            btnDefaultAttributeCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                ClearData();
            });
            #endregion

            #region EDITBOOKING_WINDOW HANDLING COMMAND
            btnQuitConfirmEditWindowCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    p.Close();
                }
            });
            btnConfirmEditBookingCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                BookingService bookingService = new BookingService();
                if(bookingService.UpdateBooking(selectedBooking) == true)
                {
                    MessageBox.Show("Chỉnh sửa thông tin đặt sân thành công!");
                }

                p.Close();
            });
            btnEditBooking_SelectPitchCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                selectedPitch_EditBookingWindow = DataProvider.Ins.DB.PITCHes.Where(x => x.ID_PITCH.ToString() == p.ToString()).FirstOrDefault();
            });

            btnEditBookingCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (selectedPitch_EditBookingWindow != null)
                {
                    selectedBooking.PITCH = selectedPitch_EditBookingWindow;
                }
                TimeSpan tempTime = Convert.ToDateTime(checkOutTime_EditBookingWindow) - Convert.ToDateTime(checkInTime_EditBookingWindow);
                double tempCost = Convert.ToDouble(tempTime.Ticks / 36000000000) * Convert.ToInt64(selectedBooking.PITCH.PITCH_TYPE.PRICE);
                usedCostPitch = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", tempCost);

                selectedBooking.CUSTOMER_NAME = customerName_EditBookingWindow;
                selectedBooking.CUSTOMER_PHONE_NUMBER = customerPhoneNumber_EditBookingWindow;
                selectedBooking.CHECK_IN_TIME = checkInTime_EditBookingWindow;
                selectedBooking.CHECK_OUT_TIME = checkOutTime_EditBookingWindow;
                selectedBooking.DATE_BOOKING = bookingDate_EditBookingWindow;
                selectedBooking.COST = tempCost.ToString();
                selectedBooking.USER1 = loggedInAccount;
                selectedBooking.UPDATE_AT = DateTime.UtcNow.AddHours(7);
                Confirm_EditBooking_Window confirmEditBooking_Window = new Confirm_EditBooking_Window();
                confirmEditBooking_Window.ShowDialog();
            });
            btnCheck_CheckOutTime_EditBookingWindow = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (checkOutTime_EditBookingWindow != null)
                {

                    if (checkInTimeFilter != null && checkOutTimeFilter != null)
                    {

                        int resultCheckOutTime_CheckOutTimeFilter = TimeSpan.Compare(Convert.ToDateTime(checkOutTimeFilter).TimeOfDay, Convert.ToDateTime(checkOutTime_EditBookingWindow).TimeOfDay);


                        TimeSpan resultCheckOutTime_checkInTime = Convert.ToDateTime(checkOutTime_EditBookingWindow) - Convert.ToDateTime(checkInTime_EditBookingWindow);

                        TimeSpan resultCheckOutTime_checkInTimeFilter = Convert.ToDateTime(checkOutTime_EditBookingWindow) - Convert.ToDateTime(checkInTimeFilter);



                        if (resultCheckOutTime_checkInTime.Ticks < 36000000000)
                        {
                            MessageBox.Show("Thời gian cho thuê tối thiểu sân là 1 tiếng", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                            isValidCheckOutTime = false;
                            isValidBothTime = isValidCheckInTime && isValidCheckOutTime;
                            return;
                        }
                        else if (resultCheckOutTime_checkInTimeFilter.Ticks < 36000000000)
                        {
                            MessageBox.Show("Thời gian checkOut không thể cách thời gian đã lọc trước 1 tiếng!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                            isValidCheckOutTime = false;
                            isValidBothTime = isValidCheckInTime && isValidCheckOutTime;
                            return;
                        }
                        else
                        {
                            if (resultCheckOutTime_CheckOutTimeFilter >= 0)
                            {
                                isValidCheckOutTime = true;
                                isValidBothTime = isValidCheckInTime && isValidCheckOutTime;
                                MessageBox.Show("Thời gian checkOut hợp lệ");
                            }
                            else
                            {
                                MessageBox.Show("Thời gian kết thúc thuê sân không thể nằm ngoài thời gian kết thúc đã lọc", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                                isValidCheckOutTime = false;
                                isValidBothTime = isValidCheckInTime && isValidCheckOutTime;
                                return;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn thời gian kết thúc thuê sân!");
                }

            });
            btnCheck_CheckInTime_EditBookingWindow = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (checkInTime_EditBookingWindow != null)
                {
                    if (checkInTimeFilter != null && checkOutTimeFilter != null)
                    {

                        TimeSpan checkInTime_checkOutTimeFilter = Convert.ToDateTime(checkOutTimeFilter) - Convert.ToDateTime(checkInTime_EditBookingWindow);

                        if (checkInTime_checkOutTimeFilter.Ticks < 36000000000)
                        {
                            MessageBox.Show("Thời gian bắt đầu không thể cách thời gian kết thúc đã lọc nhỏ hơn 1 tiếng!", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                            isValidCheckInTime = false;
                            isValidBothTime = isValidCheckInTime && isValidCheckOutTime;
                            return;
                        }

                        int resultCheckInTime_withCheckInTimeFilter = TimeSpan.Compare(Convert.ToDateTime(checkInTime_EditBookingWindow).TimeOfDay, Convert.ToDateTime(checkInTimeFilter).TimeOfDay);


                        int resultCheckInTime_withCheckOutTimeFilter = TimeSpan.Compare(Convert.ToDateTime(checkOutTimeFilter).TimeOfDay, Convert.ToDateTime(checkInTime_EditBookingWindow).TimeOfDay);



                        if (resultCheckInTime_withCheckInTimeFilter >= 0 && resultCheckInTime_withCheckOutTimeFilter >= 0)
                        {
                            isValidCheckInTime = true;
                            isValidBothTime = isValidCheckInTime && isValidCheckOutTime;
                            MessageBox.Show("Thời gian checkIn hợp lệ");
                        }
                        else
                        {
                            if (resultCheckInTime_withCheckInTimeFilter < 0)
                            {
                                MessageBox.Show("Thời gian checkIn không thể trước thời gian đã lọc!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                                isValidCheckInTime = false;
                                isValidBothTime = isValidCheckInTime && isValidCheckOutTime;
                                return;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn thời gian bắt đầu thuê sân!");
                }
            });
            btnQuit_EditWindow_Command = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    ClearData();
                    p.Close();
                }

            });
            btnFilterPitch_EditBooking_Window_Command = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {

                if (CheckAttributeFilter_EditBookingWindow() == false)
                {
                    ClearDataGrid();
                    return;
                }
                EditBooking_FilterPitchList();
            });
            #endregion

        }
        #region FUNCTION ADDNEWBOOKING WINDOW
        public void SetupDataBindingEnableBtn()
        {

            isValidCheckInTime = false;
            isValidCheckOutTime = false;
            isValidBothTime = false;
            isFilteredPitch = false;
        }
        public void SetUpDataPitchTypeCombobox()
        {
            //Setup datestart in Datepicker BookingDate
            todayDate = DateTime.Today;


            //Setup Data PITCH_TYPE in COMBOBOX PITCHTYPE
            PITCHTYPELISTCOMBOBOX = new ObservableCollection<string>();
            PitchType_Service pitchType_Service = new PitchType_Service();
            foreach (PITCH_TYPE pitchTypeTemp in pitchType_Service.GetListPitchType())
            {
                if (pitchTypeTemp.NAME_PITCH_TYPE == "Sân 5 người")
                {
                    double tempPrice = Convert.ToDouble(pitchTypeTemp.PRICE);
                    priceOf_5Pitch = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", tempPrice);
                }
                if (pitchTypeTemp.NAME_PITCH_TYPE == "Sân 7 người")
                {
                    double tempPrice = Convert.ToDouble(pitchTypeTemp.PRICE);
                    priceOf_7Pitch = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", tempPrice);
                }
                if (pitchTypeTemp.NAME_PITCH_TYPE == "Sân 11 người")
                {
                    double tempPrice = Convert.ToDouble(pitchTypeTemp.PRICE);
                    priceOf_11Pitch = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", tempPrice);
                }
                PITCHTYPELISTCOMBOBOX.Add(pitchTypeTemp.NAME_PITCH_TYPE);
            }
            //Setup Default Selected Item Combobox PitchTypeList
            selectedPitchType = "Sân 5 người";
        }

        public void SetUpDataPitchList()
        {
            //Setup Data PITCHLIST
            PitchService pitchService = new PitchService();
            PITCHLIST = new List<PITCH>();
            PITCHLIST = pitchService.GetListPitch();
        }

        // Filter PitchList base on Atribute
        public void FilterPitchList()
        {
            //Setup Data PITCHLISTWITHTYPE
            PitchService pitchService = new PitchService();
            PITCHLISTWITHTYPE = new List<PITCH>();
            PITCHLISTWITHTYPE = pitchService.GetListPitchByType(selectedPitchType);

            PITCHLISTBYFILTER = new ObservableCollection<PITCH>();

            BOOKINGLISTEXISTED = new List<BOOKING>();

            BookingService bookingService = new BookingService();
            BOOKINGLISTEXISTED = bookingService.GetListBookingByDateBooking(checkInTimeFilter, checkOutTimeFilter, bookingDate, selectedPitchType);

            foreach (var tempPitch in PITCHLISTWITHTYPE)
            {
                PITCHLISTBYFILTER.Add(tempPitch);
                foreach (var tempBooking in BOOKINGLISTEXISTED)
                {
                    if (tempPitch.ID_PITCH == tempBooking.ID_PITCH)
                    {
                        PITCHLISTBYFILTER.Remove(tempPitch);
                    }
                }
            }
        }


        public void DefaultAtrribute()
        {
            selectedPitch = null;
            customerName = "";
            customerPhoneNumber = "";
            checkInTime = null;
            checkOutTime = null;
            isValidCheckInTime = false;
            isValidCheckOutTime = false;
            isValidBothTime = false;
        }
        //Check data
        public bool CheckAttribute()
        {
            bool result = true;
            if (selectedPitch == null)
            {
                MessageBox.Show("Vui lòng chọn sân!");
                result = false;
                return result;
            }
            if (customerName == null)
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!"); result = false; return result;
            }
            if (customerPhoneNumber == null)
            {
                MessageBox.Show("Vui lòng nhập SDT khách hàng!"); result = false; return result;
            }
            if (customerPhoneNumber != null)
            {
                if (Regex.Match(customerPhoneNumber, @"(84|0[3|5|7|8|9])+([0-9]{8})\b").Success == false)
                {
                    MessageBox.Show("SĐT khách hàng không đúng, xin nhập lại!"); result = false; return result;
                }
            }
            if (checkInTime == null)
            {
                MessageBox.Show("Vui lòng chọn thời gian bắt đầu!"); result = false; return result;
            }
            if (checkOutTime == null)
            {
                MessageBox.Show("Vui lòng chọn thời gian kết thúc!"); result = false; return result;
            }

            return result;
        }

        //Check data atribute Filter

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
                MessageBox.Show("Thời gian kết thúc nhỏ hơn thời gian bắt đầu, vui lòng nhập lại!!!", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error); success = false; return success;
            }

            TimeSpan resultCheckTimeFilter_TimeSpan = Convert.ToDateTime(checkOutTimeFilter) - Convert.ToDateTime(checkInTimeFilter);

            if (resultCheckTimeFilter_TimeSpan.Ticks < 36000000000)
            {
                MessageBox.Show("Thời gian kết thúc phải cách thời gian bắt đầu hơn 1 tiếng, vui lòng nhập lại!!!", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error); success = false; return success;
            }
            return success;

        }

        //Defauult DataGrid
        public void ClearDataGrid()
        {
            PITCHLISTBYFILTER = new ObservableCollection<PITCH>();
        }

        //Defauult Data
        public void ClearData()
        {
            checkOutTimeFilter = null;
            checkInTimeFilter = "";
            bookingDate = "";
            selectedPitch = null;
            customerName = "";
            customerPhoneNumber = "";
            checkInTime = "";
            checkOutTime = "";
            SetupDataBindingEnableBtn();
            selectedPitchType = "Sân 5 người";
            PITCHLISTBYFILTER = new ObservableCollection<PITCH>();
        }
        #endregion

        #region EDITBOOKING_WINDOW FUNCTION
        //Check data atribute Filter

        public bool CheckAttributeFilter_EditBookingWindow()
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
            if (string.IsNullOrEmpty(bookingDate_EditBookingWindow))
            {
                MessageBox.Show("Vui lòng chọn ngày để lọc!"); success = false; return success;
            }

            int resultCheckTimeFilter = TimeSpan.Compare(Convert.ToDateTime(checkInTimeFilter).TimeOfDay, Convert.ToDateTime(checkOutTimeFilter).TimeOfDay);


            if (resultCheckTimeFilter >= 0)
            {
                MessageBox.Show("Thời gian kết thúc nhỏ hơn thời gian bắt đầu, vui lòng nhập lại!!!", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error); success = false; return success;
            }

            TimeSpan resultCheckTimeFilter_TimeSpan = Convert.ToDateTime(checkOutTimeFilter) - Convert.ToDateTime(checkInTimeFilter);

            if (resultCheckTimeFilter_TimeSpan.Ticks < 36000000000)
            {
                MessageBox.Show("Thời gian kết thúc phải cách thời gian bắt đầu hơn 1 tiếng, vui lòng nhập lại!!!", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error); success = false; return success;
            }
            return success;

        }
        public void SetUpDataEditBookingWindow()
        {
           
            BookingManage_Usercontrol bookingManage_Usercontrol = new BookingManage_Usercontrol();
            var bookingManage_Usercontrol_VM = bookingManage_Usercontrol.DataContext as BookingManage_Usercontrol_ViewModel;
            selectedBooking = bookingManage_Usercontrol_VM.selectedBooking;

            if (selectedBooking == null)
            {
                return;
            }

            selectedPitch_EditBookingWindow = selectedBooking.PITCH;
            customerName_EditBookingWindow = selectedBooking.CUSTOMER_NAME;
            customerPhoneNumber_EditBookingWindow = selectedBooking.CUSTOMER_PHONE_NUMBER;
            checkInTime_EditBookingWindow = selectedBooking.CHECK_IN_TIME;
            checkOutTime_EditBookingWindow = selectedBooking.CHECK_OUT_TIME;
            bookingDate_EditBookingWindow = selectedBooking.DATE_BOOKING;

            
        }

        // Filter PitchList base on Atribute
        public void EditBooking_FilterPitchList()
        {
            bool checkTime(string checkInTimeFilter, string checkOutTimeFilter, string checkInTimeDTB, string checkOutTimeDTB)
            {
                bool success = false;

                int resultCheckInTime = TimeSpan.Compare(Convert.ToDateTime(checkInTimeDTB).TimeOfDay, Convert.ToDateTime(checkInTimeFilter).TimeOfDay);

                int resultCheckOutTime = TimeSpan.Compare(Convert.ToDateTime(checkOutTimeFilter).TimeOfDay, Convert.ToDateTime(checkOutTimeDTB).TimeOfDay);

                if (resultCheckInTime >= 0 && resultCheckOutTime >= 0)
                {
                    success = true;
                }
                return success;

            }
            //Setup Data PITCHLISTWITHTYPE
            PitchService pitchService = new PitchService();
            PITCHLISTWITHTYPE = new List<PITCH>();
            PITCHLISTWITHTYPE = pitchService.GetListPitchByType(selectedPitchType);

            PITCHLISTBYFILTER = new ObservableCollection<PITCH>();

            BOOKINGLISTEXISTED = new List<BOOKING>();

            BookingService bookingService = new BookingService();
            BOOKINGLISTEXISTED = bookingService.GetListBookingByDateBooking(checkInTimeFilter, checkOutTimeFilter, bookingDate_EditBookingWindow, selectedPitchType);

            foreach (var tempPitch in PITCHLISTWITHTYPE)
            {
                PITCHLISTBYFILTER.Add(tempPitch);
            }    

            foreach(var tempBooking in BOOKINGLISTEXISTED)
            {


                if (PITCHLISTWITHTYPE.Where(x=>x.ID_PITCH == tempBooking.ID_PITCH).FirstOrDefault() != null && checkTime(checkInTimeFilter, checkOutTimeFilter,tempBooking.CHECK_IN_TIME, tempBooking.CHECK_OUT_TIME))
                {
                    PITCH tempPitch = new PITCH();
                    tempPitch = PITCHLISTWITHTYPE.Where(x => x.ID_PITCH == tempBooking.ID_PITCH).FirstOrDefault();
                    PITCHLISTBYFILTER.Remove(tempPitch);
                }


                if (tempBooking.ID_PITCH == selectedBooking.ID_PITCH && checkTime(checkInTimeFilter, checkOutTimeFilter, tempBooking.CHECK_IN_TIME, tempBooking.CHECK_OUT_TIME))
                {
                    PITCH tempPitch = new PITCH();
                    tempPitch = PITCHLISTWITHTYPE.Where(x => x.ID_PITCH == tempBooking.ID_PITCH).FirstOrDefault();
                    PITCHLISTBYFILTER.Add(tempPitch);
                }
            }    

            //foreach (var tempPitch in PITCHLISTWITHTYPE)
            //{
            //    PITCHLISTBYFILTER.Add(tempPitch);

            //    foreach (var tempbooking in bookinglistexisted)
            //    {
            //        if (tempbooking.id_pitch == selectedbooking.id_pitch && checktime(checkintimefilter, checkouttimefilter, checkintime_editbookingwindow, checkouttime_editbookingwindow) == true)
            //        {
            //            continue;
            //        }

            //        if (temppitch.id_pitch == tempbooking.id_pitch && checktime(checkintimefilter, checkouttimefilter, checkintime_editbookingwindow, checkouttime_editbookingwindow) == true)
            //        {
            //            pitchlistbyfilter.remove(temppitch);
            //        }
            //    }
            //}
        }
        #endregion
    }
}
