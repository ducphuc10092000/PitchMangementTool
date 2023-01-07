using Domain.PitchManagementTool;
using Domain.PitchManagementTool.Services.Pitch_Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF.PitchManagementTool.Views.Booking_Views;

namespace WPF.PitchManagementTool.ViewModels.Booking_ViewModels
{
    public class AddNewBookingPitch_Window_Viewmodel : BaseViewModel
    {
        //Logged Account
        private USER _loggedInAccount;
        public USER loggedInAccount { get => _loggedInAccount; set { _loggedInAccount = value; OnPropertyChanged(); } }

        #region BINDING LIST PITCH FOR BOOKING
        //Selected item in combobox PitchType
        private string _selectedPitchType;
        public string selectedPitchType { get => _selectedPitchType; set { _selectedPitchType = value; OnPropertyChanged(nameof(selectedPitchType)); } }

        //Selected Pitch_Type To FILTER
        private string _selectedNamePitchType;
        public string selectedNamePitchType { get => _selectedNamePitchType; set { _selectedNamePitchType = value; OnPropertyChanged(); } }

        //Combobox PITCHTYPE
        private ObservableCollection<string> _PITCHTYPELISTCOMBOBOX;
        public ObservableCollection<string> PITCHTYPELISTCOMBOBOX { get => _PITCHTYPELISTCOMBOBOX; set { _PITCHTYPELISTCOMBOBOX = value; OnPropertyChanged(); } }

        // LISTPITCH
        private ObservableCollection<PITCH> _PITCHLIST;
        public ObservableCollection<PITCH> PITCHLIST { get => _PITCHLIST; set { _PITCHLIST = value; OnPropertyChanged(); } }

        //LISTPITCH FILTERED
        private ObservableCollection<PITCH> _PITCHLISTBYFILTER;
        public ObservableCollection<PITCH> PITCHLISTBYFILTER { get => _PITCHLISTBYFILTER; set { _PITCHLISTBYFILTER = value; OnPropertyChanged(); } }

        #region COMMAND IN LISTBOOKINGPITCH WINDOW
        public ICommand MouseDoubleClickOnPitchCommand { get; set; }
        public ICommand btnFilterPitchBaseTypeCommand { get; set; }
        public ICommand btnSelectedPitchCommand { get; set; }

        #endregion
        #endregion

        #region BINDING TEXT & ELEMENT

        #endregion
        #region COMMAND
        public ICommand OpenPitchListCommand { get; set; }
        #endregion

        public AddNewBookingPitch_Window_Viewmodel()
        {
            SetUpDataPitchList();
            SetUpDataPitchTypeCombobox();
            OpenPitchListCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                ListBookingPitch_Window ListBookingPitch_Window = new ListBookingPitch_Window();
                ListBookingPitch_Window.ShowDialog();
            });
        }

        #region FUNCTION in ListBookingPitch_Window
        public void SetUpDataPitchList()
        {
            //Setup Data PITCHLIST
            PitchService pitchService = new PitchService();
            PITCHLIST = new ObservableCollection<PITCH>();
            foreach (var pitchItem in pitchService.GetListPitch())
            {
                PITCHLIST.Add(pitchItem);
            }
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
            selectedNamePitchType = "Sân 5 người";
        }
        public void FilterPitchList()
        {
            PITCHLISTBYFILTER = new ObservableCollection<PITCH>();
            foreach (var item in PITCHLIST)
            {
                if (item.PITCH_TYPE.NAME_PITCH_TYPE == selectedNamePitchType)
                {
                    PITCHLISTBYFILTER.Add(item);
                }
            }
        }
        #endregion
    }
}
