namespace Day_3
{
    class TaskManager
    {
        public List<Task> Tasks { get; set; } = new List<Task>();
        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }
        public void RemoveTask(Task task)
        {
            Tasks.Remove(task);
        }
        public void PrintAllTasks()
        {
            foreach (var task in Tasks)
            {
                Console.WriteLine(task.ToString());
            }
        }
        public void PrintPendingTasks()
        {
            var pendingTasks = Tasks.Where(task => task.IsCompleted == false).ToList();
            for (int i = 0; i < pendingTasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pendingTasks[i].ToString()}");
            }
        }

        public void PrintTasksByType()
        {
            Console.WriteLine("1. Personal");
            Console.WriteLine("2. Work");
            Console.WriteLine("3. Shopping");
            Console.WriteLine("4. Others");
            Console.WriteLine("Enter your choice: ");
            var choice = int.Parse(Console.ReadLine());
            var taskItem = (TaskItem)choice - 1;
            var tasks = Tasks.Where(task => task.TaskItem == taskItem).ToList();
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i].ToString()}");
            }
        }

        public void PrintCompletedTasks()
        {
            var completedTasks = Tasks.Where(task => task.IsCompleted == true).ToList();
            for (int i = 0; i < completedTasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {completedTasks[i].ToString()}");
            }
        }

        public void viewTasks(){
            
            Console.WriteLine("1. View All Tasks");
            Console.WriteLine("2. View Completed Tasks");
            Console.WriteLine("3. View Pending Tasks");
            Console.WriteLine("4. View Tasks By Type");

            Console.WriteLine("Enter your choice: ");
            var choice = int.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    PrintTasks();
                    break;
                case 2:
                    PrintCompletedTasks();
                    break;
                case 3:
                    PrintPendingTasks();
                    break;
                case 4:
                    PrintTasksByType();
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }

        }

        public void loadTasks()
        {
            try{
            using (var reader = new StreamReader("tasks.csv"))
            {
       
                reader.ReadLine();
               
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    var title = values[0];
                    var description = values[1];
                    var taskItem = (TaskItem)Enum.Parse(typeof(TaskItem), values[2]);
                    var isCompleted = bool.Parse(values[3]);
                    var task = new Task(title, description, taskItem);
                    task.IsCompleted = isCompleted;
                    Tasks.Add(task);
                }
            }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void saveTasks()
        {
            try{

            using (var writer = new StreamWriter("tasks.csv"))
            {
                
                writer.WriteLine("Title,Description,TaskItem,IsCompleted");
            
                foreach (var task in Tasks)
                {
                    writer.WriteLine($"{task.Title},{task.Description},{task.TaskItem},{task.IsCompleted}");
                }
            }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}