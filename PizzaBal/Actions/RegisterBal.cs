using PizzaDal.DAL;
using PizzaDal.Models;
using System;
using System.Data.SqlClient;
using System.Configuration;

namespace PizzaBal.Actions
{
    public class RegisterBal
    {
        public string message = string.Empty;
        private User _user;
        public RegisterBal()
        {

        }
        public RegisterBal(User user)
        {
            _user = user;
        }
        public bool SignUp()
        {
            var userDal = new UserDal(_user);
            userDal.Create();
            return false;
        }

        public Validation Validate()
        {
            var validationStatus = new Validation() { IsValid = true, Message = "Ok" };

            //if (!IsValidName(_user.Name))
            //{
            //    //validationStatus.Message = "Not a Valid Name";
            //    validationStatus.IsValid = false;
            //}
            //else if (IsValidEmail(_user.Email))
            //{

            //    message = "Not a Valid Email";
            //}
            return validationStatus;
        }

        private bool IsValidName(string name)
        {
            return false;
        }

        public bool IsValidEmail(string emailAddress)
        {
            var regDal = new RegisterDal();
            regDal.CheckEmail(emailAddress);

            return true;
        }

        private bool IsValidContactNo(string name)
        {
            return false;
        }


    }

    public class Validation1
    {
        public string Message { get; set; }
        public bool IsValid { get; set; }
    }
}


