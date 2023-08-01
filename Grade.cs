using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Enter student's name: ");
        string studentName = Console.ReadLine();

        Console.Write("Enter the number of subjects: ");
        int numberOfSubjects;
        while (!int.TryParse(Console.ReadLine(), out numberOfSubjects) || numberOfSubjects <= 0)
        {
            Console.Write("Invalid input! Please enter a valid number of subjects: ");
        }

        Dictionary<string, double> subjectGrades = new Dictionary<string, double>();

        for (int i = 0; i < numberOfSubjects; i++)
        {
            Console.Write($"Enter the name of subject {i + 1}: ");
            string subjectName = Console.ReadLine();

            Console.Write($"Enter the grade for {subjectName}: ");
            double grade;
            while (!double.TryParse(Console.ReadLine(), out grade) || grade < 0 || grade > 100)
            {
                Console.Write($"Invalid input. Please enter a valid grade for {subjectName}: ");
            }
            subjectGrades.Add(subjectName, grade);
        }

        double averageGrade = CalculateAverage(subjectGrades);

        Console.WriteLine($"Student Name: {studentName}");
        foreach (var pair in subjectGrades)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
        Console.WriteLine($"Average grade: {averageGrade}");
    }

    static double CalculateAverage(Dictionary<string, double> subjectGrades)
    {
        double total = 0;
        foreach (var grade in subjectGrades.Values)
        {
            total += grade;
        }
        return total / subjectGrades.Count;
    }
}
