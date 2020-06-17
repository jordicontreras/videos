using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using Videos.Lib.Models;

namespace Videos
{
    class Program
    {
        //We create the users dictionary
        public static Dictionary<string, User> usersDict = new Dictionary<string, User>();

        //We create the users dictionary
        public static Dictionary<string, Video> videosDict = new Dictionary<string, Video>();

        static bool loginOK = false;
        static string username;
        public static User loggedUser;
        

        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to the Videos Software");

            OptionsMenu();
    
        }

        //Function that shows the main menu
        static void ShowOptionsMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("To create a user, write 'user'");
            Console.WriteLine("To Log In, write login");
            Console.WriteLine("To end the program write 'finish'");
        }

        //Function that redirects to the chosen section by the user
        static void OptionsMenu()
        {
            bool exit = false;

            while (!exit)
            {
                ShowOptionsMenu();
                var selectedOption = Console.ReadLine();

                switch (selectedOption)
                {
                    case "user":
                        CreateUser();
                        break;
                    case "login":
                        Login();
                        break;
                    case "finish":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("You did not write a correct option");
                        break;
                }
            }
        }

        //Function to create the user
        static void CreateUser()
        {
            var usernameCorrect = false;

            //we keep in the while until the user creates correctly the user or asks for exit
            while (!usernameCorrect)
            {
                Console.WriteLine("Introduce a username or write 'exit' to exit");
                //we read the username introduced by the user
                var username = Console.ReadLine();

                //if the user writes exit we go to the main menu
                if (username == "exit")
                {
                    break;
                }

                //We create an object User
                var user = new User();
                user.USERNAME = username;

                //We check if the user exists already in the dictionary
                if (usersDict.ContainsKey(username))
                {
                    Console.WriteLine("This username is already registered. Try a different one or go to the Login section");
                }
                //Checkings on the propertie USERNAME
                else if (user.USERNAME == "too short")
                {
                    Console.WriteLine("You need to write at least 4 characters for your username");
                }
                else if (user.USERNAME == "too long")
                {
                    Console.WriteLine("You need to write a maximun of 12 characters for your username");
                }
                //if everything with the username we start with the password
                else
                {
                    Console.WriteLine("Your chosen username is: " + user.USERNAME);
                    var passwordCorrect = false;

                    //We keep in the while until the password is correct or the user asks for exit
                    while (!passwordCorrect)
                    {
                        Console.WriteLine("Now write your password or write 'exit' to exit");

                        var password = Console.ReadLine();

                        if (password == "exit")
                        {
                            usernameCorrect = true;
                            break;
                        }

                        //We set the propertie PASSWORD with the value introduced by the user
                        user.PASSWORD = password;

                        //Checkings on the propertie PASSWORD
                        if (user.PASSWORD == "too short")
                        {
                            Console.WriteLine("You need to write at least 6 characters for your password");
                        }
                        else if (user.PASSWORD == "too long")
                        {
                            Console.WriteLine("You need to write a maximun of 12 characters for your password");
                        }
                        //if everything is ok we add the user to the dictionary
                        else
                        {
                            Console.WriteLine("Your chosen password is: " + user.PASSWORD);
                            usersDict.Add(username, user);
                            Console.WriteLine($"The user {username} has been created correctly");
                            usernameCorrect = true;
                            passwordCorrect = true;
                            break;
                        }
                    }
                }
            }
        }

        //Function to Log in as a user
        static void Login()
        {
            Console.WriteLine("Introduce the username");
            username = Console.ReadLine();
            Console.WriteLine("Introduce the password");
            var password = Console.ReadLine();

            //Function that checks if the login is correct
            loginOK = checkLogin(username, password);

            //if the login is ok we get redirected to the videos section
            if(loginOK == true)
            {
                Console.WriteLine("Logged in correctly");
                videoSection();
            }
            else
            {
                Console.WriteLine("The username or password are not correct");
            }
        }

        //Function that returns true if the login is correct or false if the login is not correct
        static bool checkLogin(string paramUsername, string paramPassword)
        {
            if (usersDict.ContainsKey(paramUsername))
            {
                usersDict.TryGetValue(paramUsername, out User foundUser);

                if(foundUser.PASSWORD == paramPassword)
                {
                    loggedUser = foundUser;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //Function that redirects to the chosen video section by the user
        static void videoSection()
        {
            bool exit = false;

            while (!exit)
            {
                ShowMenuVideo();
                var videoOption = Console.ReadLine();

                switch (videoOption)
                {
                    case "all":
                        ShowAllUserVideos();
                        break;
                    case "add":
                        CreateVideo();
                        break;
                    case "exit":
                        loggedUser = null;
                        exit = true;
                        break;
                    case "tags":
                        AddTags();
                        break;
                    default:
                        Console.WriteLine("You did not write a correct option");
                        break;
                }
            }

        }

        //Function that prints the menu options in the video section
        static void ShowMenuVideo()
        {
            Console.WriteLine("");
            Console.WriteLine("Welcome to the videos section");
            Console.WriteLine("To show all your videos, write 'all'");
            Console.WriteLine("To add a new video write 'add'");
            Console.WriteLine("To add tags to a video write 'tags'");
            Console.WriteLine("To logout write 'exit'");
        }

        //Function to create new videos
        static void CreateVideo()
        {
            //Boolean to exit the whole while to create video
            var exit = false;
            //Boolean to exit the while for the title introduction
            var titleCorrect = false;
            //Boolean to exit the while for the url introduction
            var urlCorrect = false;

            while (!exit)
            {
                Console.WriteLine("Write the title of the video");
                //we save the student DNI
                var title = Console.ReadLine();

                //If the user writes exit we leave the video creation
                if (title == "exit")
                {
                    break;
                }

                //We create a new object Video
                var video = new Video();
                video.TITLE = title;

                if(video.TITLE == "undefined")
                {
                    Console.WriteLine("The title can't be empty. Try again.");
                }
                else
                {                    
                    titleCorrect = true;
                    Console.WriteLine("Title introduced correctly.");

                    //We keep on this while until the introduced url is correct or the user write exit
                    while (!urlCorrect)
                    {
                        Console.WriteLine("Now write the url for the video or write 'exit' to exit.");
                        //We save the url introduced by the user
                        var url = Console.ReadLine();

                        if(url == "exit")
                        {
                            exit = true;
                            break;
                        }

                        video.URL = url;
                        if (video.URL == "undefined")
                        {
                            Console.WriteLine("The url can't be empty. Try again.");
                        }
                        else
                        {
                            urlCorrect = true;
                            Console.WriteLine("url introduced correctly");

                            Console.WriteLine("Do you want to add some tags Y/N?");
                            //We save the answer of the user
                            var answerTags = Console.ReadKey().Key.ToString();
                            Console.WriteLine("");

                            //We keep in this while if the user wants to keep introducing tags
                            while (answerTags == "Y")
                            {
                                Console.WriteLine("Write the tag");
                                var tag = Console.ReadLine();

                                //We call the function to add the tag in the class
                                var result = video.AddTag(tag);
                                if(result == "full")
                                {
                                    Console.WriteLine("The tags list is full, delete before adding new ones");
                                    answerTags = "N";
                                }
                                else if(result == "undefined")
                                {
                                    Console.WriteLine("The tag can't be empty. Try again.");
                                }
                                else
                                {
                                    Console.WriteLine("Do you want to add more tags Y/N?");
                                    answerTags = Console.ReadKey().Key.ToString();
                                    Console.WriteLine("");
                                }
                            }

                            //We add the video to the users videolist
                            loggedUser.videoList.Add(video);
                            //We add the video to the videos dictionary
                            videosDict.Add(video.TITLE, video);
                            Console.WriteLine("Video created correctly");
                            exit = true;
                        }
                    }                 
                }

            }
        }

        //We print all the videos of the logged user
        static void ShowAllUserVideos()
        {
            loggedUser.PrintVideoList();
        }

        //Function that will add tags to the selected video
        static void AddTags()
        {
            Console.WriteLine("Write the title of the video you want to add tags");
            var videoTitle = Console.ReadLine();

            //We check if the video exists in the dictionary
            if (!videosDict.ContainsKey(videoTitle))
            {
                Console.WriteLine("The video you are looking for doesn't exist.");
            }
            else
            {
                //Because the video exists we try to add the tag
                Console.WriteLine("Write the new tag");
                var newTag = Console.ReadLine();
                string result = videosDict[videoTitle].AddTag(newTag);

                if(result == "ok")
                {
                    Console.WriteLine("tag added correctly.");
                }
                else if(result == "undefined")
                {
                    Console.WriteLine("The tag can't be empty.");
                }
                else if(result == "full")
                {
                    Console.WriteLine("The tags list is already full, you can't add more.");
                } 
            }

        }
    }
}
