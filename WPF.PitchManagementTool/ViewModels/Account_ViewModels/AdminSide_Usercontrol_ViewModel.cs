using Domain.PitchManagementTool;
using Domain.PitchManagementTool.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.PitchManagementTool.ViewModels.Account_ViewModels
{
    public class AdminSide_Usercontrol_ViewModel : BaseViewModel
    {
        private USER _loggedInAccount;
        public USER loggedInAccount { get => _loggedInAccount; set { _loggedInAccount = value; OnPropertyChanged(); } }

        private ObservableCollection<USER> _USERLIST;
        public ObservableCollection<USER> USERLIST { get => _USERLIST; set { _USERLIST = value; OnPropertyChanged(); } }

        public AdminSide_Usercontrol_ViewModel()
        {
            LoadListUser();
        }


        public void LoadListUser()
        {
            UserService userService = new UserService();
            USERLIST = new ObservableCollection<USER>();
            foreach (var user in userService.GetListUsers())
            {
                USERLIST.Add(user);
            }    
        }
    }
}
