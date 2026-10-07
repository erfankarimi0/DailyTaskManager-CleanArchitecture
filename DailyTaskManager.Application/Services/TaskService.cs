using DailyTaskManager.Application.DTOs;
using DailyTaskManager.Application.Interfaces;
using DailyTaskManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskManager.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<CreateTaskResultDto> CreateAsync(CreateTaskDto dto)
        {
            var task = new DailyTaskManager.Domain.Entities.Task
            {
                Title = dto.Title,
                Description = dto.Description,
                Priority = dto.Priority,
                DueDate = dto.DueDate
            };
            await _taskRepository.AddAsync(task);

            return new CreateTaskResultDto
            {
                Id = task.Id,
                Message = "تسک با موفقیت ایجاد شد."
            };
        }
    }
}
