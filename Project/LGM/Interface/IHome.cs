using LGM.Dto;
using LGM.Entity;

namespace LGM.Interface
{
    public interface IHome
    {
        public  Task<MemberEntity> SelectMember(MemberDto memberDto);

        public Task<MemberDto> InsertMember(MemberDto memberDto);

        public Task<MemberDto> UpdateMember(MemberDto memberDto);

        public Task<MemberDto> DeleteMember(MemberDto memberDto);
    }
}
