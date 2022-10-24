using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PitchManagementTool.Services.Pitch_Services
{
    public class LinkPitchDetail_Service
    {
        public LinkPitchDetail_Service()
        {

        }
        public bool AddNewLinkPitchDetail(PITCH parentPitch, ObservableCollection<PITCH> pitchLinkedList)
        {

            bool success = false;
            if (parentPitch != null)
            {
                foreach(var pitch in pitchLinkedList)
                {
                    LINK_PITCH_DETAILS newLinkPitchDetails = new LINK_PITCH_DETAILS();
                    newLinkPitchDetails.PITCH = pitch;
                    newLinkPitchDetails.PITCH1 = parentPitch;
                    DataProvider.Ins.DB.LINK_PITCH_DETAILS.Add(newLinkPitchDetails);
                    DataProvider.Ins.DB.PITCHes.Where(x => x.ID_PITCH == pitch.ID_PITCH).FirstOrDefault().IS_CHILDREN = true;
                    DataProvider.Ins.DB.SaveChanges();
                }    
                success = true;
            }
            return success;
        }
    }
}
