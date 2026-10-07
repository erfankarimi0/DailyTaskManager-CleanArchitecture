using DailyTaskManager.Application.DTOs;
using DailyTaskManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DailyTaskManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskDto dto)
        {
            var result = await _taskService.CreateAsync(dto);

            return Ok(result);
        }
    }
}