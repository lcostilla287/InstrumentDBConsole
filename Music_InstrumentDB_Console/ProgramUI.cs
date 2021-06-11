﻿using Music_InstrumentDB_Console.POCO;
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
            }
            else
            {
                Console.WriteLine("Please try again");
                Console.ReadKey();
                EnterLogin();
            }
        }

        private void Menu()
        {
            Console.Clear();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Access Instrument Families\n" +
                "2. Access Instruments\n" +
                "3. Access Musicians\n" +
                "4. Log Out");

            switch (Console.ReadLine())
            {
                case "1":
                    InstrumentFamilyAccess();
                    break;
                case "2":
                    InstrumentAccess();
                    break;
                case "3":
                    MusicianAccess();
                    break;
                case "4":
                    EnterLogin();
                    break;
                default:
                    Console.WriteLine("Please select a valid option");
                    Console.ReadKey();
                    Menu();
                    break;
            }
        }

        private void InstrumentFamilyAccess()
        {
            Console.Clear();
            Console.WriteLine("You are now accessing instrument families");
            Console.ReadKey();
        }

        private void InstrumentAccess()
        {
            Console.Clear();
            Console.WriteLine("You are now accessing instruments");
            Console.ReadKey();
        }

        private void MusicianAccess()
        {
            Console.Clear();
            Console.WriteLine("You are now accessing musicians");
            Console.ReadKey();
        }
    }
}
