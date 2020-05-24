open System

let validate keyA keyB = (keyA, keyB) |> function
    | ("","") -> "Both keys are empty."
    | (x,y) & (("",_) | (_,"")) -> sprintf "One key is empty. keyA: %s. keyB: %s" keyA keyB
    | (x,y) when x = y -> sprintf "Both keys are equal and NOT empty: %s" x
    | _ & (x,y) -> sprintf "Both keys are NOT empty. keyA: %s. keyB: %s." keyA keyB

validate "sa" "sa"