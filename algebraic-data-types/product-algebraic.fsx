module Tuples =
    module Composition =
        let tuple = (1 , "2" , fun () -> 3)
        let a = 1 , "car"
        a = (1 , "car")
        tuple = (1 , "2" , fun () -> 3)
        a < (2 , "jet")
        
    module Decomposition =
        open Composition
        
        let elem1, elem2 = a
        printfn "%i %s" elem1 elem2
        let (_ , _ , f) = tuple in
        f ()
        
    module Augmentation =
        let a = 1 , "car" 
        type System.Tuple<'a , 'b> with
            member t.AsString() = sprintf "[[%A]:[%A]]" t.Item1 t.Item2 
        (a |> box :?> System.Tuple<int , string>).AsString()

module Records =
    module Composition =
        type Transport = { Code : int ; Name : string }
        let a = { Code = 1 ; Name = "car" }
        let b = { Name = "jet" ; Code = 2 }
        let c = { b with Name = "plane" }
        
    module EqualityAndComparison =
        [<ReferenceEquality>]
        type Transport = { Code : int ; Name : string }
        let x = { Code = 5 ; Name = "Boat" }
        let y = { x with Name = "Boat" }
        x = y
        x = x
    
    module Decomposition =
        open Composition
        
        let { Code = _ ; Name = aName } = a
        // or even shorter
        let { Name = aName } = a
    
    module Augmentation =
        type Configuration =
            { Database : string
              RetryCount : int }
        
        [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
        [<AutoOpen>]
        module Configuration =
            let private singleton = ref { Database = "(local)" ; RetryCount = 3 }
            let private guard = obj()
            
            type Configuration with
                static member Current
                    with get() = lock guard <| fun() -> !singleton
                    and set value = lock guard <| fun() -> singleton := value
                    
        printfn "Default start-up config: %A" Configuration.Current
        
        Configuration.Current <- { Configuration.Current with Database = ".\SQLExpress" }