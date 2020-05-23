// Simple closure example:
let simpleClosure =
    let scope = "old lexical scope"
    let enclose() =
        sprintf "%s" scope
    let scope = "new lexical scope"
    sprintf "[%s][%s]" scope (enclose())

// Another one:
let trackState seed =
    let state = ref seed in
    fun() -> incr state; !state, seed
let counter1 = trackState 1
let counter2 = trackState 100
counter1()
counter2()

// Mutable values
let mutable x = "I'm x"
let mutable y = x
y <- "I'm y"
printfn "%s | %s" x y
// Reference cells
let rx = ref "I'm rx"
let ry = rx
ry := "I'm ry"
printfn "%s | %s" !rx !ry
// Conclusion: mutable values x and y are independent. Binding a new value to one will not affect the other. Whereas
// `rx` and ry refence the same object and changing the underlying value using the reference stored in one of these
// keywords will make these changes reflect on all the references and thereby `ry` also.
