
namespace BLL.Dtos
{
    public class RefreshTokenOutputDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
    }
}
