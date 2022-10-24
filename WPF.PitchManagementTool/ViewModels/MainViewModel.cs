using Domain.PitchManagementTool;
using Domain.PitchManagementTool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF.PitchManagementTool.ViewModels.Account_ViewModels;
using WPF.PitchManagementTool.ViewModels.Login_ViewModels;
using WPF.PitchManagementTool.ViewModels.Pitch_ViewModels;
using WPF.PitchManagementTool.Views.Account_Views;
using WPF.PitchManagementTool.Views.Login_Views;
using WPF.PitchManagementTool.Views.Pitch_Views;

namespace WPF.PitchManagementTool.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Account Logged in system

        public ICommand LoadedWindowCommand { get; set; }

        private USER _loggedInAccount;
        public USER loggedInAccount { get => _loggedInAccount; set { _loggedInAccount = value; OnPropertyChanged(); } }

        private bool _isLoaded;
        public bool IsLoaded { get => _isLoaded; set { _isLoaded = value; OnPropertyChanged(); } }

        #endregion


        #region Chức năng Button chuyển UC - Navigation
        public enum FEATURE
        {
            DashBoard, PitchManage, Booking, PrintingReceipt, InventoryManage, DebtManage, Setting, AccountManage
        }
        private int _Feature;
        public int Feature { get => _Feature; set { _Feature = value; OnPropertyChanged(); } }
        #endregion


        #region Declare Binding Command
        public ICommand BtnDashBoardCommand { get; set; }
        public ICommand BtnPitchManageCommand { get; set; }
        public ICommand BtnBookingCommand { get; set; }
        public ICommand BtnPrintingReceiptCommand { get; set; }
        public ICommand BtnInventoryManageCommand { get; set; }
        public ICommand BtnDebtManageCommand { get; set; }
        public ICommand BtnSettingCommand { get; set; }
        public ICommand BtnAccountManageCommand { get; set; }
        #endregion

        public MainViewModel()
        {
            #region Load Login Window
            LoadedWindowCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                //Add New An USER
                //UserService userService = new UserService();
                //USER usernew = new USER();
                //usernew.USERNAME = "admin";
                //usernew.PASSWORD = "admin";
                //usernew.ID_ROLE_NAME = 1;
                //usernew.FULL_NAME = "Nguyễn Đức Phúc";

                //AuthenticationService authenticationService = new AuthenticationService();
                //authenticationService.Register(usernew.USERNAME, usernew.PASSWORD, usernew);


                p.Hide();
                Login_Window loginWindow = new Login_Window();
                loginWindow.ShowDialog();
                var login_WD_VM = loginWindow.DataContext as Login_Window_ViewModel;
                loggedInAccount = login_WD_VM.Authentication_Login(loginWindow);
                p.Show();

                if (login_WD_VM.isCloseLoginWD == true)
                {
                    p.Close();
                }
            });
            #endregion

            #region Handle Binding Command Swap UserControl
            BtnDashBoardCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                Feature = (int)FEATURE.DashBoard;
            });
            BtnPitchManageCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                Feature = (int)FEATURE.PitchManage;

                PitchManage_Usercontrol pitchManage_UC = new PitchManage_Usercontrol();
                var pitchManage_UC_VM = pitchManage_UC.DataContext as PitchManage_Usercontrol_ViewModel;
                pitchManage_UC_VM.loggedInAccount = loggedInAccount;
            });

            BtnBookingCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                Feature = (int)FEATURE.Booking;
            });
            BtnPrintingReceiptCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                Feature = (int)FEATURE.PrintingReceipt;
            });
            BtnInventoryManageCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                Feature = (int)FEATURE.InventoryManage;
            });
            BtnDebtManageCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                Feature = (int)FEATURE.DebtManage;
            });
            BtnSettingCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                Feature = (int)FEATURE.Setting;
            });
            BtnAccountManageCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                Feature = (int)FEATURE.AccountManage;

                AccountManage_Usercontrol accountManage_UC = new AccountManage_Usercontrol();
                var acountManage_UC_VM = accountManage_UC.DataContext as AccountManage_Usercontrol_ViewModel;
                acountManage_UC_VM.loggedInAccount = loggedInAccount;
                acountManage_UC_VM.CheckRole(loggedInAccount);
            });
            #endregion
        }
    }
}
