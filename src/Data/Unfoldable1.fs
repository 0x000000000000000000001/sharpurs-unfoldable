let unfoldr1ArrayImpl = 
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
            let tuple = f' value
            result.Add(fst' tuple)
            let maybe = snd' tuple
            if (isNothing' maybe :?> bool) then
                looping <- false
            else
                value <- fromJust' maybe
                
        result.ToArray() :> obj
