using LGM.Enum;

namespace LGM.Entity
{
    public class MemberEntity
    {
        public int MemberSeq { get; set; }

        public string MemberId { get; set; } = "";

        public MemberEnum RoleId { get; set; }

        public string MemberName { get; set; } = "";
    }
}
