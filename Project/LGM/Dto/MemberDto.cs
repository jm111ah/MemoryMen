namespace LGM.Dto
{
    public class MemberDto
    {
        public string NameIdentifier { get; set; } = "";
        public string Name { get; set; } = "";

        public string Role { get; set; } = "";

        public bool IsSuccess { get; set; }

        public int MemberSeq { get; set; }
    }
}
