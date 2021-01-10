namespace api_rest_debts.Models
{
    public class Error
    {
        public string Code { get; set; }

        public string Message { get; set; }

        public Error(string code, string message)
        {
            this.Code = code;
            this.Message = message;
        }
    }
}