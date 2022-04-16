namespace Filter.DAL
{
    public class ServiceResponse<T>
    {
        #region Properties
        public bool IsSuccess { get; set; } = true;
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }
        #endregion
    }
}
