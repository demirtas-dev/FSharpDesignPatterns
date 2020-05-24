// Some cases where types are obvious and type annotation is unnecessary.
let s = "I'm a string"
let dict = System.Collections.Generic.Dictionary<string, string list>()
let gameOutcome isWin = "you " + if isWin then "win" else "lose"

// A case where type inference fails:
let truncator limit (s : string) =
    if s.Length > limit
    then s.Substring(0, limit)
    else s

// A more complicated example
let logAndTrash ss =
    let log = System.Text.StringBuilder()
    for s in ss do
        printf "%A" s |> log.AppendLine |> ignore
    (ss :> System.IDisposable).Dispose()
    log
//... in this case compiler infers the type of this function as:
// 'a -> System.Text.StringBuilder when 'a :> seq<'b> and a :> System.IDisposable
