using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PitchManagementTool.Services.Pitch_Services
{
    public class PitchType_Service
    {
        public PitchType_Service()
        {

        }

        public List<PITCH_TYPE> GetListPitchType()
        {
            return DataProvider.Ins.DB.PITCH_TYPE.ToList();
        }

        public PITCH_TYPE GetPitchTypeByName(string namePitchType)
        {
            return DataProvider.Ins.DB.PITCH_TYPE.Where(x => x.NAME_PITCH_TYPE == namePitchType).FirstOrDefault();
        }
        public bool AddPitchType(PITCH_TYPE pitchType)
        {
            bool success = false;
            if(DataProvider.Ins.DB.PITCH_TYPE.Where(x=>x.NAME_PITCH_TYPE == pitchType.NAME_PITCH_TYPE).FirstOrDefault() != null)
            {
                return success;
            }    
            else
            {
                DataProvider.Ins.DB.PITCH_TYPE.Add(pitchType);
                DataProvider.Ins.DB.SaveChanges();
                success = true;
            }    
            return success;
        }
        public bool UpdatePitchType(PITCH_TYPE pitchType)
        {
            bool success = false;

            if(DataProvider.Ins.DB.PITCH_TYPE.Where(x=>x.NAME_PITCH_TYPE == pitchType.NAME_PITCH_TYPE).FirstOrDefault() != null)
            {
                PITCH_TYPE tempPitchType = DataProvider.Ins.DB.PITCH_TYPE.Where(x => x.ID_PITCH_TYPE == pitchType.ID_PITCH_TYPE).FirstOrDefault();
                tempPitchType = pitchType;
                DataProvider.Ins.DB.SaveChanges();
                success = true;
            }    
            return success;
        }

        public bool DeletePitchType(PITCH_TYPE pitchType)
        {
            bool success = false;

            if (DataProvider.Ins.DB.PITCH_TYPE.Where(x => x.NAME_PITCH_TYPE == pitchType.NAME_PITCH_TYPE).FirstOrDefault() != null)
            {
                PITCH_TYPE tempPitchType = DataProvider.Ins.DB.PITCH_TYPE.Where(x => x.ID_PITCH_TYPE == pitchType.ID_PITCH_TYPE).FirstOrDefault();
                tempPitchType.IS_DELETED = true;
                DataProvider.Ins.DB.SaveChanges();
                success = true;
            }
            return success;
        }
    }
}
