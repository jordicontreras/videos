using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Videos.Lib.Models
{
    class User : Entity
    {
        private string username;
        private string name;
        private string surname;
        private string password;
        private DateTime dateCreated;
        public List<Video> videoList = new List<Video>();

        //public Video video { get; set; }

        private int usernameMinLength = 4;
        private int usernameMaxLength = 12;
        
        private int passwordMinLength = 6;
        private int passwordMaxLength = 12;
        
        private int nameMaxLength = 20;
        
        private int surnameMaxLength = 40;

        public User()
        {

        }

        //Function that checks for the correct introduction of the surname
        private string ValidUsername(string paramUsername)
        {
            if (paramUsername.Length > usernameMaxLength)
            {
                return "too long";
            }
            else if (paramUsername.Length < usernameMinLength)
            {
                return "too short";
            }
            else
            {
                return paramUsername;
            }
        }

        //Function that checks for the correct introduction of the surname
        private string ValidPassword(string paramPassword)
        {
            if (paramPassword.Length > passwordMaxLength)
            {
                return "too long";
            }
            else if (paramPassword.Length < passwordMinLength)
            {
                return "too short";
            }
            else
            {
                return paramPassword;
            }
        }

        //Function that checks for the correct introduction of the surname
        private string ValidName(string paramName)
        {
            if (!String.IsNullOrEmpty(paramName))
            {
                if(paramName.Length > nameMaxLength)
                {
                    return paramName.Substring(0, nameMaxLength - 1);
                }
                else
                {
                    return paramName;
                }
            }
            else
            {
                return "undefined name";
            }
        }

        //Function that checks for the correct introduction of the surname
        private string ValidSurname(string paramSurname)
        {
            if (!String.IsNullOrEmpty(paramSurname))
            {
                if (paramSurname.Length > surnameMaxLength)
                {
                    return paramSurname.Substring(0, surnameMaxLength - 1);
                }
                else
                {
                    return paramSurname;
                }
            }
            else
            {
                return "undefined surname";
            }
        }

        //Username propertie
        public string USERNAME
        {
            get => this.username;

            set => this.username = ValidUsername(value);
        }

        //Password propertie
        public string PASSWORD
        {
            get => this.password;

            set => this.password = ValidPassword(value);
        }

        //Name propertie
        public string NAME
        {
            get => this.name;

            set => this.name = ValidName(value);
        }

        //Surname propertie
        public string SURNAME
        {
            get => this.surname;

            set => this.surname = ValidSurname(value);
        }

        //Method to print the videos for of a user
        public void PrintVideoList()
        {
            foreach (var video in videoList)
            {
                Console.WriteLine($"ID: {video.Id} Title: {video.TITLE} URL: {video.URL}");
                Console.WriteLine("Tags:");
                foreach(var item in video.tags)
                {
                    Console.WriteLine(item);
                }
            }
        }

    }
}
