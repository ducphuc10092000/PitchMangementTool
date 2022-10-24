using Domain.PitchManagementTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.PitchManagementTool.ViewModels.Account_ViewModels
{
    public class AccountManage_Usercontrol_ViewModel :BaseViewModel
    {
        private int _isAdmin;
        public int isAdmin { get => _isAdmin; set { _isAdmin = value; OnPropertyChanged(); } }

        private USER _loggedInAccount;
        public USER loggedInAccount { get => _loggedInAccount; set { _loggedInAccount = value; OnPropertyChanged(); } }

        public AccountManage_Usercontrol_ViewModel()
        {

        }    

        public void CheckRole(USER loggedInAccountCheck)
        {
            if(loggedInAccount.USER_ROLES.ROLE_NAME == "admin" || loggedInAccount.USER_ROLES.ROLE_NAME == "manager")
            {
                isAdmin = 1;
            }    
            else
            {
                isAdmin = 0;
            }    
        }
    }
}
