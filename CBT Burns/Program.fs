module CBTBurns

[<EntryPoint>]
let main argv =
    

    // List of categories with questions
    let quiz = [
        ("Thoughts and Feelings", 
            [
                "Feeling sad or down in the dumps";
                "Feeling unhappy or blue";
                "Crying spells or tearfulness";
                "Feeling discouraged";
                "Feeling hopeless";
                "Low self esteem";
                "Feeling worthless or inadequate";
                "Guilt or shame";
                "Criticizing yourself or blaming others";
                "Difficulty making decisions";
            ];
        );
        ("Activities and Personal Relationships",
            [
                "Loss of interest in family, friends or colleagues";
                "Loneliness";
                "Spending less time with family or friends";
                "Loss of motivation";
                "Loss of interest in work or other activities";
                "Avoiding work or other activities";
                "Loss of pleasure or satisfaction in life";
            ];
        );
        ("Physical Symptoms",
            [
                "Feeling tired";
                "Difficulty sleeping or sleeping too much";
                "Decreased or increased appetite";
                "Loss of interest in sex";
                "Worrying about your health";
            ];
        );
        ("Suicidal Urges",
            [
                "Do you have any suicidal thoughts?";
                "Would you like to end your life?";
                "Do you have a plan for harming yourself?";
            ]
        )
    ]

    // Record user input and return a number appropriate to input
    let rec rateQuestion () =
        printfn "Valid options are:"
        printfn "\t 0 = Not At All"
        printfn "\t 1 = Somewhat"
        printfn "\t 2 = Moderately"
        printfn "\t 3 = A Lot"
        printfn "\t 4 = Extremely"

        printf "\nInput: "
        let input = System.Console.ReadKey(true)
        match input.KeyChar with
            // Valid input
            | '0' | '1' | '2' | '3' | '4' -> 
                System.Int32.Parse(input.KeyChar.ToString())
            // Invalid input
            | _ -> 
                printfn "Invalid input\n"
                rateQuestion()

    // Prints a string with a line of '----' before and after
    let fancyPrint (str:string) =
        for i = 1 to str.Length + 2 do
            printf "-"
        printfn "\n %s" str
        for i = 1 to str.Length + 2 do
            printf "-"

    // Asks questions in a category and returns the total score
    let rec askQuestions category questions =
        match questions with
        // Empty
        | [] -> 0
        // Non-empty
        | first::others ->
            fancyPrint category
            printfn "\n\nQuestion: %s\n" first
            let score = rateQuestion()
            System.Console.Clear()
            score + askQuestions category others
    
    // Loops over entire quiz and pops out the total score
    let rec runQuiz sets =
        match sets with
            // Empty
            | [] -> 0
            // Non-empty
            | (category, questions)::tail ->
                System.Console.Clear()
                // Ask all questions in category
                let score = askQuestions category questions
                fancyPrint category
                printfn "\nCategory score: %d" score
                printfn "\n\t(To continue press Enter)"
                System.Console.ReadLine() |> ignore
                // Sum scores from other categories
                score + runQuiz tail
    
    // Introduction
    printfn "Welcome to Burns Depression Checklist.\n"
    printfn "Answer the following questions and you'll get to know your depression level!\n"
    printfn "There are a total of 25 questions. For each you'll enter a number from 0 to 4 inclusive."
    printfn "That number indicates how much you have experienced each symptom during the past week, including today.\n"
    printfn "Total score is in the range of 0 - 100 inclusive.\n"
    printfn "\n\tLets begin! (press Enter)"
    System.Console.ReadLine() |> ignore

    // Run quiz
    let totalScore = runQuiz quiz
    System.Console.Clear()

    // Show score
    sprintf "Your total score was %d." totalScore |> fancyPrint 

    // Show level of depression according to Burn's Depression Checklist
    printf "\nYour depression level: "
    match totalScore with
        | a when -1 < a && a <= 5 -> printfn "You are not depressed!"
        | a when 5 < a && a <= 10 -> printfn "Normal but unhappy"
        | a when 10 < a && a <= 25 -> printfn "Mild depression"
        | a when 25 < a && a <= 50 -> printfn "Moderate depression"
        | a when 50 < a && a <= 75 -> printfn "Severe depression"
        | a when 75 < a && a <= 100 -> printfn "Extreme depression"
        | a -> printf "Your score fell of the chart"
    System.Console.ReadLine() |> ignore

    0 // return an integer exit code
