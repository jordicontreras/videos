using System;
using System.Collections.Generic;
using System.Text;

namespace Videos.Lib.Models
{
    class Video : Entity
    {
        private string title;
        private string url;
        public List<string> tags = new List<string>(10);
        private int maxNumberTags = 10;

        //Function that checks for the correct introduction of the title
        private string checkTitle(string paramTitle)
        {
            if (String.IsNullOrEmpty(paramTitle))
            {
                return "undefined";
            }
            else
            {
                return paramTitle;
            }
        }

        //Function that checks for the correct introduction of the url
        private string checkURL(string paramURL) 
        {
            if (String.IsNullOrEmpty(paramURL))
            {
                return "undefined";
            }
            else
            {
                return paramURL;
            }
        }

        //Title propertie
        public string TITLE
        {
            get => this.title; 

            set => this.title = checkTitle(value);
        }

        //URL propertie
        public string URL
        {
            get => this.url;

            set => this.url = checkURL(value);
        }

        //Method to add tags to the list of tags of the video
        public string AddTag(string paramTag)
        {
            //We create the variable count and initializes with the number of elements added
            int count = this.tags.Count;
            
            //We check if the number of tags is already complete
            if (count > maxNumberTags - 1)
            {
                return "full";
            }
            else
            {         
                //We check if the value given by the user is not empty
                if(string.IsNullOrEmpty(paramTag))
                {
                    return "undefined";
                }
                else
                {
                    this.tags.Add(paramTag);
                    return "ok";
                }               
            }          
        }


    }
}
