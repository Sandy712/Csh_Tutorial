// var names =new List<string> {"Sandeep","Cool","loop"};

// foreach(var name in names){
//     Console.WriteLine($"Hello {name.ToUpper()}");
// }


// Console.WriteLine($"The first element is {names[1]}");






//Using list methods
// List<int> number=new List<int>{456,123,789,369,159,357};

// number.Add(1000);
// number.Add(2000);
// number.Add(3000);

// foreach(int num in number){
//     Console.WriteLine($"The number is : {num}");
// }

// number.Remove(1000);

// foreach(int num in number){
//     Console.WriteLine($"[The number is : {num}]");
// }

// Console.WriteLine(number.Contains(123));
// Console.WriteLine(number.Contains(1000));

// Console.WriteLine($"The list has {names.Count} people in it");








// List<int> number=new List<int>{456,123,789,369,159,357};
// var index=number.IndexOf(159);

// if (index==-1){
//     Console.WriteLine($"Item is not found {index}");
// }
// else{
//     Console.WriteLine($"The number {number[index]} is at {index}");
// }


// index = number.IndexOf(15);
// if (index == -1)
// {
//     Console.WriteLine($"When an item is not found, IndexOf returns {index}");
// }
// else
// {
//     Console.WriteLine($"The name {number[index]} is at index {index}");

// }





// var name=new List<string>{"loop","Sandy","Kool","sad"};
// foreach(string i in name){
//     Console.WriteLine($"The name in list are {i}");
// }

// name.Sort();

// foreach(string i in name){
//     Console.WriteLine($"~~~The name in list are {i}~~~");
// }






// var fibonacciNumbers= new List<int> {1,1};

// var previous=fibonacciNumbers[fibonacciNumbers.Count-1];
// var previous1=fibonacciNumbers[fibonacciNumbers.Count-2];


// foreach(var item in fibonacciNumbers)
// {
//     Console.WriteLine(item);
// }

// Console.WriteLine("\t");

// fibonacciNumbers.Add(previous+previous1);

// foreach(var item in fibonacciNumbers)
// {
//     Console.WriteLine(item);
// }



var fibonacciNumbers = new List<int> { 0, 1 };
int sum = 2;

while (fibonacciNumbers.Count <21)
{
    var previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
    var previous1 = fibonacciNumbers[fibonacciNumbers.Count - 2];

    var Total=previous+previous1;
    sum+=Total;
    fibonacciNumbers.Add(Total);
}

Console.WriteLine($"20 number  of fibonacci number is : {fibonacciNumbers[20]}");
Console.WriteLine($"Total of fibonacci number is : {sum}");

foreach(int i in fibonacciNumbers){
    Console.WriteLine($"The fibonacci number in increasing order :{i}");
}





