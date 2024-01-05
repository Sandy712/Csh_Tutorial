// // // string[] names={
// // //     "Bill",
// // //     "steve",
// // //     "James",
// // //     "Mohan"
// // // };

// // // var mylinq=from name in names
// // //         where name.Contains('a')
// // //         select name;

// // // foreach(var name in mylinq)
// // // {
// // //     Console.Write(name+" ");
// // // }


// // IList<string> stringlist =new List<string>()
// // {
// //     "C# tut",
// //     "Vb.net",
// //     "laern C.Net",
// //     "Mvc tot",
// //     "Java"
// // };

// // var res=from s in stringlist
// //         where s.Contains("tut")
// //         select s;

// // foreach(string i in res)
// // {
// //     Console.WriteLine(i);
// // }    


// IList<string> stringList = new List<string>{
//     "C# tutorials",
//     "Vb.NET tutorial",
//     "Learn C++",
//     "MVC tutorials",
//     "JAva"
// };

// var result = stringList.Where(s => s.Contains("tutorials"));

// foreach (string i in result)
// {
//     Console.WriteLine(i);
// }


using System;
using System.Linq;
using System.Collections.Generic;


public class Student
{

    public int StudentID { get; set; }
    public string StudentName { get; set; }
    public int Age { get; set; }

}

public class ProgramP
{
    public static void Main()
    {
        // Student collection
        IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 21} ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };

        // LINQ Query Syntax to find out teenager students

        var teenAgerStudent = studentList.OrderByDescending(s => s.StudentName);
        Console.WriteLine("Teen age Students:");

        foreach (Student std in teenAgerStudent)
        {
            Console.WriteLine(std.StudentName);
        }
        Console.WriteLine("\nOrder by name as well as ID");

        var teen = studentList.OrderBy(s => s.StudentName).OrderBy(s => s.StudentID);

        foreach (Student std in teen)
        {
            Console.WriteLine(std.StudentName);
        }

        Console.WriteLine("\nUse of Thenby LINq");

        var thenByResult = studentList.OrderBy(s => s.StudentName).ThenBy(s => s.Age);

        foreach (Student std in thenByResult)
        {
            Console.WriteLine("Name: {0}, AGE:{1}", std.StudentName, std.StudentID);
        }



        Console.WriteLine("\nUse of Group by LINQ");

        var groupedResult = from s in studentList
                            group s by s.Age;

        //iterate each group        
        foreach (var ageGroup in groupedResult)
        {
            Console.WriteLine("\nAge Group: {0}", ageGroup.Key); //Each group has a key 

            foreach (Student s in ageGroup) // Each group has inner collection
                Console.WriteLine("Student Name: {0}", s.StudentName);
        }


        Console.WriteLine("\nUSe of select operator");
        var selectResult = from s in studentList
                           select new { Name = "Mr. " + s.StudentName, Age = s.Age };

        // iterate selectResult
        foreach (var item in selectResult)
            Console.WriteLine("Student Name: {0}, Age: {1}", item.Name, item.Age);
    }
}