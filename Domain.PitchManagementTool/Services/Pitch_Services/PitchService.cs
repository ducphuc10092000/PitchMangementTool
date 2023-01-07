using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PitchManagementTool.Services.Pitch_Services
{
    public class PitchService
    {
        public PitchService()
        {

        }

        public List<PITCH> GetListPitchByType(string pitchType)
        {
            return DataProvider.Ins.DB.PITCHes.Where(x=>x.PITCH_TYPE.NAME_PITCH_TYPE == pitchType).ToList();
        }


        public List<PITCH> GetListPitch()
        {
            return DataProvider.Ins.DB.PITCHes.Where(pitch=>true).ToList();
        }

        public PITCH GetPitchByID(int idPitch)
        {
            if(DataProvider.Ins.DB.PITCHes.Where(x => x.ID_PITCH == idPitch).FirstOrDefault() == null)
            {
                return null;
            }    
            else
            {
                return DataProvider.Ins.DB.PITCHes.Where(x => x.ID_PITCH == idPitch).FirstOrDefault();
            }    
        }

        public PITCH GetPitchByName(string namePitch)
        {
            if (DataProvider.Ins.DB.PITCHes.Where(x => x.NAME_PITCH == namePitch).FirstOrDefault() == null)
            {
                return null;
            }
            else
            {
                return DataProvider.Ins.DB.PITCHes.Where(x => x.NAME_PITCH == namePitch).FirstOrDefault();
            }
        }

        public bool ExistedPitch(PITCH newpitch)
        {
            bool isExisted = true; 
            if(DataProvider.Ins.DB.PITCHes.Where(x=>x.NAME_PITCH == newpitch.NAME_PITCH).FirstOrDefault() != null)
            {
                return isExisted;
            }    
            else
            {
                isExisted = false;
                return isExisted;
            }    
        }
        public bool AddNewPitch(PITCH newPitch, ObservableCollection<PITCH> pitchLinkedList)
        {

            bool success = false;
            if(newPitch != null)
            {
                if(newPitch.PITCH_TYPE.NAME_PITCH_TYPE == "Sân 5 người")
                {
                    DataProvider.Ins.DB.PITCHes.Add(newPitch);
                    DataProvider.Ins.DB.SaveChanges();
                }
                else
                {
                    //Add new PITCH
                    DataProvider.Ins.DB.PITCHes.Add(newPitch);
                    DataProvider.Ins.DB.SaveChanges();

                    //Add Details
                    LinkPitchDetail_Service linkPitchDetail_Service = new LinkPitchDetail_Service();
                    linkPitchDetail_Service.AddNewLinkPitchDetail(newPitch, pitchLinkedList);
                }    

                success = true;
            }    
            return success;
        }
        public bool UpdatePitch(PITCH newPitch)
        {
            bool success = false;

            if (newPitch != null)
            {
                PITCH tempPitch = DataProvider.Ins.DB.PITCHes.Where(x => x.ID_PITCH == newPitch.ID_PITCH).FirstOrDefault();
                tempPitch = newPitch;
                DataProvider.Ins.DB.SaveChanges();
                success = true;
            }
            return success;
        }
        public bool DeletedPitch(PITCH newPitch)
        {
            bool success = false;


            return success;
        }
    }
}
