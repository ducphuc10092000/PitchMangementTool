using Domain.PitchManagementTool;
using Domain.PitchManagementTool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF.PitchManagementTool.Views.Login_Views;

namespace WPF.PitchManagementTool.ViewModels.Login_ViewModels
{
    public class Login_Window_ViewModel : BaseViewModel
    {
        private string _userName;
        public string userName { get => _userName; set { _userName = value; OnPropertyChanged(nameof(userName)); } }

        public string _passWord;
        public string passWord { get => _passWord; set { _passWord = value; OnPropertyChanged(nameof(passWord)); } }


        private USER _loggedInAccount;
        public USER loggedInAccount { get => _loggedInAccount; set { _loggedInAccount = value; OnPropertyChanged(); } }


        public bool _isCloseLoginWD;
        public bool isCloseLoginWD { get => _isCloseLoginWD; set { _isCloseLoginWD = value; OnPropertyChanged(nameof(isCloseLoginWD)); } }

        #region Command
        public ICommand btnLoginCommand { get; set; }

        public ICommand btnQuitCommand { get; set; }

        public ICommand PasswordChangedCommand { get; set; }
        #endregion
        public Login_Window_ViewModel()
        {
            isCloseLoginWD = false;
            Load_login_WD();

            #region Handling command button

            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) =>
            { return p == null ? false : true; }, (p) =>
            {
                passWord = p.Password;
            });

            btnLoginCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(passWord))
                {
                    MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                else if (string.IsNullOrEmpty(userName))
                {
                    MessageBox.Show("Tên đăng nhập không được để trống!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                else if (string.IsNullOrEmpty(passWord))
                {
                    MessageBox.Show("Mật khẩu không được để trống!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                else
                {
                    if (Authentication_Login(p) != null)
                    {
                        isCloseLoginWD = true;
                    }    
                }
            });

            btnQuitCommand = new RelayCommand<Login_Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                    p.Close();
                    isCloseLoginWD = true;
            });
            #endregion
        }
        public void Load_login_WD()
        {
            userName = "";
            passWord = "";
        }
        public USER Authentication_Login(Window login_WD)
        {
            UserService userService = new UserService();


            AuthenticationService authenticationService = new AuthenticationService();

            if (authenticationService.Login(userName, passWord) != null)
            {
                login_WD.Hide();
                login_WD.Close();
                return authenticationService.Login(userName, passWord);
            }

            if (authenticationService.Login(userName, passWord) == null && string.IsNullOrEmpty(userName) == false && string.IsNullOrEmpty(passWord) == false)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng, xin nhập lại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }

            return null;
        }
    }
}
