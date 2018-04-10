//using System;
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game config data
    string[] level1PW = { "sony","crash","vita","playstation","videogame"}; 
    string[] level2PW = { "xbox","halo","controller","kinect","membership"}; 
    string[] level3PW = { "mario", "zelda", "switch", "nintendo", "pokemon" };

    // not able to change this string when const is added
    const string menuHint = "Type 'menu' to go back";
    // Game state
    int level;

    // are your own self made vars
    enum Screen { MainMenu,Password,Win};
    Screen currentScreen;
    string password;


	// Use this for initialization
	void Start () 
    {
        ShowMainMenu();
	}

    void ShowMainMenu()
    {   currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hacking into gaming companies...");
        Terminal.WriteLine("Which company would like to hack into?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for Sony(Easy)");
        Terminal.WriteLine("Press 2 for Microsoft(Medium)");
        Terminal.WriteLine("Press 3 for Nintendo(Hard)");
        Terminal.WriteLine("");
        Terminal.WriteLine("Make a selection: ");

    }

    // this decides how to handle user input
    void OnUserInput(string input)
    {
        if (input == "menu") // able to get to the menu screen
        {
            ShowMainMenu();
        }
        else if(input == "quit" || input == "close"|| input == "exit"){
            Terminal.WriteLine("If on the web close the tab");
            Application.Quit();

        }
        else if (currentScreen == Screen.MainMenu)
        {
            runMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            checkPassword(input);
        }
    }


    void runMainMenu(string input)
    {
        bool isValidLevelNum = (input == "1" || input == "2"|| input == "3");
        if (isValidLevelNum){
            level = int.Parse(input);
            askForPassword();
        }
        else
        {
            Terminal.WriteLine("This is not a valid input.");

        }
    }

    //Starts the game
    void askForPassword()
    {
        currentScreen = Screen.Password;
        setRandomPassword();
        Terminal.ClearScreen();
        Terminal.WriteLine("Enter your password, Hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    //sets the password for the level
    void setRandomPassword()
    {
        switch (level)
        {
            case 1:
                int index1 = Random.Range(0, level1PW.Length);
                password = level1PW[index1];
                break;
            case 2:
                int index2 = Random.Range(0, level2PW.Length);
                password = level2PW[index2];
                break;
            case 3:
                int index3 = Random.Range(0, level3PW.Length);
                password = level3PW[index3];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }

    }

    //checks for the password
    void checkPassword(string input)
    {
        if (input == password)
        {
            displayWinScreen();
        }
        else
        {
            askForPassword();
        }
    }

    //Shows your win Screen
    void displayWinScreen()
    {
        Terminal.ClearScreen();
        showLevelReward();

        Terminal.WriteLine(menuHint);

    }

    void showLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Hack successful.");
                Terminal.WriteLine("Heres a cat.");
                Terminal.WriteLine(@"
           |\__/,|   (`\
           |_ _  |.--.) )
           ( T   )     /
          (((^_(((/(((_>" );
                break;
            case 2:
                Terminal.WriteLine("Hack successful.");
                Terminal.WriteLine("Heres a cat.");
                Terminal.WriteLine(@"
           |\_/|     
           (. .)
            =w= (\   
           / ^ \//   
          (|| ||)
          ,""_""_ . " );

                break;
            case 3:
                Terminal.WriteLine("Hack successful.");
                Terminal.WriteLine("Heres a hat.");
                Terminal.WriteLine(@"
           /\_/\
           >^.^<.---.
          _'-`-'     )\
         (6--\ |--\ (`.`-.
             --'  --'  ``-'BP ");

                break;
            default:
                Debug.LogError("This is an invalid level reached");
                break;
        }
    }

    void removePassword(){
        print(password);

    }
}
