namespace LGM.Dto
{
    public class JwtDto
    {
        public string Issuer { get; set; } = "";
        public string Audience { get; set; } = "";
        public string Key { get; set; } = "";
    }
}
