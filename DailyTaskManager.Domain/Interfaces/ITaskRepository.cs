using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailyTaskManager.Domain.Entities;
using DomainTask = DailyTaskManager.Domain.Entities.Task;

namespace DailyTaskManager.Domain.Interfaces
    //تسک ها قاطی شدن
{
    public interface ITaskRepository
    {
        System.Threading.Tasks.Task AddAsync(DomainTask task);

        System.Threading.Tasks.Task<DomainTask?> GetAsync(int id);

        System.Threading.Tasks.Task<List<DomainTask>> GetAllAsync();

        System.Threading.Tasks.Task UpdateAsync(DomainTask task);

        System.Threading.Tasks.Task DeleteAsync(DomainTask task);
    }
}