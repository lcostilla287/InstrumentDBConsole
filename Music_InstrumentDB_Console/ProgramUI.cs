using Music_InstrumentDB_Console.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Music_InstrumentDB_Console
{
    public class ProgramUI
    {
        private Authentication authentication = new Authentication();
        private HttpClient httpClient = new HttpClient();
        public void Run()
        {
            Login();
        }

        private void Login()
        {
            bool login = true;
            while (login)
            {
                Console.Clear();
                Console.WriteLine("1. Login\n" +
                    "2. Exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        EnterLogin();
                        break;
                    case "2":
                        login = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid option");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void EnterLogin()
        {
            Console.Clear();
            Console.Write("Username: ");
            string userName = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            Token token = authentication.GetToken(userName, password);
            if (token != null)
            {
                Console.WriteLine("Welcome");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
                Console.ReadKey();


                Menu();
                //HttpResponseMessage response = httpClient.GetAsync("https://localhost:44363/api/Instrument/2").Result;
                //if (response.IsSuccessStatusCode)
                //{
                    //Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                //}
                //else
                //{
                    //Console.WriteLine(response.StatusCode);
                //}
                //Console.ReadKey();
                //Console.ReadKey();
                //Info();
            }
            else
            {
                Console.WriteLine("Please try again");
                Console.ReadKey();
                EnterLogin();
            }
        }
        //private void Info()
        //{

            //HttpResponseMessage response = httpClient.GetAsync("https://localhost:44363/api/Instrument/2").Result;

            //if (response.IsSuccessStatusCode)
            //{
                //Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            //}
            //else
            //{
                //Console.WriteLine(response.StatusCode);
            //}
            //Console.ReadKey();
        //}
        private void Menu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("Insert menu here");
            Console.ReadKey();
        }
    }
}
