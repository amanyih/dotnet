using System.Text.Json;

namespace Day4
{
    class StudentList<T>{
        
        public T[] Students {get; set;} = Array.Empty<T>();

        public StudentList(T[] Students){
            this.Students = Students;
        }

        public void Add(T student){
            T[] temp = new T[Students.Length + 1];
            for(int i = 0; i < Students.Length; i++){
                temp[i] = Students[i];
            }
            temp[Students.Length] = student;
            Students = temp;
        }


        public void Remove(T student){
            T[] temp = new T[Students.Length - 1];
            int j = 0;
            for(int i = 0; i < Students.Length; i++){
                if( Students[i]!.Equals(student)){
                    temp[j] = Students[i];
                    j++;
                }
            }
            Students = temp;
        }

        public void Print(){
            foreach(T student in Students){
                System.Console.WriteLine(student!.ToString());
            }
        }

        //search with linq
        public List<T> Search(string keyword){
            System.Diagnostics.Debug.Assert(keyword != null, nameof(keyword) + " != null");
            IEnumerable<T> query = from student in Students
                        where student?.ToString()?.ToLower()?.Contains(keyword.ToLower()) == true
                        select student;
            List<T> list = query.ToList();
            return list;     
        }

        //searialize to json
        public string Serialize(){
            string json = JsonSerializer.Serialize(Students);
            return json;
        }

        //deserialize from json
        public T[] Deserialize(string json){
            Students = JsonSerializer.Deserialize<T[]>(json) ?? Array.Empty<T>();

            return Students;
        }

    }}