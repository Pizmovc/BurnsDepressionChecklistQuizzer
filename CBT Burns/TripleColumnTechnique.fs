module TripleColumnTechnique
    open Console
    let Run () =
        Clear()
        

        let rec collectThoughts thoughts =
            Clear()
            printfn "Enter another automatic thought or just press Enter to stop collecting thoughts.\n"
            printf "Input: "
            let input = ReadLine()
            match input with
                | "" -> 
                    Clear()
                    printfn "You will now classify each thought according to the 10 Cognitive Distortions.\n\n\t(Press Enter to continue)"
                    PressEnter()
                    thoughts
                | a -> a::(collectThoughts thoughts)

        let rec classify thought =
            Clear()
            printfn "Currently classifying thought '%s'" thought
            printfn "\nWhich of the following distortions can you recognize in the thought:"
            printfn "\t1. ALL-OR-NOTHING THINKING"//: You see things in black-and-white categories. If your performance falls short of perfect, you see yourself as a total failure."
            printfn "\t2. OVERGENERALIZATION"//: You see a single negative event as a never-ending pattern of defeat."
            printfn "\t3. MENTAL FILTER"//: You pick out a single negative detail and dwell on it exclusively so that your vision of all reality becomes darkened, like the drop of ink that colors the entire beaker of water."
            printfn "\t4. DISQUALIFYING THE POSITIVE"//: You reject positive experiences by insisting they “don’t count” for some reason or other. In this way you can maintain a negative belief that is contradicted by your everyday experiences."
            printfn "\t5. JUMPING TO CONCLUSIONS"//: You make a negative interpretation even though there are no definite facts that convincingly support your conclusion."
            printfn "\t\ta. Mind reading"//. You arbitrarily conclude that someone is reacting negatively to you, and you don’t bother to check this out."
            printfn "\t\tb. The Fortune Teller Error"//. You anticipate that things will turn out badly, and you feel convinced that your prediction is an already-established fact."
            printfn "\t6. MAGNIFICATION (CATASTROPHIZING) OR MINIMIZATION"//: You exaggerate the importance of things (such as your goof-up or someone else’s achievement), or you inappropriately shrink things until they appear tiny (your own desirable qualities or the other fellow’s imperfections). This is also called the “binocular trick.”"
            printfn "\t7. EMOTIONAL REASONING"//: You assume that your negative emotions necessarily reflect the way things really are: “I feel it, therefore it must be true.”"
            printfn "\t8. SHOULD STATEMENTS"//: You try to motivate yourself with shoulds and shouldn’ts, as if you had to be whipped and punished before you could be expected to do anything. “Musts” and “oughts” are also offenders. The emotional consequence is guilt. When you direct should statements toward others, you feel anger, frustration, and resentment."
            printfn "\t9. LABELING AND MISLABELING"//: This is an extreme form of overgeneralization. Instead of describing your error, you attach a negative label to yourself: “I’m a loser.” When someone else’s behavior rubs you the wrong way, you attach a negative label to him: “He’s a goddam louse.” Mislabeling involves describing an event with language that is highly colored and emotionally loaded."
            printfn "\t10. PERSONALIZATION"//: You see yourself as me cause of some negative external event which in fact you were not primarily responsible for."
            printfn "\n Please enter all numbers for those distortions you think are pressent (for example: '1 3 5b 10') and press Enter."
                    
            printf "\n Input: "

            let input = ReadLine()
            match input with
                | "" -> 
                    printfn "\nPlease enter at least one number!"
                    classify thought
                | a -> a

        let rec identifyErrors thoughts =
            match thoughts with
                | [] -> []
                | head::tail -> 
                    Clear()
                    (head, (classify head))::(identifyErrors tail)

        let rec printErrors errors =
            match errors with
                | [] -> ()
                | head::tail ->
                    match head with
                        | "1" -> printfn "\tALL-OR-NOTHING THINKING"
                        | "2" -> printfn "\tOVERGENERALIZATION"
                        | "3" -> printfn "\tMENTAL FILTER"
                        | "4" -> printfn "\tDISQUALIFYING THE POSITIVE"
                        | "5" -> printfn "\tJUMPING TO CONCLUSIONS"
                        | "5a" -> printfn "\tJUMPING TO CONCLUSIONS: Mind reading"
                        | "5b" -> printfn "\tJUMPING TO CONCLUSIONS: The Fortune Teller Error"
                        | "6" -> printfn "\tMAGNIFICATION (CATASTROPHIZING) OR MINIMIZATION"
                        | "7" -> printfn "\tEMOTIONAL REASONING"
                        | "8" -> printfn "\tSHOULD STATEMENTS"
                        | "9" -> printfn "\tLABELING AND MISLABELING"
                        | "10" -> printfn "\tPERSONALIZATION"
                        | a -> printfn "Unknown: %s" a
                    printErrors tail
                    
        let rec respondRationally thoughts =
             match thoughts with
                | [] -> []
                | (thought, errors:string)::tail ->
                    Clear()
                    printfn "Currently responding to thought '%s'" thought
                    printfn "\nYou found the following errors in your analysis:"
                    errors.Split(' ') 
                        |> Array.toList
                        |> printErrors
                    printfn "\nNow please enter your rational response!"        
                    printf "\nInput: "
                    let head = (thought, errors, ReadLine())
                    Clear()
                    head::(respondRationally tail)

        let rec printEndResult thoughts =
            match thoughts with
                | [] -> ()    
                | (thought, errors:string, response)::tail ->
                    sprintf "Thought: '%s'" thought |> fancyPrint
                    printfn "\nErrors:"
                    errors.Split(' ') 
                        |> Array.toList
                        |> printErrors
                    printfn "\nYour response: '%s'\n" response
                    printEndResult tail

        collectThoughts []
            |> identifyErrors
            |> respondRationally
            |> printEndResult
                    
        printfn "\t(Press Enter to return to main menu)"

        PressEnter()

