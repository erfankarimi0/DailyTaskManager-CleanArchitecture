
using DailyTaskManager.Application.DTOs;
using DailyTaskManager.Application.Interfaces;
using DailyTaskManager.Domain.Enums;
using DailyTaskManager.Domain.Interfaces;

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
            var task = new DailyTaskManager.Domain.Entities.Task(
                id: 0,
                title: dto.Title,
                description: dto.Description,
                isCompleted: false,
                priority: dto.Priority,
                dueDate: dto.DueDate,
                createDate: DateTime.UtcNow,
                updateDate: null
            );

            await _taskRepository.AddAsync(task);

            return new CreateTaskResultDto
            {
                Id = task.Id,
                Message = "تسک با موفقیت ایجاد شد."
            };
        }

        public async Task<List<GetAllTaskResultDto>> GetAllAsync()
        {
            var tasks = await _taskRepository.GetAllAsync();

            return tasks.Select(task => new GetAllTaskResultDto
            {
                Id = task.Id,
                Title = task.Title,
                IsCompleted = task.IsCompleted,
                Priority = task.Priority
            }).ToList();
        }
    }
}