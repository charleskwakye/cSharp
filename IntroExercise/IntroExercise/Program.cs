using System.Diagnostics;
using System;
using IntroExercise;

string courseName = "ASP .NET";
Trace.WriteLine(courseName);


const int students = 36;
Trace.WriteLine("Number of students:"+students);
Trace.WriteLine($"Number of students:{students}");

double pi = Math.PI;
Trace.WriteLine(Math.Round(pi,2)+" is the famous pi number ");
Console.WriteLine(pi);

Mymovie Mymovie= new Mymovie { };