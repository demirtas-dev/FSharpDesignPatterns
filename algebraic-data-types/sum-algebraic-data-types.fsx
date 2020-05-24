module DiscriminatedUnions =
    [<AutoOpen>]
    module Composition =
        type ChargeAttempt =
            | Original
            | Retry of int
            
        let cco = Original
        let ccr = Retry 4
        
        type Brightness = Brightness of int
        type Voltage = Voltage of int
        type Bulb = { brightness : Brightness ; voltage : Voltage }
        
        let myBulb = { brightness = Brightness 110 ; voltage = Voltage 2500 }
        
    [<AutoOpen>]
    module EqualityAndComparison =
        let lamp1br = Brightness 2500
        lamp1br = Brightness 2500
        lamp1br < Brightness 2100
        
    [<AutoOpen>]
    module Decomposition =
        match myBulb.brightness with
        | Brightness v -> v
    
    [<AutoOpen>]
    module Augmentation =
        type PaymentInstrumentDiscount =
            | CreditCard of decimal
            | DebitCard of decimal
            | ACH of decimal
            
            member this.ApplyDiscount payment =
                match this with
                | CreditCard discount -> payment - discount
                | DebitCard discount -> payment - discount
                | ACH discount -> payment - discount
        