
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

        public async Task<bool> DeleteAsync(int id)
        {
            var task = await _taskRepository.GetAsync(id);

            if (task == null)
            {
                return false;
            }

            await _taskRepository.DeleteAsync(task);

            return true;
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


        public async Task<GetTaskResultDto?> GetAsync(int id)
        {
            var task = await _taskRepository.GetAsync(id);

            if (task == null)
            {
                return null;
            }

            return new GetTaskResultDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
                Priority = task.Priority,
                DueDate = task.DueDate,
                CreateDate = task.CreateDate,
                UpdateDate = task.UpdateDate
            };
        }


        public async Task<UpdateTaskResultDto?> UpdateAsync(int id,UpdateTaskDto dto)
        {
            var task = await _taskRepository.GetAsync(id);

            if (task == null)
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(dto.Title) &&
                dto.Description == null &&
                dto.IsCompleted == null &&
                dto.Priority == null &&
                dto.DueDate == null)
            {
                return null;
            }

            bool hasChanges = false;

            if (!string.IsNullOrWhiteSpace(dto.Title) &&
                dto.Title != task.Title)
            {
                task.Title = dto.Title;
                hasChanges = true;
            }

            if (dto.Description != null &&
                dto.Description != task.Description)
            {
                task.Description = dto.Description;
                hasChanges = true;
            }

            if (dto.IsCompleted.HasValue &&
                task.IsCompleted != dto.IsCompleted.Value)
            {
                if (dto.IsCompleted.Value)
                {
                    task.Complete();
                }
                else
                {
                    task.Uncomplete();
                }

                hasChanges = true;
            }

            if (dto.Priority.HasValue &&
                task.Priority != dto.Priority.Value)
            {
                task.Priority = dto.Priority.Value;
                hasChanges = true;
            }

            if (dto.DueDate.HasValue &&
                task.DueDate != dto.DueDate.Value)
            {
                task.DueDate = dto.DueDate.Value;
                hasChanges = true;
            }

            if (!hasChanges)
            {
                return null;
            }

            task.MarkUpdated();

            await _taskRepository.UpdateAsync(task);

            return new UpdateTaskResultDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
                Priority = task.Priority,
                DueDate = task.DueDate,
                CreateDate = task.CreateDate,
                UpdateDate = task.UpdateDate
            };
        }
    }
}