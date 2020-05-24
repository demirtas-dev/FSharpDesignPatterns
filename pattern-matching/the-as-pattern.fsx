let verifyGuid (g : string) =
    match System.Guid.TryParse g with
    | (true, _ as r) -> sprintf "%s is a genuine GUID: %A" g (snd r)
    | (_, _ as r) -> sprintf "%s is a garbage GUID, defaults to %A" g (snd r)
    
verifyGuid (System.Guid.NewGuid().ToString())
verifyGuid "SADFweasdfgaklfsdj-fasdFASDFAS-sfafsad"

