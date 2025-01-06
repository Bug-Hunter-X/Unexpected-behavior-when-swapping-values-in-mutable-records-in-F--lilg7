let mutable x = 10
let mutable y = 20

let swap x y = 
    let temp = x
    x <- y
    y <- temp

swap x y
printfn "%d %d" x y //This will print 20 20 as expected

//However, if you try to swap values in a function that modifies a mutable record, it won't work as expected.

type MyRecord = { a: int; b: int }

let mutable record = { a = 10; b = 20 }

let swapRecord record = 
    let temp = record.a
    record.a <- record.b
    record.b <- temp

swapRecord record
printfn "%A" record //This will print { a = 20; b = 20 } as expected

//But the below code won't work as expected:

let swapRecord2 (record:byref<MyRecord>) = 
    let temp = record.a
    record.a <- record.b
    record.b <- temp
    record

let mutable record2 = { a = 10; b = 20 }
let record3 = swapRecord2 &record2
printfn "%A" record3 //This will print { a = 20; b = 10 }
printfn "%A" record2  //This will also print { a = 20; b = 10 } as expected

//The issue is that in swapRecord2, we are creating a copy of the record and modifying that copy.  The original record is not modified. By using 'byref', the function will now modify the original record passed in.
