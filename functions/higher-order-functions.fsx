// Anonymous function as a parameter for another function
Array2D.init 5 5 (fun x y -> if x = y then 1 else 0)

// A higher order function that calculates the time it takes to apply its first parameter (which is a function) to
// its second parameter.
let stopWatchGenerator (f : 'a -> 'b) (x : 'a) : (('a -> 'b) -> 'a -> 'b) =
    let whoRunsMe =
        System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName
        |> System.IO.Path.GetFileNameWithoutExtension
        |> sprintf "[%s]:" in
    fun f x ->
        let stopWatch = System.Diagnostics.Stopwatch() in
        try
            stopWatch.Start()
            x |> f
        finally
            printf "Took %dms in %s\n"
                stopWatch.ElapsedMilliseconds
                whoRunsMe
                
// Just a wrapper to call both the higher order function and the function it returns.
let whatItTakes f x = (stopWatchGenerator f x) f x

// The amount of time it takes to sum up the first 10 million positive numbers.
whatItTakes (fun x -> seq { 1L .. x } |> Seq.sum) 10000000L

// Gregory series
whatItTakes (fun cutOff ->
    (Seq.initInfinite (fun k -> (if k % 2 = 0 then -1.0 else 1.0)/((float k) * 2.0 - 1.0)) |> Seq.skip 1 |> Seq.take cutOff |>Seq.sum) * 4.0)
    2000000
    
// Functions as data type constituents
let apply case arg =
    match case with
    | 0 -> sin arg
    | 1 -> cos arg
    | 2 -> asin arg
    | 3 -> acos arg
    | _ -> arg
    
// Array of functions
let apply' case arg =
    try
        [| sin; cos; asin; acos |].[ case ] arg
    with
        | :? System.IndexOutOfRangeException -> arg
