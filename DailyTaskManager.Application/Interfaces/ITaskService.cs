using DailyTaskManager.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskManager.Application.Interfaces
{
    public interface ITaskService
    {
        Task<CreateTaskResultDto> CreateAsync(CreateTaskDto dto);
        Task<List<GetAllTaskResultDto>> GetAllAsync();
        Task<GetTaskResultDto?> GetAsync(int id);
        Task<UpdateTaskResultDto?> UpdateAsync(int id, UpdateTaskDto dto);

    }
}
