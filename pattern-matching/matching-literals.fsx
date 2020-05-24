[<Literal>]
let THREE = 3

let transformA v =
    match v with
    | 1 -> "1"
    | 2 -> "2"
    | THREE -> "3"
    
transformA (1 + 2)

type Multiples =
    | Zero = 0
    | Five = 5

let transformB ``compare me`` =
    match ``compare me`` with
    | Multiples.Zero -> "0"
    | Multiples.Five -> "5"

transformB Multiples.Five