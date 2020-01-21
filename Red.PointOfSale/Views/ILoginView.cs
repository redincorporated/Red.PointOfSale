using System;
using Red.PointOfSale.Models;

namespace Red.PointOfSale.Views
{
    public interface ILoginView : IView
    {
        event EventHandler<UserEventArgs> Login;
    }
    
    public class ConsoleLoginView : ILoginView
    {
        public ConsoleLoginView()
        {
            
        }
        
        public event EventHandler<UserEventArgs> Login;
        
        protected virtual void OnLogin(UserEventArgs e)
        {
            if (Login != null) {
                Login(this, e);
            }
        }
        
        string ReadLinePassword()
        {
            string pass = "";
            do {
                ConsoleKeyInfo key = Console.ReadKey(true);
                // Backspace Should Not Work
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter) {
                    pass += key.KeyChar;
                    Console.Write("*");
                } else {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0) {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    } else if(key.Key == ConsoleKey.Enter) {
                        break;
                    }
                }
            } while (true);
            return pass;
        }
    }
}
