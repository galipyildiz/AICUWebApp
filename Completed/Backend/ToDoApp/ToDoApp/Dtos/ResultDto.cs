namespace ToDoApp.Dtos
{
    public class ResultDto<T> where T : class
    {
        public bool Result { get; set; }
        public T? Data { get; set; }
        public string Message { get; set; }

        public ResultDto(bool result, string message, T? data = null)
        {
            Result = result;
            Data = data;
            Message = message;
        }
    }
}
