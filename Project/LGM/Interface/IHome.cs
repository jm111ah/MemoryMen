using LGM.Dto;
using LGM.Entity;

namespace LGM.Interface
{
    public interface IHome
    {
        public  Task<MemberEntity> SelectMember(MemberDto memberDto);
    }
}
