using DailyTaskManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskManager.Application.DTOs
{
    public class CreateTaskDto
    {
        [Required]
        [StringLength(45)]
        public required string Title { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public TaskPriority Priority { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
