using TransactionTracker.Model;
using TransactionTracker.Services;

namespace TransactionTracker.Components.Pages
{
    public partial class Login
    {
        private LoginModel loginModel = new LoginModel();
        private bool loginError = false;

        private void HandleLogin()
        {
            var success = UserService.Login(loginModel.UserName, loginModel.Password);
            if (success)
            {
                Navigation.NavigateTo("/dashboard");
            }
           

            else
            {
                loginError = true;
            }
        }

        public class LoginModel
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}