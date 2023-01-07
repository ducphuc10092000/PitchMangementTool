using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PitchManagementTool.Services.Commodities_Services
{
    public class CommoditiesService
    {
        public CommoditiesService()
        {

        }

        public List<COMMODITy> GetListCommodities()
        {
            List<COMMODITy> tempList = new List<COMMODITy>();
            tempList = DataProvider.Ins.DB.COMMODITIES.Where(x => x.IS_DELETED == false).ToList();
            return tempList;
        }

        public COMMODITy GetCommoditiesByID(int idCommodities)
        {

            COMMODITy returnCommodities = new COMMODITy();
            returnCommodities = DataProvider.Ins.DB.COMMODITIES.Where(x => x.ID_COMMODITIES == idCommodities).FirstOrDefault();

            return returnCommodities;
        }

        public bool CheckExistedCommoditiesByName(COMMODITy tempCommodities)
        {
            bool is_Existed = false;
            COMMODITy existedCommodities = new COMMODITy();

            existedCommodities = DataProvider.Ins.DB.COMMODITIES.Where(x => x.NAME_COMMODITIES == tempCommodities.NAME_COMMODITIES).FirstOrDefault();

            if (tempCommodities != null)
            {
                is_Existed = true;
                return is_Existed;
            }
            return is_Existed;
        }
        public bool AddNewCommodities(COMMODITy newCommodities)
        {
            bool success = false;
            if (CheckExistedCommoditiesByName(newCommodities) == false)
            {
                DataProvider.Ins.DB.COMMODITIES.Add(newCommodities);
                DataProvider.Ins.DB.SaveChanges();
                success = true;
            }
            return success;

        }

        public bool UpdateCommodities(COMMODITy newCommodities)
        {
            bool success = false;
            if (CheckExistedCommoditiesByName(newCommodities) == false)
            {
                COMMODITy updateCommodities = DataProvider.Ins.DB.COMMODITIES.Where(x => x.ID_COMMODITIES == newCommodities.ID_COMMODITIES).FirstOrDefault();
                updateCommodities = newCommodities;
                DataProvider.Ins.DB.SaveChanges();
                success = true;
            }
            return success;

        }

        public bool DeleteCommodities(COMMODITy deleteCommodities)
        {
            bool success = false;
            COMMODITy neededDeleteCommodities = DataProvider.Ins.DB.COMMODITIES.Where(x => x.ID_COMMODITIES == deleteCommodities.ID_COMMODITIES).FirstOrDefault();
            if(neededDeleteCommodities != null)
            {
                neededDeleteCommodities.IS_DELETED = true;
                DataProvider.Ins.DB.SaveChanges();
                success = true;
            }    
            return success;

        }
    }
}
