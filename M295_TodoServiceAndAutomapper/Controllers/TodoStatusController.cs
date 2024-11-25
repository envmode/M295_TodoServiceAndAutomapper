using M295_TodoServiceAndAutomapper.Models.DTO;
using M295_TodoServiceAndAutomapper.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace M295_TodoServiceAndAutomapper.Controllers;

/// <summary>
///   <br />
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TodoStatusController : ControllerBase
{
    private readonly ITodoStatusService _todoStatusService;

    public TodoStatusController(ITodoStatusService todoStatusService)
    {
        _todoStatusService = todoStatusService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoStatusDTO>>> GetTodoStatus()
    {
        IEnumerable<TodoStatusDTO> todoStatus = await _todoStatusService.GetAllAsync();

        if (todoStatus == null)
        {
            return NotFound();
        }

        return Ok(todoStatus);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TodoStatusDTO>> GetTodoStatusById(long id)
    {
        TodoStatusDTO todoStatus = await _todoStatusService.GetByIdAsync(id);

        if (todoStatus == null)
        {
            return NotFound();
        }

        return todoStatus;
    }

    [HttpPost]
    public async Task<ActionResult<TodoStatusDTO>> PostTodoStatus(TodoStatusDTO todoStatusDTO)
    {
        // Service aufrufen, um den neuen Status zu erstellen
        TodoStatusDTO todoStatus = await _todoStatusService.CreateAsync(todoStatusDTO);

        return CreatedAtAction(
            nameof(GetTodoStatus),
            new { id = todoStatus.Id },
            todoStatus);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoStatus(long id)
    {
        bool todoStatus = await _todoStatusService.DeleteAsync(id);

        if (todoStatus == false)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTodoStatus(long id, TodoStatusDTO todoStatusDTO)
    {
        {
            if (id != todoStatusDTO.Id)
            {
                return BadRequest();
            }

            var result = await _todoStatusService.UpdateAsync(id, todoStatusDTO);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}