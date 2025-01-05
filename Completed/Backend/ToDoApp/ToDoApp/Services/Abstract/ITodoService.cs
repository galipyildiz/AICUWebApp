using ToDoApp.Dtos;
using ToDoApp.Entities;

namespace ToDoApp.Services.Abstract
{
    public interface ITodoService
    {
        Task<ResultDto<List<Todo>>> GetTodosAsync();
        Task<ResultDto<Todo>> CreateTodoAsync(CreateTodoDto dto);
        Task<ResultDto<Todo>> UpdateTodoAsync(Todo dto);
        Task<ResultDto<Todo>> DeleteTodoAsync(int id);
    }
}
