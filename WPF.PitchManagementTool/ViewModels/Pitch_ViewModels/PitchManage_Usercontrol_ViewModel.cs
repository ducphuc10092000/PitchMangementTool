using Domain.PitchManagementTool;
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
using WPF.PitchManagementTool.Views.Pitch_Views;

namespace WPF.PitchManagementTool.ViewModels.Pitch_ViewModels
{
    public class PitchManage_Usercontrol_ViewModel : BaseViewModel
    {
        #region BINDING PITCH_LINK_LIST_WINDOW

        private PITCH _selectedPitch;
        public PITCH selectedPitch { get => _selectedPitch; set { _selectedPitch = value; OnPropertyChanged(); } }

        private ObservableCollection<PITCH> _PITCHLINKLIST;
        public ObservableCollection<PITCH> PITCHLINKLIST { get => _PITCHLINKLIST; set { _PITCHLINKLIST = value; OnPropertyChanged(); } }

        #region COMMAND
        public ICommand btnSelectedPitchLinkCommand { get; set; }
        #endregion

        #endregion


        #region BINDING PITCH_MANAGE_USERCONTROL
        //Logged Account
        private USER _loggedInAccount;
        public USER loggedInAccount { get => _loggedInAccount; set { _loggedInAccount = value; OnPropertyChanged(); } }


        // Combobox
        private ObservableCollection<string> _PITCHTYPELISTCOMBOBOX;
        public ObservableCollection<string> PITCHTYPELISTCOMBOBOX { get => _PITCHTYPELISTCOMBOBOX; set { _PITCHTYPELISTCOMBOBOX = value; OnPropertyChanged(); } }

        private ObservableCollection<PITCH> _PITCHLIST;
        public ObservableCollection<PITCH> PITCHLIST { get => _PITCHLIST; set { _PITCHLIST = value; OnPropertyChanged(); } }

        private ObservableCollection<PITCH> _PITCHLISTBYFILTER;
        public ObservableCollection<PITCH> PITCHLISTBYFILTER { get => _PITCHLISTBYFILTER; set { _PITCHLISTBYFILTER = value; OnPropertyChanged(); } }


        //Selected Pitch_Type To FILTER
        private string _selectedNamePitchType;
        public string selectedNamePitchType { get => _selectedNamePitchType; set { _selectedNamePitchType = value; OnPropertyChanged(); } }


        #region COMMAND INPUT BY USER

        public ICommand btnAddNewPitchCommand { get; set; }
        public ICommand MouseDoubleClickOnPitchCommand { get; set; }
        public ICommand btnFilterPitchBaseTypeCommand { get; set; }

        public ICommand btnDetailPitchCommand { get; set; }
        public ICommand btnBookingPitchCommand { get; set; }

        public ICommand PitchTypeListChangedCommand { get; set; }
        #endregion
        #endregion


        public PitchManage_Usercontrol_ViewModel()
        {
            SetUpDataPitchTypeCombobox();
            SetUpDataPitchList();
            #region HANDLE COMMAND PITCHMANAGE_USERCONTROL

            btnAddNewPitchCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                AddNewPitch_Window addNewPitch_Window = new AddNewPitch_Window();
                var addNewPitch_WD_VM = addNewPitch_Window.DataContext as AddNewPitch_Window_ViewModel;
                addNewPitch_WD_VM.loggedInAccount = loggedInAccount;
                addNewPitch_Window.ShowDialog();

                SetUpDataPitchList();
            });
            MouseDoubleClickOnPitchCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                AddNewPitch_Window addNewPitch_Window = new AddNewPitch_Window();
                addNewPitch_Window.ShowDialog();
            });
            btnFilterPitchBaseTypeCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                FilterPitchList();
            });
            btnDetailPitchCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                MessageBox.Show(p.ToString());
            });
            btnBookingPitchCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                MessageBox.Show(p.ToString());
            });

            PitchTypeListChangedCommand = new RelayCommand<ComboBox>((p) =>
            { return p == null ? false : true; }, (p) =>
            {
                selectedNamePitchType = p.SelectedItem.ToString();
            });
            #endregion


            #region HANDLE COMMAND PITCHLINKLIST_WINDOW
            btnSelectedPitchLinkCommand = new RelayCommand<PitchLinkList_Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                if(selectedPitch == null)
                {
                    return;
                }    
                else
                {
                    p.Close();
                }    
            });
            #endregion
        }


        #region FUNCTION SETUP AND HANDLE ON PITCHMANAGE_USERCONTROL

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

        #region FUNCTION SETUP AND HANDLE ON PITCHLINKLIST_WINDOW
        public void LoadDataPitchLinkListWindow(string selectedTypeOfNewPitch, ObservableCollection<PITCH> pitchLinkList)
        {
            
            PITCHLINKLIST = new ObservableCollection<PITCH>();
            if (selectedTypeOfNewPitch == "Sân 7 người")
            {
                foreach(var item in PITCHLIST)
                {
                    if(item.PITCH_TYPE.NAME_PITCH_TYPE == "Sân 5 người" && item.IS_CHILDREN == false)
                    {
                        PITCHLINKLIST.Add(item);
                    }    
                }

                //Remove selectedPitch
                if (pitchLinkList != null)
                {
                    foreach (var item in pitchLinkList)
                    {
                        PITCHLINKLIST.Remove(item);
                    }
                }

                return;
            }

            if (selectedTypeOfNewPitch == "Sân 11 người")
            {
                foreach (var item in PITCHLIST)
                {
                    if (item.PITCH_TYPE.NAME_PITCH_TYPE == "Sân 7 người" && item.IS_CHILDREN == false)
                    {
                        PITCHLINKLIST.Add(item);
                    }
                }
                //Remove selectedPitch
                if (pitchLinkList != null)
                {
                    foreach (var item in pitchLinkList)
                    {
                        PITCHLINKLIST.Remove(item);
                    }
                }
                return;
            }     
        }
        #endregion
    }
}
