namespace Crud_API.DTO
{
    public class ResponseErroDTO
    {
        public int Status { get; set; }

        public List<string> Error { get; set; }

        public string MsgError { get; set; }

    }
}
