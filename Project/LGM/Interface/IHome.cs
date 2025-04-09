using LGM.Dto;
using LGM.Entity;

namespace LGM.Interface
{
    public interface IHome
    {
        public  Task<MemberEntity> SelectMember(MemberDto memberDto);

        public Task<MemberEntity> InsertMember(MemberDto memberDto);

        public Task<MemberEntity> UpdateMember(MemberDto memberDto);

        public Task<MemberEntity> DeleteMember(MemberDto memberDto);
    }
}
