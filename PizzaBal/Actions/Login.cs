using PizzaDal.DAL;
using PizzaDal.Models;

namespace PizzaBal.Actions
{
    public class Login
    {
        private User _user;
        private Login()
        {

        }
        public Login(User user)
        {
            _user = user;
        }
        public bool LoginIn()
        {
            var userDal = new UserDal(_user);
            userDal.Create();
            return false;
        }

        public Validation Validate()
        {
            var validationStatus = new Validation();
            string message = string.Empty;
            if (!IsValidName(_user.Name))
            {
                validationStatus.Message = "Not a Valid Name";
                validationStatus.IsValid = false;
            }
            else if (IsValidEmail(_user.Password))
            {
                message = "Not a Valid Password";
            }
            return validationStatus;
        }

        private bool IsValidName(int p)
        {
            throw new System.NotImplementedException();
        }

        private bool IsValidName(string name)
        {
            return false;
        }

        private bool IsValidEmail(string name)
        {
            return false;
        }

        private bool IsValidContactNo(string name)
        {
            return false;
        }
    }

    public class Validation
    {
        public string Message { get; set; }

        public bool IsValid { get; set; }
    }


}
