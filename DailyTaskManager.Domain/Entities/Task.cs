using DailyTaskManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskManager.Domain.Entities
{
    public class Task
    {
        public int Id { get; set; }

        public required string Title { get; set; }

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

    }

}
