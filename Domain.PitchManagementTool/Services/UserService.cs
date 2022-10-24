using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PitchManagementTool.Services
{
    public class UserService
    {
        public UserService()
        {

        }

        public List<USER> GetListUsers()
        {
            return DataProvider.Ins.DB.USERS.Where(user => true).ToList();
        }

        public USER GetUserByUserName(string username)
        {
            return DataProvider.Ins.DB.USERS.Where(user => user.USERNAME == username).FirstOrDefault();
        }

        public USER AddUser(USER user)
        {
            if(DataProvider.Ins.DB.USERS.Where(x=>x.USERNAME == user.USERNAME) != null)
            {
                return null;
            }    
            DataProvider.Ins.DB.USERS.Add(user);
            DataProvider.Ins.DB.SaveChanges();
            return user;
        }

        public bool DeleteUser(USER user)
        {
            DataProvider.Ins.DB.USERS.Where(targetuser => targetuser.ID == user.ID).FirstOrDefault().IS_DELETED = true; 
            DataProvider.Ins.DB.SaveChanges();
            return true;
        }

        public bool UpdateUser(USER user)
        {
            return true;
        }
    }
}
