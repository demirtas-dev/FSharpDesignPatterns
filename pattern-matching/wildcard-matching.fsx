type Multiples =
    | Zero = 0
    | One = 1

let transform m =
    match m with
    | Multiples.Zero -> Some "0"
    | Multiples.One -> Some "1"
    | _ -> None