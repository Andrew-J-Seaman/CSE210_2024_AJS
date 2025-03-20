using System;
using System.Numerics;
using System.Runtime.CompilerServices;

public class Reflection : Activity
{
    //  ******************
    //      * SUMMARY*
    //
    //      ATTRIBUTE:   2
    //      INSTANCE:    1
    //      CONSTRUCTOR: 1
    //      METHOD:      1
    //  ******************

    // ATTRIBUTE........(2)

    // A1.
    private List<string> _promptsReflecting;

    // A2.
    private List<string> _questions;

    // INSTANCES........(1)

    // I1.
    Spinner spinner = new Spinner();

    // CONSTRUCTOR......(1)

    // C1.
    public Reflection(string name, string description, string durationRequestMsg)
        : base(name, description, durationRequestMsg) // Pass Name and Description to base class for initialization
    {
        // Initialize prompts
        _promptsReflecting = new List<string>
        {
            "Think of a time when you overcame a fear.",
            "Think of a time when you made someone feel truly appreciated.",
            "Think of a time when you worked hard to achieve a goal.",
            "Think of a time when you forgave someone who wronged you.",
            "Think of a time when you went out of your way to support a friend.",
            "Think of a time when you stayed calm under pressure.",
            "Think of a time when you stood up for what you believed in.",
            "Think of a time when you made a positive impact on a community.",
            "Think of a time when you learned something valuable from failure.",
            "Think of a time when you put someone else’s needs before your own.",
        };

        // Initialize questions
        _questions = new List<string> // 10 questions
        {
            "Why do you think this experience stood out to you?",
            "What challenges did you face during this experience?",
            "Who else was involved, and how did they contribute?",
            "What emotions did you experience throughout this event?",
            "What surprised you most about this experience?",
            "How would you describe this experience to someone else?",
            "What strengths did you demonstrate during this time?",
            "What would you do differently if you encountered this situation again?",
            "How has this experience shaped your perspective?",
            "What value does this memory hold for your future?",
        };
    }

    // METHOD...........(1)

    // M1.
    // public void RunReflection()
    // {
    //     SetDuration(DisplayPrologue()); // Question duration: 10 sec
    //     Console.Clear();

    //     // REFLECTION functionality:

    //     // Random integers (prompts and questions)
    //     int randNumPrompt = new Random().Next(0, _promptsReflecting.Count); // Random prompt index
    //     int[] randNumsQuestions = new int[_duration]; // Random questions index
    //     for (int j = 0; j < _duration - 1; j++) // Build array of random question indices
    //     {
    //         int randNum;
    //         do
    //         {
    //             randNum = new Random().Next(0, _questions.Count); // Random question
    //         } while (randNum == randNumsQuestions[randNumPrompt]);

    //         randNumsQuestions[j] = randNum;
    //     }

    //     Console.WriteLine("Instructions:\n   > Read the prompt then press enter to answer the first questions.\n");
    //     spinner.SetSpinDuration(1);
    //     spinner.Spin(); // 1 second
    //     Console.WriteLine($"Prompt:\n   > {_promptsReflecting[randNumPrompt]}\n");
    //     PressEnterToContinue();
    //     spinner.SetSpinDuration(3);
    //     spinner.Spin(); // 3 second
    //     Console.Clear();

    //     Console.WriteLine($"Prompt:\n   > {_promptsReflecting[randNumPrompt]}");

    //     int i = 0;
    //     foreach (int q in randNumsQuestions)
    //     {
    //         i++;

    //         DateTime start = DateTime.Now;
    //         DateTime end = start.AddSeconds(10);

    //         Console.WriteLine($"\nQuestion {i}.\n   > {_questions[randNumsQuestions[q]]}");
    //         Console.Write("   > Response: ");
    //         Console.ReadLine();

    //         while (DateTime.Now < end)
    //         {
    //             spinner.SetSpinDuration(10);
    //             spinner.Spin();

    //         }
    //     }
    //     // End activity and display summary
    //     DisplayEpilogue();
    // }

    // M2.
    // public async Task RunReflectionAsync()
    // {
    //     SetDuration(DisplayPrologue()); // Question duration: 10 sec
    //     Console.Clear();

    //     // Random integers (prompts and questions)
    //     int randNumPrompt = new Random().Next(0, _promptsReflecting.Count); // Random prompt index
    //     int[] randNumsQuestions = new int[_duration]; // Random questions index

    //     for (int j = 0; j < _duration; j++) // Build array of random question indices
    //     {
    //         int randNum;
    //         bool valid = false;
    //         do
    //         {
    //             randNum = new Random().Next(0, _questions.Count); // Random question

    //             // Ensure randNum isn't already in randNumsQuestions and isn't equal to randNumPrompt
    //             if (!randNumsQuestions.Contains(randNum))
    //             {
    //                 valid = true;
    //             }
    //         } while (!valid);

    //         randNumsQuestions[j] = randNum;
    //     }

