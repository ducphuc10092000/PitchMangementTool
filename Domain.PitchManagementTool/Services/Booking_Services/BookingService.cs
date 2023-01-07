using Domain.PitchManagementTool.Services.Receipt_Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PitchManagementTool.Services.Booking_Services
{
    public class BookingService
    {
        public BookingService()
        {

        }
        public List<BOOKING> GetListBookingByDateBooking(string checkInTime, string checkOutTime, string dateBooking, string namePitchType)
        {
            bool checkTime(string checkInTimeFilter, string checkOutTimeFilter, string checkInTimeDTB, string checkOutTimeDTB)
            {
                bool success = false;

                int resultCheckInTime = TimeSpan.Compare(Convert.ToDateTime(checkInTimeDTB).TimeOfDay, Convert.ToDateTime(checkInTimeFilter).TimeOfDay);

                int resultCheckOutTime = TimeSpan.Compare(Convert.ToDateTime(checkOutTimeFilter).TimeOfDay, Convert.ToDateTime(checkOutTimeDTB).TimeOfDay);

                if (resultCheckInTime >= 0 && resultCheckOutTime >= 0)
                {
                    success = true;
                }
                return success;
            }

            List<BOOKING> bookingListByDate = new List<BOOKING>();
            bookingListByDate = DataProvider.Ins.DB.BOOKINGs.Where(x => x.DATE_BOOKING == dateBooking && x.PITCH.PITCH_TYPE.NAME_PITCH_TYPE == namePitchType).ToList();

            foreach (var item in bookingListByDate.ToList())
            {
                if (checkTime(checkInTime, checkOutTime, item.CHECK_IN_TIME, item.CHECK_OUT_TIME) == false)
                {
                    bookingListByDate.Remove(item);
                }
            }

            return bookingListByDate;
        }
        public bool AddNewBooking(BOOKING newbooking)
        {
            bool success = false;
            if (newbooking != null)
            {
                //AddNewBooking
                DataProvider.Ins.DB.BOOKINGs.Add(newbooking);


                //Create Receipt
                ReceiptService receipt_Services = new ReceiptService();

                CUSTOMER_PAYMENT_RECEIPT newCustomer_Payment_Receipt = new CUSTOMER_PAYMENT_RECEIPT();
                newCustomer_Payment_Receipt.BOOKING = newbooking;
                newCustomer_Payment_Receipt.COST_USED_PITCH = newbooking.COST;
                newCustomer_Payment_Receipt.COST_COMMODITIES_SERVICE = 0.ToString();
                newCustomer_Payment_Receipt.USER = newbooking.USER;
                newCustomer_Payment_Receipt.CREATE_AT = DateTime.UtcNow.AddHours(7);
                newCustomer_Payment_Receipt.IS_DELETED = false;
                newCustomer_Payment_Receipt.TOTAL_COST = (Convert.ToInt64(newCustomer_Payment_Receipt.TOTAL_COST) + Convert.ToInt64(newbooking.COST)).ToString();
                newCustomer_Payment_Receipt.IS_DONE = "Chưa hoàn thành";
                newCustomer_Payment_Receipt.COST_PAID = "0";
                newCustomer_Payment_Receipt.COST_UNPAID = newCustomer_Payment_Receipt.TOTAL_COST;

                receipt_Services.AddNewReceipt(newCustomer_Payment_Receipt);

                DataProvider.Ins.DB.SaveChanges();

                success = true;
            }
            return success;
        }
        public bool UpdateBooking(BOOKING updatebooking)
        {
            bool success = false;
            if (updatebooking != null)
            {
                //Catch Tempbooking in DTB where == updatebooking
                BOOKING tempbooking = DataProvider.Ins.DB.BOOKINGs.Where(x => x.ID_BOOKING == updatebooking.ID_BOOKING).FirstOrDefault();
                tempbooking = updatebooking;
                //Catch Receipt existed by BOOKING
                CUSTOMER_PAYMENT_RECEIPT tempCustomer_Payment_Receipt = new CUSTOMER_PAYMENT_RECEIPT();
                tempCustomer_Payment_Receipt = DataProvider.Ins.DB.CUSTOMER_PAYMENT_RECEIPT.Where(x => x.ID_BOOKING == tempbooking.ID_BOOKING).FirstOrDefault();
                tempCustomer_Payment_Receipt.TOTAL_COST = (Convert.ToInt64(tempCustomer_Payment_Receipt.TOTAL_COST) - Convert.ToInt64(tempCustomer_Payment_Receipt.COST_USED_PITCH)).ToString();
                tempCustomer_Payment_Receipt.COST_USED_PITCH = updatebooking.COST;
                tempCustomer_Payment_Receipt.TOTAL_COST = (Convert.ToInt64(tempCustomer_Payment_Receipt.TOTAL_COST) + Convert.ToInt64(tempCustomer_Payment_Receipt.COST_USED_PITCH)).ToString();
                tempCustomer_Payment_Receipt.USER1 = updatebooking.USER1;
                tempCustomer_Payment_Receipt.UPDATE_AT = DateTime.UtcNow.AddHours(7);

                DataProvider.Ins.DB.SaveChanges();

                success = true;
            }
            return success;
        }

        public bool DeleteBooking(BOOKING newbooking)
        {
            bool success = false;
            if (newbooking != null)
            {
                DataProvider.Ins.DB.BOOKINGs.Remove(newbooking);
                DataProvider.Ins.DB.SaveChanges();
                success = true;
            }
            return success;
        }
    }
}
