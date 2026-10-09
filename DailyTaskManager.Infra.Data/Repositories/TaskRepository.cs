
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


        public async System.Threading.Tasks.Task<DomainTask?> GetAsync(int id)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
            {
                return null;
            }

            return new DomainTask(
                task.Id,
                task.Title,
                task.Description,
                task.IsCompleted != 0,
                (DailyTaskManager.Domain.Enums.TaskPriority)task.Priority,
                task.DueDate,
                task.CreateDate,
                task.UpdateDate
            );
        }


        public async System.Threading.Tasks.Task UpdateAsync(DomainTask task)
        {
            var infraTask = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == task.Id);

            if (infraTask == null)
            {
                throw new InvalidOperationException($"Task with ID {task.Id} was not found.");
            }

            infraTask.Title = task.Title;
            infraTask.Description = task.Description;
            infraTask.IsCompleted = task.IsCompleted ? (sbyte)1 : (sbyte)0;
            infraTask.Priority = (int)task.Priority;
            infraTask.DueDate = task.DueDate;
            infraTask.UpdateDate = task.UpdateDate;

            await _context.SaveChangesAsync();
        }

        public System.Threading.Tasks.Task DeleteAsync(DomainTask task)
        {
            throw new NotImplementedException();
        }
    }
}