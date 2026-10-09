
using DailyTaskManager.Domain.Interfaces;
using DailyTaskManager.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using DomainTask = DailyTaskManager.Domain.Entities.Task;

namespace DailyTaskManager.Infra.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DailyTaskManagerCleanContext _context;

        public TaskRepository(DailyTaskManagerCleanContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task AddAsync(DomainTask task)
        {
            var infraTask = new Models.Task
            {
                Title = task.Title,
                Description = task.Description,
                IsCompleted = 0,
                Priority = (int)task.Priority,
                DueDate = task.DueDate
            };

            await _context.Tasks.AddAsync(infraTask);
            await _context.SaveChangesAsync();

            task.Id = infraTask.Id;
        }

        public async System.Threading.Tasks.Task<List<DomainTask>> GetAllAsync()
        {
            var tasks = await _context.Tasks.ToListAsync();

            return tasks.Select(t => new DomainTask(
                t.Id,
                t.Title,
                t.Description,
                t.IsCompleted != 0,
                (DailyTaskManager.Domain.Enums.TaskPriority)t.Priority,
                t.DueDate,
                t.CreateDate,
                t.UpdateDate
            )).ToList();
        }

        public System.Threading.Tasks.Task<DomainTask?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task UpdateAsync(DomainTask task)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task DeleteAsync(DomainTask task)
        {
            throw new NotImplementedException();
        }
    }
}