    //     // Show instructions
    //     Console.WriteLine("Instructions:\n   > Read the prompt then press enter to answer the first question.\n");
    //     PressEnterToContinue();
    //     Console.Clear();
    //     Console.WriteLine($"Prompt:\n   > {_promptsReflecting[randNumPrompt]}\n");
    //     PressEnterToContinue();

    //     for (int i = 0; i < _duration; i++)
    //     {
    //         DateTime start = DateTime.Now;
    //         DateTime end = start.AddSeconds(10);

    //         // Run spinner in the background while waiting for user input
    //         Task spinnerTask = Task.Run(() =>
    //         {
    //             while (DateTime.Now < end)
    //             {
    //                 Console.WriteLine();
    //                 spinner.SetSpinDuration(10);
    //                 spinner.Spin();
    //             }
    //         });

    //         Console.WriteLine($"\nQuestion {i + 1}.\n   > {_questions[randNumsQuestions[i]]}");
    //         Console.Write("   > Response: ");
    //         // Wait for the user to provide their response
    //         Console.ReadLine();

    //         // Wait for the spinner to finish before moving to the next question
    //         await spinnerTask;
    //     }

    //     // Correct duration (intervals = 10 sec each)
    //     _duration = _duration * 10;

    //     // End activity and display summary
    //     DisplayEpilogue();
    // }

    // M3.
    public async Task RunReflectionAsync()
    {
        SetDuration(DisplayPrologue()); // Question duration: 10 sec
        Console.Clear();

        // Random integers (prompts and questions)
        int randNumPrompt = new Random().Next(0, _promptsReflecting.Count); // Random prompt index
        int[] randNumsQuestions = new int[_duration]; // Random questions index

        for (int j = 0; j < _duration; j++) // Build array of random question indices
        {
            int randNum;
            bool valid = false;
            do
            {
                randNum = new Random().Next(0, _questions.Count); // Random question

                // Ensure randNum isn't already in randNumsQuestions and isn't equal to randNumPrompt
                if (!randNumsQuestions.Contains(randNum) && randNum != randNumPrompt)
                {
                    valid = true;
                }
            } while (!valid);

            randNumsQuestions[j] = randNum;
        }

        // Show instructions
        Console.WriteLine(
            "Instructions:\n   > Read the prompt then press enter to answer the first question.\n"
        );
        PressEnterToContinue();
        Console.Clear();
        Console.WriteLine($"Prompt:\n   > {_promptsReflecting[randNumPrompt]}\n");
        PressEnterToContinue();

        for (int i = 0; i < _duration; i++)
        {
            DateTime start = DateTime.Now;
            DateTime end = start.AddSeconds(10);

            // Create a cancellation token for controlling the spinner task
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            // Run spinner in the background while waiting for user input
            Task spinnerTask = Task.Run(() =>
            {
                while (DateTime.Now < end && !token.IsCancellationRequested)
                {
                    Console.Write($"\r{spinner.GetNextFrame()}");
                    Thread.Sleep(200); // Sleep to allow time for other actions
                }
            });

            // Print the question and wait for the user to respond
            Console.WriteLine($"\nQuestion {i + 1}.\n   > {_questions[randNumsQuestions[i]]}");
            Console.Write("   > Response: ");

            // Wait for the user input asynchronously
            var inputTask = Task.Run(() => Console.ReadLine());

            // Wait for either the spinner to finish or the user to provide input
            await Task.WhenAny(spinnerTask, inputTask);

            // Cancel the spinner task once the user has finished input
            cts.Cancel();

            // Ensure the spinner task is completed
            await spinnerTask;

            // You can use the input from inputTask if needed
            string userInput = await inputTask;

            // Process userInput if necessary
        }

        // Correct duration (intervals = 10 sec each)
        _duration = _duration * 10;

        // End activity and display summary
        DisplayEpilogue();
    }
}
// REQUIREMENTS
//  •   The activity should begin with the standard starting message and prompt for the duration that is used by all activities.
//  •   The description of this activity should be something like: "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
//  •   After the starting message, select a random prompt to show the user such as:
//      -   Think of a time when you stood up for someone else.
//      -   Think of a time when you did something really difficult.
//      -   Think of a time when you helped someone in need.
//      -   Think of a time when you did something truly selfless.
//  •   After displaying the prompt, the program should ask them to reflect on questions that relate to this experience. These questions should be pulled from a list such as the following:
//      -   Why was this experience meaningful to you?
//      -   Have you ever done anything like this before?
//      -   How did you get started?
//      -   How did you feel when it was complete?
//      -   What made this time different than other times when you were not as successful?
//      -   What is your favorite thing about this experience?
//      -   What could you learn from this experience that applies to other situations?
//      -   What did you learn about yourself through this experience?
//      -   How can you keep this experience in mind in the future?
//  •   After each question the program should pause for several seconds before continuing to the next one. While the program is paused it should display a kind of spinner.
//  •   It should continue showing random questions until it has reached the number of seconds the user specified for the duration.
//  •   The activity should conclude with the standard finishing message for all activities.
