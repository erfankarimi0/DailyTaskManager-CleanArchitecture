using DailyTaskManager.Domain.Enums;

namespace DailyTaskManager.Domain.Entities
{
    public class Task
    {
        public Task(
    int id,
    string title,
    string? description,
    bool isCompleted,
    TaskPriority priority,
    DateTime? dueDate,
    DateTime createDate,
    DateTime? updateDate)
        {
            Id = id;
            Title = title;
            Description = description;
            IsCompleted = isCompleted;
            Priority = priority;
            DueDate = dueDate;
            CreateDate = createDate;
            UpdateDate = updateDate;
        }


        public int Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public bool IsCompleted { get; private set; }

        public TaskPriority Priority { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime CreateDate { get; private set; }

        public DateTime? UpdateDate { get; private set; }

        public void Complete()
        {
            IsCompleted = true;
            UpdateDate = DateTime.UtcNow;
        }

        public void Uncomplete()
        {
            IsCompleted = false;
            UpdateDate = DateTime.UtcNow;
        }

        public void MarkUpdated()
        {
            UpdateDate = DateTime.UtcNow;
        }

    }

}