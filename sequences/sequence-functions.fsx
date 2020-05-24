module Aggregates =
    //average : seq<^T> -> ^T (requires member (+) and member DivideByInt and member get_Zero)
    seq { 1. .. 4. } |> Seq.average
    //averageBy : ('T -> ^U) -> seq<'T> -> ^U (requires ^U with static member (+) and ^U with static member DivideByInt and ^U with static member Zero)
    seq { "1" ; "2" ; "3" } |> Seq.averageBy (double >> (+) 50.)
    //fold : ('State -> 'T -> 'State) -> 'State -> seq<'T> -> 'State
    seq { "X" ; "y" ; "z" ; "z" ; "y" } |> Seq.fold (fun a x -> a + (x |> function "z" -> 1 | _ -> 0)) 0
    //length : seq<'T> -> int
    seq { 1 .. 12 } |> Seq.length
    //sum : seq<^T> -> ^T (requires member (+) and member get_Zero)
    seq { 1 .. 4 } |> Seq.sum
    //sumBy : ('T -> ^U) -> seq<'T> -> ^U (requires ^U with static member (+) and 'U with static member Zero)
    seq { "1" ; "2" ; "3" ; "4" } |> Seq.sumBy (((+) "10") >> double)
    //max : seq<'T> -> 'T (requires comparison)
    seq { 11 ; 20 ; 3 } |> Seq.max
    //maxBy : ('T -> 'U) -> Seq<'T> -> 'U (requires comparison)
    seq { "11" ; "20" ; "3" } |> Seq.maxBy int
    //min : seq<'T> -> 'T (requires comparison)
    seq { "11" ; "20" ; "3" } |> Seq.min
    //minBy : ('T -> 'U) -> Seq<'T> -> 'U (requires comparison)
    seq { "11" ; "20" ; "3" } |> Seq.minBy float
    //isEmpty : seq<'T> -> bool
    Seq.isEmpty Seq.empty
    //reduce : ('T -> 'T -> 'T) -> seq<'T> -> 'T
    seq { "X" ; "y" ; "z" ; "z" ; "y" } |> Seq.reduce (fun a x -> a + x)
    //exactlyOne: seq<'T> -> 'T
    Seq.exactlyOne [ "42" ]

module Generators =
    //empty : seq<'T>
    Seq.empty
    //init : int -> (int -> 'T) -> seq<'T>
    Seq.init 5 ((*) 10)
    //initInfinite : (int -> 'T) -> seq<'T>
    Seq.initInfinite ((*) 100 >> string)
    //singleton : 'T -> seq<'T>
    seq { '*' ; '.' } |> Seq.singleton 
    //unfold : ('State -> 'T * 'State option) -> 'State -> seq<'T>
    Seq.unfold (fun current -> Some(fst current + snd current, (snd current, fst current + snd current))) (1 , 1)
    
