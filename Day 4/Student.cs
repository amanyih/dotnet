namespace  Day4
{
    class Student{
        
        public string ID {get;set;}
        public string Name{get;set;}
        public int Age{get;set;}

        public  int  RollNumber{get;}

        public double Grade{get;set;}

        public Student(string id,string name,int age,int rollNumber,double grade){
            this.ID = id;
            this.Name=name;
            this.Age=age;
            this.RollNumber = rollNumber;
            this.Grade = grade;
        }

        public void ShowInfo(){
            Console.WriteLine("ID: "+this.ID);
            Console.WriteLine("Name: "+this.Name);
            Console.WriteLine("Age: "+this.Age);
            Console.WriteLine("RollNumber: "+this.RollNumber);
            Console.WriteLine("Grade: "+this.Grade);
        }

        //to string method
        public override string ToString(){
            return "ID: "+this.ID+"\nName: "+this.Name+"\nAge: "+this.Age+"\nRollNumber: "+this.RollNumber+"\nGrade: "+this.Grade;
        }
    }
}