let curriedPrint header value = printfn "%s %d" header value
let tupledPrint (header, value) = printfn "%s %d" header value

curriedPrint "The answer is" 42

tupledPrint ("The answer is", 42)

let curriedStepOne = curriedPrint "The answer is"
let curriedStepTwo = curriedStepOne 42