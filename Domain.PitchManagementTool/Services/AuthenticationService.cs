using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Domain.PitchManagementTool.Services
{
    public class AuthenticationService
    {
        UserService userService = new UserService();
        public AuthenticationService()
        {

        }

        public USER Login(string username, string password)
        {
            USER storedUser = userService.GetUserByUserName(username);
            IPasswordHasher _passwordHasher = new PasswordHasher();
            if (storedUser != null)
            {

                Microsoft.AspNet.Identity.PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(storedUser.PASSWORD.ToString(), password.ToString());

                if (passwordResult != Microsoft.AspNet.Identity.PasswordVerificationResult.Success)
                {
                    return null;
                }

                else
                {
                    return storedUser;
                }
            }
            else
            {
                return storedUser;
            }
        }

        public bool Register(string username, string password, USER newUser)
        {
            bool success = false;
            IPasswordHasher _passwordHasher = new PasswordHasher();
            string passwordHashed = _passwordHasher.HashPassword(password);
            newUser.PASSWORD = passwordHashed;

            userService.AddUser(newUser);
            if (userService.AddUser(newUser) != null)
            {
                success = true;
            }
            return success;
        }
    }
}
