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

let swapRecord2 (record:MyRecord) = 
    let temp = record.a
    record.a <- record.b
    record.b <- temp
    record

let record2 = swapRecord2 record
printfn "%A" record2 //This will print { a = 20; b = 20 }
printfn "%A" record  //This will also print { a = 20; b = 20 }, which is unexpected

//The issue is that in swapRecord2, we are creating a copy of the record and modifying that copy.  The original record is not modified.
//To fix this, the record passed into the function must be declared as mutable.

let swapRecord3 (record:byref<MyRecord>) = 
    let temp = record.a
    record.a <- record.b
    record.b <- temp

let mutable record3 = { a = 10; b = 20 }
swapRecord3 &record3
printfn "%A" record3 //This will print { a = 20; b = 10 } as expected
