using LGM.Dto;

namespace LGM.Interface
{
    public interface IJWT
    {
        public Task<string> GenerateToken(MemberDto memberDto);
    }
}
