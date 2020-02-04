using System;
using System.Windows.Forms;
using Red.PointOfSale.Gui;
using Red.PointOfSale.Helpers;
using Red.PointOfSale.Models;
using Red.PointOfSale.Repositories;
using Red.PointOfSale.Views;

namespace Red.PointOfSale.Controllers
{
    public class UserController
    {
        IUserRepository userRepo;
        ILoginView loginView;
        
        public UserController(IUserRepository userRepo, ILoginView loginView)
        {
            this.userRepo = userRepo;
            this.loginView = loginView;
        }
        
        public IView Login()
        {
            loginView.Login += delegate(object sender, UserEventArgs e) { 
                var user = userRepo.ReadByUsernameAndPassword(e.User.Name, e.User.Password);
                if (user != null) {
                    // TODO:
                } else {
                    MessageHelper.ShowWarning("Username or password not correct. Please try again!");
                }
            };
            return loginView;
        }
        
        public void Logout()
        {
            MainForm.Instance.AddChild(new LoginPane());
        }
    }
}
