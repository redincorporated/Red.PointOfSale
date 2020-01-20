using System;
using Red.PointOfSale.Gui;
using Red.PointOfSale.Helpers;
using Red.PointOfSale.Models;
using Red.PointOfSale.Repositories;

namespace Red.PointOfSale.Controllers
{
    public class UserController
    {
        IUserRepository userRepo;
        
        public UserController()
        {
        }
        
        public LoginPane Login()
        {
            var v = new LoginPane();
            v.Login += delegate(object sender, UserEventArgs e) { 
                var user = userRepo.ReadByUsernameAndPassword(e.User.Username, e.User.Password);
                if (user != null) {
                    
                } else {
                    MessageHelper.ShowWarning("Username or password not correct. Please try again!");
                }
            };
            return v;
        }
        
        public void Logout()
        {
            MainForm.Instance.AddChild(new LoginPane());
        }
    }
}
