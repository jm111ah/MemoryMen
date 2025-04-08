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
                var result = await db.QueryFirstAsync<MemberEntity>(MemberQuery.SelectMember, param);
                return result;
            }
        }
    }
}
