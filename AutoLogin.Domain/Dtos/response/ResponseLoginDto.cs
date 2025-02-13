namespace AutoLogin.Domain.Dtos.response
{
    public class ResponseLoginDto
    {
        public long Id { get; set; }
        public string Identification { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string Email { get; set; }
        public string Phone_Number { get; set; }
        public int Status { get; set; }
        public string Token { get; set; }
    }
}
