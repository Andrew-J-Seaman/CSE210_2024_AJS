using System.Xml.Serialization;

public class Menu
{
    private Dictionary<int, string> _mainMenu;
    private string _option1;
    private string _option2;
    private string _option3;
    private string _option4;
    private string _option5;
    public int    _choice;

    private string _message1;
    private string _message2;
    private string _message3;

    // New Delay object
    Delay delay = new Delay();

    public Menu()
    {
        _option1 = "Load";
        _option2 = "Display";
        _option3 = "Write";
        _option4 = "Save";
        _option5 = "Quit";

        _mainMenu = new Dictionary<int, string>()
        {
            {1, _option1},
            {2, _option2},
            {3, _option3},
            {4, _option4},
            {5, _option5}
        };
    } 

    // Display menu
    public void DisplayMenuxSelection()
    {
        int choice;
        bool isInt = false;

        do
        {
            // Print menu options (1-5)
            foreach (KeyValuePair<int, string> kvp in _mainMenu)
            {
                Console.WriteLine($"{kvp.Key}. {kvp.Value}");
            }

            // Request menu selection (1-5)
            Console.Write("> Selection (1-5): ");

            // Try to parse the input and check if it’s within the valid range
            if (int.TryParse(Console.ReadLine().Trim(), out choice) && choice >= 1 && choice <= 5)
            {
                _choice = choice; // Assign valid choice to the class variable
                isInt = true; // Exit loop
            }
            else
            {
                // Error (invalid entry)
                _message1 = "Error: invalid entry.";
                // Suggest next action
                _message2 = "Please select a number (1-5).";
                delay.Display2(_message1, _message2);
            }

        } while (!isInt);
    }

    // 2) Greeting message
    // Set
    public void SetGreeting(){
        _message1 = "Welcome! Let's Journal!";
    }
    // Display
    public void DisplayGreeting(){
        delay.Display1(_message1);
    }

    // 3) Departing message
    // Set
    public void SetDeparting(){
        // Success message
        _message1 = "Quitting...";
        _message2 = "Done!";
        // Departing message
        _message3 = "See you tomorrow!";
    }
    // Display
    public void DisplayDeparting(){
        delay.Display3(_message1, _message2, _message3);
    }
}
































/* ORIGINAL CODE: Menu.cs


// AUTHOR: Andrew Seaman


using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;


public class Menu
{
    public int _selectedKeyMainMenuLoop;

    public void MainMenuLoop()
    {   
        // Create a list of actions; current length: 4 items
        List<string> menu_dict_values = new List<string>
        {
            "Write a new entry",        // 1
            "Display the journal",      // 2
            "Change User",              // 3
            "Exit Program"              // 4
        };

        int menu_length = menu_dict_values.Count;

        // Generate keys from 1 to menu_length using LINQ to a list
        List<int> menu_dict_keys = Enumerable.Range(1, menu_length).ToList();

        // Combine keys and values into a dictionary using LINQ's Zip method
        Dictionary<int, string> menuOptions = menu_dict_keys
            .Zip(menu_dict_values, (key, value) => new { key, value })
            .ToDictionary(x => x.key, x => x.value);

        // Redefine class attribute as shortened local variable name
        int selectedKey = _selectedKeyMainMenuLoop;
        bool validKeySelection = true;
        do
        {
            // Print menu title
            Console.WriteLine("Menu:");

            // Print menu: dictionary where each key maps to an Action.
            foreach (KeyValuePair<int, string> kvp in menuOptions) //replaced 'var' with 'KeyValuePair<int, Action>'
            {
                Console.WriteLine($"\t{kvp.Key}. {kvp.Value}");
            }

            // Gets user input for menu option selection
            Console.Write($"\n\tSelect a number(1-{menu_length}): ");
            selectedKey = int.Parse(Console.ReadLine());

            // Running an action from the dictionary using the selected key
            if (menuOptions.ContainsKey(selectedKey))
            {
                validKeySelection = true;
            }
            else
            {
                Console.WriteLine($"\t{selectedKey} is not a valid selection.");
                validKeySelection = false;
            };
        } while (!validKeySelection);
        
        // Redefine class attribute with value of shortened local variable
        _selectedKeyMainMenuLoop = selectedKey;
    }

    public void SaveDeleteMenu()
    {

    }
}


*/