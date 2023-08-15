// See https://aka.ms/new-console-template for more information

namespace Day4
{

    class Program{
        static void Main(string[] args){
            Student student = new("UG", "Jhn", 19, 5, 3.5);
            Student student2 = new("UGR", "John", 20, 9, 3.5);

            StudentList<Student> studentList = new(new Student[2] { student, student2 });
            
            studentList.Add(new Student("UGR", "John", 20, 9, 3.5));
            studentList.Add(new Student("UGR", "John", 20, 9, 3.5));

            // studentList.Remove(student2);

            studentList.Print();
            
        }
    }
    
}
