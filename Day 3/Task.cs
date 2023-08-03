namespace Day_3
{
    class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskItem TaskItem { get; set; }
        public bool IsCompleted { get; set; } = false;
        public Task(string title, string description, TaskItem taskItem)
        {
            Title = title;
            Description = description;
            TaskItem = taskItem;
        }

        public ToString()
        {
            return $"Title: {Title}\nDescription: {Description}\nTaskItem: {TaskItem}\nIsCompleted: {IsCompleted}";
        }
    }

}