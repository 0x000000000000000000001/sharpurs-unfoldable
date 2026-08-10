let unfoldrArrayImpl = 
    fun (isNothing: obj) -> fun (fromJust: obj) -> fun (fst: obj) -> fun (snd: obj) -> fun (f: obj) -> fun (b: obj) ->
        let isNothing' = isNothing :?> (obj -> obj)
        let fromJust' = fromJust :?> (obj -> obj)
        let fst' = fst :?> (obj -> obj)
        let snd' = snd :?> (obj -> obj)
        let f' = f :?> (obj -> obj)
        
        let result = System.Collections.Generic.List<obj>()
        let mutable value = b
        let mutable looping = true
        
        while looping do
            let maybe = f' value
            if (isNothing' maybe :?> bool) then
                looping <- false
            else
                let tuple = fromJust' maybe
                result.Add(fst' tuple)
                value <- snd' tuple
                
        result.ToArray() :> obj
