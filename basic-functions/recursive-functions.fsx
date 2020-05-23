// compare the behavior of:
let cutter1 s =
    let cut s = printfn "imitator cut: %s" s
    let cut (s : string) =
        if s.Length > 0 then
            printfn "real cut: %s" s
            cut s.[1..]
        else
            printfn "finished cutting"
    cut s
// with:
let cutter2 s =
    let cut s = printfn "imitator cut: %s" s
    let rec cut (s : string) =
        if s.Length > 0 then
            printfn "real cut: %s" s
            cut s.[1..]
        else
            printfn "finished cutting"
    cut s
// all that changes is the `rec` keyword
cutter1 "Noluyor?"
cutter2 "Noluyor?"
