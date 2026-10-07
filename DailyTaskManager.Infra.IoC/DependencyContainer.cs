using DailyTaskManager.Application.Interfaces;
using DailyTaskManager.Application.Services;
using DailyTaskManager.Domain.Interfaces;
using DailyTaskManager.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DailyTaskManager.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Infra Data Layer
            services.AddScoped<ITaskRepository, TaskRepository>();

            // Application Layer
            services.AddScoped<ITaskService, TaskService>();
        }
    }
}