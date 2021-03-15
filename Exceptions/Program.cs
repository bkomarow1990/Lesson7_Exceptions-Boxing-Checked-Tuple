using System;

namespace Exceptions
{
    class Program
    {
        class Account
        {
            string login="NoLogin";
            void checkLogin(string login) {
                if (String.IsNullOrWhiteSpace(login))
                {
                    throw new LoginExcpetion("Login is Null or white space");
                }
                if (login.Length < 5)
                {
                    var ex = new LoginExcpetion("Login too short! Must be more 4 symbols");
                    ex.HelpLink = "http://google.com";
                    ex.Data.Add("Length", login.Length);
                    ex.Data.Add("BadLogin", login);
                    ex.Data.Add("Time: ", DateTime.Now); // or ex.Data["Time"] = DateTime.Now
                    
                    throw ex;
                }

            }
            public Account(string login="NoLogin")
            {
                Login = login;
            }
            public string Login
            {
                get => login;
                set
                {
                    checkLogin(value);
                    login = value;
                }
            }
        }
        static void Main(string[] args)
        {
            try {
                int numer = int.Parse(Console.ReadLine());
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception type: {ex.GetType().Name}, {ex.Message}");
            }
                Console.WriteLine("Account exception test: ");
                Account account = new Account();
            try {
                account.Login = "abc";
            }
            catch (LoginExcpetion ex)
            {
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"Help Link: {ex.HelpLink}");
                foreach (var item in ex.Data)
                {
                    Console.WriteLine($"{item}");
                }
            }
            //overflove type
            byte a = 250, b = 2;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{a,10}");
                try
                {
                    checked
                    {
                        ++a;
                    }
                }
                catch(OverflowException ex)
                {
                    Console.WriteLine($" {ex.Message}");
                    a = 0;
                }
                --b;
            }
        }
    }
}
