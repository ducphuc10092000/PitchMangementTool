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
    public class AddNewPitch_Window_ViewModel : BaseViewModel
    {
        //Logged Account
        private USER _loggedInAccount;
        public USER loggedInAccount { get => _loggedInAccount; set { _loggedInAccount = value; OnPropertyChanged(); } }
        //Combobox PITCHTYPE
        private ObservableCollection<string> _PITCHTYPELISTCOMBOBOX;
        public ObservableCollection<string> PITCHTYPELISTCOMBOBOX { get => _PITCHTYPELISTCOMBOBOX; set { _PITCHTYPELISTCOMBOBOX = value; OnPropertyChanged(); } }


        //Selected item in combobox binding
        private string _selectedPitchType;
        public string selectedPitchType { get => _selectedPitchType; set { _selectedPitchType = value; OnPropertyChanged(nameof(selectedPitchType)); } }


        //Binding enable and parameter the textbox linkPitch base on combobox pitchtypelist
        public bool _isEnableLinkPitch1;
        public bool isEnableLinkPitch1 { get => _isEnableLinkPitch1; set { _isEnableLinkPitch1 = value; OnPropertyChanged(nameof(isEnableLinkPitch1)); } }

        public bool _isEnableLinkPitch2;
        public bool isEnableLinkPitch2 { get => _isEnableLinkPitch2; set { _isEnableLinkPitch2 = value; OnPropertyChanged(nameof(isEnableLinkPitch2)); } }

        public bool _isEnableLinkPitch3;
        public bool isEnableLinkPitch3 { get => _isEnableLinkPitch3; set { _isEnableLinkPitch3 = value; OnPropertyChanged(nameof(isEnableLinkPitch3)); } }

        private PITCH _pitchLink1;
        public PITCH pitchLink1 { get => _pitchLink1; set { _pitchLink1 = value; OnPropertyChanged(nameof(pitchLink1)); } }
        private PITCH _pitchLink2;
        public PITCH pitchLink2 { get => _pitchLink2; set { _pitchLink2 = value; OnPropertyChanged(nameof(pitchLink2)); } }
        private PITCH _pitchLink3;
        public PITCH pitchLink3 { get => _pitchLink3; set { _pitchLink3 = value; OnPropertyChanged(nameof(pitchLink3)); } }

        private ObservableCollection<PITCH> _PITCHLINKEDLIST;
        public ObservableCollection<PITCH> PITCHLINKEDLIST { get => _PITCHLINKEDLIST; set { _PITCHLINKEDLIST = value; OnPropertyChanged(); } }




        //Field to type input
        private string _pitchName;
        public string pitchName { get => _pitchName; set { _pitchName = value; OnPropertyChanged(); } }

        public ICommand btnDefaultAttributeCommand { get; set; }
        public ICommand btnAddNewPitchCommand { get; set; }
        public ICommand btnQuitCommand { get; set; }
        public ICommand PitchTypeListChangedCommand { get; set; }
        public ICommand OpenListPitchLinkCommand_1 { get; set; }
        public ICommand OpenListPitchLinkCommand_2 { get; set; }
        public ICommand OpenListPitchLinkCommand_3 { get; set; }
        public AddNewPitch_Window_ViewModel()
        {
            //Setup default (null or empty field when open window)
            DefaultField();



            PITCHLINKEDLIST = new ObservableCollection<PITCH>();

            PitchService pitchService = new PitchService();
            PitchType_Service pitchTypeService = new PitchType_Service();
            SetupPitchTypeListCombobox();

            btnAddNewPitchCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {


                PITCH newPitch = new PITCH();
                if(string.IsNullOrEmpty(pitchName))
                {
                    MessageBox.Show("Không thể để trống tên sân!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }    
                else
                {
                    if (string.IsNullOrEmpty(selectedPitchType))
                    {
                        MessageBox.Show("Vui lòng chọn loại sân", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    if (selectedPitchType == "Sân 5 người")
                    {
                        newPitch.NAME_PITCH = pitchName;
                        newPitch.CREATE_BY_ID_USER = loggedInAccount.ID;
                        newPitch.CREATE_AT = DateTime.Now.ToLocalTime();
                        newPitch.PITCH_TYPE_ID = pitchTypeService.GetPitchTypeByName(selectedPitchType).ID_PITCH_TYPE;
                        newPitch.PITCH_TYPE = pitchTypeService.GetPitchTypeByName(selectedPitchType);

                    }
                    if (selectedPitchType == "Sân 7 người")
                    {
                        newPitch.NAME_PITCH = pitchName;
                        newPitch.CREATE_BY_ID_USER = loggedInAccount.ID;
                        newPitch.CREATE_AT = DateTime.Now.ToLocalTime();
                        newPitch.PITCH_TYPE_ID = pitchTypeService.GetPitchTypeByName(selectedPitchType).ID_PITCH_TYPE;
                        newPitch.PITCH_TYPE = pitchTypeService.GetPitchTypeByName(selectedPitchType);
                    }
                    if (selectedPitchType == "Sân 11 người")
                    {
                        newPitch.NAME_PITCH = pitchName;
                        newPitch.CREATE_BY_ID_USER = loggedInAccount.ID;
                        newPitch.CREATE_AT = DateTime.Now.ToLocalTime();
                        newPitch.PITCH_TYPE_ID = pitchTypeService.GetPitchTypeByName(selectedPitchType).ID_PITCH_TYPE;
                        newPitch.PITCH_TYPE = pitchTypeService.GetPitchTypeByName(selectedPitchType);
                    }

                    if (pitchService.ExistedPitch(newPitch) == true)
                    {
                        MessageBox.Show("Tên sân đã tồn tại, hãy nhập lại tên sân", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    if (pitchService.AddNewPitch(newPitch, PITCHLINKEDLIST) == true)
                    {
                        MessageBox.Show("Thêm mới sân bóng thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                DefaultField(); 
                p.Close();
            });
            PitchTypeListChangedCommand = new RelayCommand<ComboBox>((p) =>
            { return p == null ? false : true; }, (p) =>
            {
                selectedPitchType = p.SelectedItem.ToString();


                if (p.SelectedItem.ToString() == "Sân 5 người")
                {
                    isEnableLinkPitch1 = false;
                    isEnableLinkPitch2 = false;
                    isEnableLinkPitch3 = false;

                }
                if (p.SelectedItem.ToString() == "Sân 7 người")
                {
                    isEnableLinkPitch1 = true;
                    isEnableLinkPitch2 = true;
                    isEnableLinkPitch3 = true;
                }
                if (p.SelectedItem.ToString() == "Sân 11 người")
                {
                    isEnableLinkPitch1 = true;
                    isEnableLinkPitch2 = true;
                    isEnableLinkPitch3 = false;
                }
            });

            OpenListPitchLinkCommand_1 = new RelayCommand<TextBox>((p) =>
            { return  true; }, (p) =>
            {
                PitchLinkList_Window pitchLinklist_Window = new PitchLinkList_Window();
                var pitchLinkList_WD_VM = pitchLinklist_Window.DataContext as PitchManage_Usercontrol_ViewModel;
                pitchLinkList_WD_VM.LoadDataPitchLinkListWindow(selectedPitchType, PITCHLINKEDLIST);

                pitchLinklist_Window.ShowDialog();


                if (pitchLinkList_WD_VM.selectedPitch == null)
                {
                    return;
                }    
                else
                {
                    if (pitchLink1 != null)
                    {
                        PITCHLINKEDLIST.Remove(pitchLink1);
                    }
                    pitchLink1 = pitchLinkList_WD_VM.selectedPitch;
                    PITCHLINKEDLIST.Add(pitchLink1);
                }    
            });
            OpenListPitchLinkCommand_2 = new RelayCommand<TextBox>((p) =>
            { return true; }, (p) =>
            {
                PitchLinkList_Window pitchLinklist_Window = new PitchLinkList_Window();
                var pitchLinkList_WD_VM = pitchLinklist_Window.DataContext as PitchManage_Usercontrol_ViewModel;
                pitchLinkList_WD_VM.LoadDataPitchLinkListWindow(selectedPitchType, PITCHLINKEDLIST);

                pitchLinklist_Window.ShowDialog();


                if (pitchLinkList_WD_VM.selectedPitch == null)
                {
                    return;
                }
                else
                {
                    if (pitchLink2 != null)
                    {
                        PITCHLINKEDLIST.Remove(pitchLink2);
                    }
                    pitchLink2 = pitchLinkList_WD_VM.selectedPitch;
                    PITCHLINKEDLIST.Add(pitchLink2);
                }
            });
            OpenListPitchLinkCommand_3 = new RelayCommand<TextBox>((p) =>
            { return true; }, (p) =>
            {
                PitchLinkList_Window pitchLinklist_Window = new PitchLinkList_Window();
                var pitchLinkList_WD_VM = pitchLinklist_Window.DataContext as PitchManage_Usercontrol_ViewModel;
                pitchLinkList_WD_VM.LoadDataPitchLinkListWindow(selectedPitchType, PITCHLINKEDLIST);

                pitchLinklist_Window.ShowDialog();


                if (pitchLinkList_WD_VM.selectedPitch == null)
                {
                    return;
                }
                else
                {
                    if (pitchLink3 != null)
                    {
                        PITCHLINKEDLIST.Remove(pitchLink3);
                    }
                    pitchLink3 = pitchLinkList_WD_VM.selectedPitch;
                    PITCHLINKEDLIST.Add(pitchLink3);
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
                    DefaultField();
                    p.Close();
                }

            });

            btnDefaultAttributeCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                DefaultField();
            });


        }


        //Setup Data PITCH_TYPE in COMBOBOX PITCHTYPE
        public void SetupPitchTypeListCombobox()
        {
            PITCHTYPELISTCOMBOBOX = new ObservableCollection<string>();
            PitchType_Service pitchType_Service = new PitchType_Service();
            foreach (PITCH_TYPE pitchTypeTemp in pitchType_Service.GetListPitchType())
            {
                PITCHTYPELISTCOMBOBOX.Add(pitchTypeTemp.NAME_PITCH_TYPE);
            }
        }

        //Setup Data LINK_PITCH in 3 - COMBOBOX LINK 
        public void DefaultField()
        {
            pitchName = "";
            selectedPitchType = "";
            pitchLink1 = null;
            pitchLink2 = null;
            pitchLink3 = null;
        }
    }
}
