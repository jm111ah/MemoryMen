using Dapper;
using LGM.Dto;
using LGM.Entity;
using LGM.Interface;
using LGM.Query;
using System.Data;

namespace LGM.Service
{
    public class HomeService : IHome
    {
        private readonly IDbContext _dbContext;
  
        public HomeService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MemberEntity> SelectMember(MemberDto memberDto)
        {
            using (IDbConnection db = _dbContext.GetConnection())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MemberName", memberDto.Name);
                var result = await db.QueryFirstAsync<MemberEntity>(MemberQuery.SelectMember, param);
                var query = await db.QuerySingleOrDefaultAsync<MemberEntity>(MemberQuery.SelectMember);
                return result;
            }
        }

        public async Task<MemberDto> InsertMember(MemberDto memberDto)
        {
            using (IDbConnection db = _dbContext.GetConnection())
            {
                DynamicParameters param = new DynamicParameters();
                var result = await db.ExecuteAsync(MemberQuery.InsertMember, param);
                memberDto.IsSuccess = result == 0 ? false : true;
                return memberDto;
            }
        }

        public async Task<MemberDto> UpdateMember(MemberDto memberDto)
        {
            using (IDbConnection db = _dbContext.GetConnection())
            {
                DynamicParameters param = new DynamicParameters();
                var result = await db.ExecuteAsync(MemberQuery.UpdateMember, param);
                memberDto.IsSuccess = result == 0 ? false : true;
                return memberDto;
            }
        }

        public async Task<MemberDto> DeleteMember(MemberDto memberDto)
        {
            using (IDbConnection db = _dbContext.GetConnection())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@MemberSeq", memberDto.MemberSeq);
                var result = await db.ExecuteAsync(MemberQuery.DeleteMember, param);
                memberDto.IsSuccess = result == 0 ? false : true;
                return memberDto;
            }
        }
    }
}
