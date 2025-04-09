namespace LGM.Query
{
    public class MemberQuery
    {
        public static string SelectMember = @"select MemberSeq, MemberId, RoleId, MemberName from M_Member where MemberName = @MemberName";
        public static string InsertMember = @"insert into M_Member (MemberId, RoleId, MemberName) values(@MemberId, @RoleId, @MemberName)";
        public static string UpdateMember = @"update M_Member set MemberId = @MemberId , RoleId = @RoleId , MemberName = @MemberName where MemberSeq = @MemberSeq";
        public static string DeleteMember = @"delete M_Member where MemberSeq = @MemberSeq";
    }
}
