namespace Day_3{

    class Program{

        static void Main(string[] args){

            Task task1 = new Task {
                Title = "Task 1",
                Description = "Description 1",
                TaskItem = TaskItem.Personal
            };

            Task task2 = new Task {
                Title = "Task 2",
                Description = "Description 2",
                TaskItem = TaskItem.Work
            };

            Task task3 = new Task {
                Title = "Task 3",
                Description = "Description 3",
                TaskItem = TaskItem.Shopping
            };

            TaskManager taskManager = new TaskManager();

            taskManager.AddTask(task1);
            taskManager.AddTask(task2);
            taskManager.AddTask(task3);

            taskManager.PrintAllTasks();
            taskManager.viewTasks();


        }
    }
}
