open System

let validate keyA keyB =
    match (keyA,keyB) with
    | ("","") -> "Both keys are empty."
    | (x,y) & (("",_) | (_,"")) -> sprintf "One key is empty. keyA: %s. keyB: %s" keyA keyB
    | _ & (x,y) -> sprintf "Both keys are NOT empty. keyA: %s. keyB: %s." keyA keyB
    
validate "" ""
validate "" "y"
validate "x" ""
validate "x" "y"