using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PitchManagementTool.Services.Receipt_Services
{
    public class ReceiptService
    {
        public ReceiptService()
        {

        }

        public List<CUSTOMER_PAYMENT_RECEIPT> GetListReceipt()
        {
            List<CUSTOMER_PAYMENT_RECEIPT> tempList = new List<CUSTOMER_PAYMENT_RECEIPT>();
            tempList = DataProvider.Ins.DB.CUSTOMER_PAYMENT_RECEIPT.Where(x => x.IS_DONE == "Đã hoàn thành").ToList();
            return tempList;
        }
        public List<CUSTOMER_PAYMENT_RECEIPT> GetListRececiptForFilter(string receiptDate, string pitchType, string statusReceipt)
        {
            List<CUSTOMER_PAYMENT_RECEIPT> tempList = new List<CUSTOMER_PAYMENT_RECEIPT>();
            if (pitchType == "Tất cả")
            {
                if (statusReceipt == "Tất cả")
                {
                    tempList = DataProvider.Ins.DB.CUSTOMER_PAYMENT_RECEIPT.Where(x => x.BOOKING.DATE_BOOKING == receiptDate).ToList();
                    return tempList;
                }
                else
                {
                    tempList = DataProvider.Ins.DB.CUSTOMER_PAYMENT_RECEIPT.Where(x => x.BOOKING.DATE_BOOKING == receiptDate && x.BOOKING.IS_DONE == statusReceipt).ToList();
                    return tempList;
                }
            }
            else
            {
                if (statusReceipt == "Tất cả")
                {
                    tempList = DataProvider.Ins.DB.CUSTOMER_PAYMENT_RECEIPT.Where(x => x.BOOKING.DATE_BOOKING == receiptDate && x.BOOKING.PITCH.PITCH_TYPE.NAME_PITCH_TYPE == pitchType).ToList();
                    return tempList;
                }
                else
                {
                    tempList = DataProvider.Ins.DB.CUSTOMER_PAYMENT_RECEIPT.Where(x => x.BOOKING.DATE_BOOKING == receiptDate && x.BOOKING.PITCH.PITCH_TYPE.NAME_PITCH_TYPE == pitchType && x.BOOKING.IS_DONE == statusReceipt).ToList();
                    return tempList;
                }
            }    

            tempList = DataProvider.Ins.DB.CUSTOMER_PAYMENT_RECEIPT.Where(x=>x.BOOKING.DATE_BOOKING == receiptDate && x.BOOKING.PITCH.PITCH_TYPE.NAME_PITCH_TYPE == pitchType  && x.BOOKING.IS_DONE == statusReceipt).ToList();
            return tempList;
        }

        public bool AddNewReceipt(CUSTOMER_PAYMENT_RECEIPT newCustomerPaymentReceipt)
        {
            bool success = false;

            if(newCustomerPaymentReceipt != null)
            {
                DataProvider.Ins.DB.CUSTOMER_PAYMENT_RECEIPT.Add(newCustomerPaymentReceipt);
                DataProvider.Ins.DB.SaveChanges();
                success = true;
            }    
            return success;
        }

        public bool DeleteReceipt(CUSTOMER_PAYMENT_RECEIPT tempCustomerPaymentReceipt)
        {
            bool success = false;
            if(DataProvider.Ins.DB.CUSTOMER_PAYMENT_RECEIPT.Where(x=>x.ID_CUSTOMER_PAYMENT_RECEIPT == tempCustomerPaymentReceipt.ID_CUSTOMER_PAYMENT_RECEIPT).FirstOrDefault() != null)
            {
                CUSTOMER_PAYMENT_RECEIPT deleteReceipt = new CUSTOMER_PAYMENT_RECEIPT();
                deleteReceipt = DataProvider.Ins.DB.CUSTOMER_PAYMENT_RECEIPT.Where(x => x.ID_CUSTOMER_PAYMENT_RECEIPT == tempCustomerPaymentReceipt.ID_CUSTOMER_PAYMENT_RECEIPT).FirstOrDefault();
                DataProvider.Ins.DB.CUSTOMER_PAYMENT_RECEIPT.Remove(deleteReceipt);
                DataProvider.Ins.DB.SaveChanges();
                success = true;

            }    

            return success;
        }
    }
}
