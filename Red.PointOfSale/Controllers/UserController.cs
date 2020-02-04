using System;
using System.Windows.Forms;
using Red.PointOfSale.Commands;
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
                var user = userRepo.ReadByUsernameAndPassword(e.User.Username, e.User.Password);
                if (user != null) {
                    new CreateSales().Run();
                } else {
                    MessageHelper.ShowWarning("Username or password not correct. Please try again!");
                    loginView.Reset();
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
