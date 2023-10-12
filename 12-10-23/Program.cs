
// int a = 18;
// int b = 6;
// int c = a + b;
// Console.WriteLine(c);

// int d = a / b;
// Console.WriteLine(d);

// int e = (a + b) - 6 * c + (12 * 4) / 3 + 12;
// Console.WriteLine(e);

// int f = (a + b) / c;
// Console.WriteLine(f);




//Precision Integer

// int a=7;
// int b=4;
// int c=3;
// int d=(a+b)/c;
// int e=(a+b)%c;

// Console.WriteLine($"Quotient: {d}");
// Console.WriteLine($"Remainder: {e}");

// int max=int.MaxValue;
// int min=int.MinValue;

// Console.WriteLine($"The range of integer is {min} to {max}");

// int what = max + 3;
// Console.WriteLine($"An example of overflow: {what}");


//Double Type

// double a = 5;
// double b = 4;
// double c = 2;
// double d = (a + b) / c;
// Console.WriteLine(d);

// double p=19;
// double o=23;
// double i=8;
// double u=(p+o)/i;
// Console.WriteLine(u);

// double max=double.MaxValue;
// double min=double.MinValue;
// Console.WriteLine($"The range of double is {min} to {max}");

//Decimal types

// decimal min = decimal.MinValue;
// decimal max = decimal.MaxValue;
// Console.WriteLine($"The range of the decimal type is {min} to {max}");

// double a = 1.0;
// double b = 3.0;
// Console.WriteLine(a / b);

// decimal c = 1.0M;
// decimal d = 3.0M;
// Console.WriteLine(c / d);


//Find area of cicle

// double radius=2.50;
// double area=Math.PI*radius*radius;

// Console.WriteLine(area);



//Branches and loop

// int a=5;
// int b=3;

// if (a+b<10){
//     Console.WriteLine("The answer is smaller than 10");
// }

// int l=5;
// int o=80;
// if(l+o<50){
//     Console.WriteLine("The answer is smaller than 50");
// }
// else{
//     Console.WriteLine("The answer is greater than 50");
// }

// int a = 5;
// int b = 3;
// int c = 4;
// if ((a + b + c > 10) && (a == b))
// {
//     Console.WriteLine("The answer is greater than 10");
//     Console.WriteLine("And the first number is equal to the second");
// }
// else
// {
//     Console.WriteLine("The answer is not greater than 10");
//     Console.WriteLine("Or the first number is not equal to the second");
// }

// int a = 5;
// int b = 5;
// int c = 4;
// if ((a + b + c > 10) || (a == b))
// {
//     Console.WriteLine("The answer is greater than 10");
//     Console.WriteLine("Or the first number is equal to the second");
// }
// else
// {
//     Console.WriteLine("The answer is not greater than 10");
//     Console.WriteLine("And the first number is not equal to the second");
// }



// int op=0;
// while (op<5){
//     Console.WriteLine($"The iteration is {op}");
//     op++;
// }

// int lp=12;
// do{
//     Console.WriteLine("Today day is "+lp);
//     lp--;
// }while(lp!=3);


// for(int counter=0;counter<10;counter++){
//     Console.WriteLine("Iteration is going on "+counter);
// }

// for (int row=1;row<11;row++)
// {
//     Console.WriteLine($"The row is {row}");
// }

// for (char col='a';col<'k';col++){
//     Console.WriteLine($"The column us {col}");
// }


// for (int row = 1; row < 11; row++)
// {
//     for (char col = 'a'; col < 'k'; col++)
//     {
//         Console.WriteLine($"The cell ss ({row},{col})");
//     }
// }

int sum=0;

for(int num=1;num<=20;num++){
    if(num%3==0){
        sum+=num;
    }
}

Console.WriteLine($"The final sum is {sum}");