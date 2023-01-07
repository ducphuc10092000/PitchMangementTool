using Domain.PitchManagementTool;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.PitchManagementTool.ViewModels.Pitch_ViewModels
{
    public class DetailsPitch_Window_ViewModel : BaseViewModel
    {
        //Logged Account
        private USER _loggedInAccount;
        public USER loggedInAccount { get => _loggedInAccount; set { _loggedInAccount = value; OnPropertyChanged(); } }


        //PITCH
        private PITCH _pitch;
        public PITCH pitch { get => _pitch; set { _pitch = value; OnPropertyChanged(nameof(_pitch)); } }


        //PITCH LINK
        private PITCH _pitchLink1;
        public PITCH pitchLink1 { get => _pitchLink1; set { _pitchLink1 = value; OnPropertyChanged(nameof(pitchLink1)); } }
        private PITCH _pitchLink2;
        public PITCH pitchLink2 { get => _pitchLink2; set { _pitchLink2 = value; OnPropertyChanged(nameof(pitchLink2)); } }
        private PITCH _pitchLink3;
        public PITCH pitchLink3 { get => _pitchLink3; set { _pitchLink3 = value; OnPropertyChanged(nameof(pitchLink3)); } }

        //PITCHLINK LIST
        private ObservableCollection<PITCH> _PITCHLINKEDLIST;
        public ObservableCollection<PITCH> PITCHLINKEDLIST { get => _PITCHLINKEDLIST; set { _PITCHLINKEDLIST = value; OnPropertyChanged(); } }

        //Field to type input
        private string _pitchName;
        public string pitchName { get => _pitchName; set { _pitchName = value; OnPropertyChanged(); } }

        public DetailsPitch_Window_ViewModel()
        {

        }
    }
}
