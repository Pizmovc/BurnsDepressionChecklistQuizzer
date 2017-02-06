module Console
   
   // Clear console screen
    let Clear () =
        System.Console.Clear()

    // Prints a string with a line of '----' before and after
    let fancyPrint (str:string) =
        for i = 1 to str.Length + 2 do
            printf "-"
        printfn "\n %s" str
        for i = 1 to str.Length + 2 do
            printf "-"

    let ReadKey () =
        System.Console.ReadKey(false)
        

    let PressEnter isReturn =
        match isReturn with
            | true -> printfn "\n\n\t(Press Enter to return to main menu)"
            | false -> printfn "\n\n\t(Press Enter to continue)"
        System.Console.ReadLine() |> ignore

    let ReadLine () =
        System.Console.ReadLine()