using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PitchManagementTool.Services.Receipt_Services
{
    public class Receipt_Detail_Commodities_Service_Service
    {
        public Receipt_Detail_Commodities_Service_Service()
        {

        }

        public List<CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES> GetListCommoditiesDetailByIDReceipt(int idReceipt)
        {
            List<CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES> listCommoditiesDetails = new List<CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES>();
            listCommoditiesDetails = DataProvider.Ins.DB.CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES.Where(x =>x.ID_CUSTOMER_PAYMENT_RECEIPT == idReceipt).ToList();
            return listCommoditiesDetails;
        }

        public List<CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES> GetListCommoditiesDetails()
        {
            List<CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES> listCommoditiesDetails = new List<CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES>();
            listCommoditiesDetails = DataProvider.Ins.DB.CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES.Where(x => true).ToList();
            return listCommoditiesDetails;
        }    
        public bool AddNewReceipt_Detail_Commodities(CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES newDetail)
        {
            bool success = false;

            DataProvider.Ins.DB.CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES.Add(newDetail);
            DataProvider.Ins.DB.SaveChanges();
            success = true; 

            return success;
        }

        public bool UpdateReceipt_Detail_Commodities(CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES updateDetail)
        {
            bool success = false;
            CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES existedDetail = DataProvider.Ins.DB.CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES.Where(x => x.ID_RECEIPT_DETAIL_COMMODITIES_SERVICE == updateDetail.ID_RECEIPT_DETAIL_COMMODITIES_SERVICE).FirstOrDefault();

            if (existedDetail!= null)
            {
                existedDetail = updateDetail;
                DataProvider.Ins.DB.SaveChanges();
                success = true;
            }    
            return success;
        }

        public bool DeleteReceipt_Detail_Commodities(CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES deledteDetail)
        {
            bool success = false;
            CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES existedDetail = DataProvider.Ins.DB.CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES.Where(x => x.ID_RECEIPT_DETAIL_COMMODITIES_SERVICE == deledteDetail.ID_RECEIPT_DETAIL_COMMODITIES_SERVICE).FirstOrDefault();

            if (existedDetail != null)
            {
                existedDetail = deledteDetail;
                DataProvider.Ins.DB.CUSTOMER_PAYMENT_RECEIPT_DETAIL_COMMODITIES.Remove(existedDetail);
                DataProvider.Ins.DB.SaveChanges();
                success = true;
            }
            return success;
        }
    }
}
