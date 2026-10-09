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



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskService.GetAllAsync();

            return Ok(tasks);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var tasks = await _taskService.GetAsync(id);
            if (tasks != null)
            {
                return Ok(tasks);
            }
            return NotFound();
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTaskDto dto)
        {
            var result = await _taskService.UpdateAsync(id, dto);

            if (result == null)
            {
                return NotFound("تسک پیدا نشد یا تغییری برای اعمال وجود ندارد.");
            }

            return Ok(result);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _taskService.DeleteAsync(id);

            if (!result)
            {
                return NotFound("تسک موردنظر پیدا نشد.");
            }

            return NoContent();
        }
    }
}