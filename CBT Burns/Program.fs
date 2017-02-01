module CBTBurns
open Console
[<EntryPoint>]
let main argv =
    let mutable exit = false
    
    while not exit do
        Clear()
        printfn "Welcome to this un-official helper program for a book Feeling Good by David D. Burns.\n"
        printfn "\n Please select your desired activity:\n\n"
        printfn "\t1. Run Burns Depression Checklist"
        printfn "\t2. Triple-column technique"
        printfn "\n\tX. Exit"
        printf "\nInput: "
        let mutable input = new System.ConsoleKeyInfo()
        input <- ReadKey()

        match input.KeyChar with
            | '1' -> BurnsDepressionChecklist.Run()
            | '2' -> TripleColumnTechnique.Run()
            | 'x' | 'X' -> exit <- true
            | a -> ignore a

    0 // return an integer exit code
