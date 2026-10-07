using DailyTaskManager.Domain.Interfaces;
using DailyTaskManager.Infra.Data.Context;

namespace DailyTaskManager.Infra.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DailyTaskManagerCleanContext _context;

        public TaskRepository(DailyTaskManagerCleanContext context)
        {
            _context = context;
        }
        public async System.Threading.Tasks.Task AddAsync(Domain.Entities.Task task)
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

        public System.Threading.Tasks.Task DeleteAsync(Domain.Entities.Task task)
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Entities.Task>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Task?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task UpdateAsync(Domain.Entities.Task task)
        {
            throw new NotImplementedException();
        }
    }
}