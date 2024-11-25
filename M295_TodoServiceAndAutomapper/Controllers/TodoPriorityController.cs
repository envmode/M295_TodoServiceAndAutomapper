using M295_TodoServiceAndAutomapper.Models.DTO;
using M295_TodoServiceAndAutomapper.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace M295_TodoServiceAndAutomapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoPriorityController : ControllerBase
{
    private readonly ITodoPriorityService _todoPriorityService;

    public TodoPriorityController(ITodoPriorityService todoPriorityService)
    {
        _todoPriorityService = todoPriorityService;
    }

    // Get all Todo priorities
    // GET: api/TodoPriority
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoPriorityDTO>>> GetTodoPriorities()
    {
        IEnumerable<TodoPriorityDTO> todoPriorities = await _todoPriorityService.GetAllAsync();
        return Ok(todoPriorities);
    }

    // Get single Todo priority
    // GET: api/TodoPriority/1
    [HttpGet("{id}")]
    public async Task<ActionResult<TodoPriorityDTO>> GetTodoPriority(long id)
    {
        TodoPriorityDTO todoPriority = await _todoPriorityService.GetByIdAsync(id);

        if (todoPriority == null)
        {
            return NotFound();
        }

        return todoPriority;
    }

    // POST: Add Todo priority
    // POST: api/TodoPriority
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<TodoPriorityDTO>> PostTodoPriority(TodoPriorityDTO todoPriorityDTO)
    {
        // Service für die Erstellung nutzen
        TodoPriorityDTO todoPriority = await _todoPriorityService.CreateAsync(todoPriorityDTO);

        // Rückgabe mit CreatedAtAction
        return CreatedAtAction(
            nameof(GetTodoPriority),
            new { id = todoPriority.Id },
            todoPriority);
    }

    // Update existing TodoPriority
    // PUT: api/TodoPriority/1
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTodoPriority(long id, TodoPriorityDTO todoPriorityDTO)
    {
        if (id != todoPriorityDTO.Id)
        {
            return BadRequest();
        }

        var result = await _todoPriorityService.UpdateAsync(id, todoPriorityDTO);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    // Delete existing TodoPriority
    // DELETE: api/TodoPriority/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoPriority(long id)
    {
        bool todoPriority = await _todoPriorityService.DeleteAsync(id);

        if (todoPriority == false)
        {
            return NotFound();
        }

        return Ok();
    }
}