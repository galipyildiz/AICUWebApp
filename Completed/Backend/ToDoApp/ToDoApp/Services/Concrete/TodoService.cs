using Microsoft.EntityFrameworkCore;
using ToDoApp.Data;
using ToDoApp.Dtos;
using ToDoApp.Entities;
using ToDoApp.Services.Abstract;

namespace ToDoApp.Services.Concrete
{
    public class TodoService(DatabaseContext databaseContext) : ITodoService
    {
        public async Task<ResultDto<Todo>> CreateTodoAsync(CreateTodoDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Content))
                return new ResultDto<Todo>(false, "Content can not be empty");

            try
            {
                var newTodo = new Todo
                {
                    Content = dto.Content,
                    IsCompleted = false
                };

                await databaseContext.AddAsync(newTodo);
                await databaseContext.SaveChangesAsync();
                return new ResultDto<Todo>(true, "", newTodo);
            }
            catch (Exception ex)
            {
                return new ResultDto<Todo>(false, ex.Message);
            }
        }

        public async Task<ResultDto<Todo>> DeleteTodoAsync(int id)
        {
            try
            {
                var existTodo = await databaseContext.Todos.FirstOrDefaultAsync(x => x.Id.Equals(id));
                if (existTodo == null)
                    return new ResultDto<Todo>(false, "Todo not found");

                databaseContext.Todos.Remove(existTodo);
                await databaseContext.SaveChangesAsync();
                return new ResultDto<Todo>(true, "", null);
            }
            catch (Exception ex)
            {
                return new ResultDto<Todo>(false, ex.Message);
            }
        }

        public async Task<ResultDto<List<Todo>>> GetTodosAsync()
        {
            try
            {
                var todos = await databaseContext.Todos.ToListAsync();
                if (todos == null)
                    return new ResultDto<List<Todo>>(false, "Todos not found");

                return new ResultDto<List<Todo>>(true, "", todos);
            }
            catch (Exception ex)
            {
                return new ResultDto<List<Todo>>(false, ex.Message);
            }
        }

        public async Task<ResultDto<Todo>> UpdateTodoAsync(Todo dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Content))
                return new ResultDto<Todo>(false, "Content can not be empty");

            try
            {
                var existTodo = await databaseContext.Todos.FirstOrDefaultAsync(x => x.Id.Equals(dto.Id));
                if (existTodo == null)
                    return new ResultDto<Todo>(false, "Todo not found");

                existTodo.Content = dto.Content;
                existTodo.IsCompleted = dto.IsCompleted;

                databaseContext.Todos.Update(existTodo);
                await databaseContext.SaveChangesAsync();
                return new ResultDto<Todo>(true, "", existTodo);
            }
            catch (Exception ex)
            {
                return new ResultDto<Todo>(false, ex.Message);
            }
        }
    }
}
