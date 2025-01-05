using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Dtos;
using ToDoApp.Entities;
using ToDoApp.Services.Abstract;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TodosController(ITodoService todoService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<Todo>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResultDto<List<Todo>>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTodos()
        {
            var response = await todoService.GetTodosAsync();
            if (response.Result)
                return Ok(response.Data);

            return new BadRequestObjectResult(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Todo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResultDto<Todo>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateTodo(CreateTodoDto dto)
        {
            var response = await todoService.CreateTodoAsync(dto);
            if (response.Result)
                return Ok(response.Data);

            return new BadRequestObjectResult(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Todo), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResultDto<Todo>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateTodo(Todo dto)
        {
            var response = await todoService.UpdateTodoAsync(dto);
            if (response.Result)
                return Ok(response.Data);

            return new BadRequestObjectResult(response);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResultDto<Todo>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var response = await todoService.DeleteTodoAsync(id);
            if (response.Result)
                return NoContent();

            return new BadRequestObjectResult(response);
        }
    }
}
