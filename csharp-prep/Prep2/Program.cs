using System;

class Program
{
    static void Main(string[] args) {
        Console.WriteLine("What is your grade?");
        string response = Console.ReadLine();
        int grade = int.Parse(response);

        string letter = "";
        string extras = "";

        if (grade >= 90) {
            letter = "A";
        }
        else if (grade >= 80) {
            letter = "B";
        }
        else if (grade >= 70) {
            letter = "C";
        }
        else if (grade >= 60) {
            letter = "D";
        }
        else {
            letter = "F";
        }

        if ((grade % 10) >= 7) {
            extras = "+";
        }
        else if ((grade % 10) <= 10) {
            extras = "-";
        }

        Console.WriteLine($"Your grade is: {letter}{extras}");

        if (grade >= 70) {
            Console.WriteLine("You passed!");
        }
        else {
            Console.WriteLine("Better luck next time!");
        }
    }
}