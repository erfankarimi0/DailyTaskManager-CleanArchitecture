using DailyTaskManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskManager.Application.DTOs
{
    public class GetAllTaskResultDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public bool IsCompleted { get; set; }

        public TaskPriority Priority { get; set; }
    }
}
