
public class MemoryMan
{
    public static void Main()
    {

        #region 기본

        List<Dto> dtos = new List<Dto>
        {
            new Dto{Age = 10, Name = "영수", No = 1, Gender=0},
            new Dto{Age = 20, Name = "영철", No = 2, Gender=0},
            new Dto{Age = 30, Name = "영식", No = 3, Gender = 0},
            new Dto{Age = 31, Name = "순자", No = 4, Gender = 1},
            new Dto{Age = 29, Name = "영자", No = 5, Gender = 1},
            new Dto{Age = 40, Name = "옥순", No = 6, Gender = 1},
        };

        List<JoinDto> joinDtos = new List<JoinDto>
        {
            new JoinDto{JoinSeq = 1, JoinName = "조인_영수" },
            new JoinDto{JoinSeq = 99, JoinName = "조인_철수" },
            new JoinDto{JoinSeq = 4, JoinName = "조인_순자" },
        };



        var filter = dtos.Where((x) => x.Age == 10 || x.Age == 20); // Age 값이 10 or 20 인 데이터만 필터링

        var order = dtos.OrderBy(x => x.No); // 오름차순 정렬
        var order2 = dtos.OrderByDescending(x => x.No); // 내림차순 정렬

        var name = dtos.Select(x => x.Name); // 이름 데이터만 추출

        var index = dtos.Where((x, y) => y == 0); // index 0번째 필터링

        #endregion

        #region 메서드

        var linq_Where = dtos.Where(x => x.Age > 20); // 조건 필터링
        var linq_Select = dtos.Select(x => x.Name); // 데이터 추출
        var linq_Orderby = dtos.OrderBy(x => x.No); // 오름차순
        var linq_Orderby_Desc = dtos.OrderByDescending(x => x.No); // 내림차순
        var linq_Groupby = dtos.GroupBy(x => x.Gender); // 그룹핑
        foreach (var group in linq_Groupby)
        {
            Console.WriteLine("그룹키 : {0}",group.Key);

            foreach (var item in group)
            {
                Console.WriteLine(item.No);
                Console.WriteLine(item.Age);
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Gender);
            }
        }

        var linq_Join = dtos.Join(joinDtos, dtos => dtos.No, joinDtos => joinDtos.JoinSeq, (dtos, joinDtos) => new { dtos.Name, joinDtos.JoinName});
        foreach (var join in linq_Join)
        {
            Console.WriteLine(join.Name);
            Console.WriteLine(join.JoinName);
        }

        var linq_Any = dtos.Any(x => x.Age > 50); // 해당되는 사항 없으므로 false
        var linq_Any2 = dtos.Any(x => x.Age > 30); // 해당되는 데이터가 1개 이상이므로 true

        var linq_First = dtos.First(x => x.Age > 10); // 조건에 맞는 1번째 데이터, 데이터가 없으면 예외 발생
        var linq_FirstDefault = dtos.FirstOrDefault(x => x.Age > 50); // 조건에 맞는 1번째 데이터, 데이터가 없으면 null 처리

        var linq_single = dtos.Single(x => x.Age > 39); // 데이터가 1개만 존재해야함.
        var linq_singleDefault = dtos.SingleOrDefault(x => x.Age > 50); // 데이터가 0~1개 존재해야함.

        var linq_Distinct = dtos.Select(x => x.Gender).Distinct();

        var linq_Count = dtos.Count();
        var linq_Sum = dtos.Sum(x => x.Age);
        var linq_Average = dtos.Average(x => x.Age);
        var linq_Max = dtos.Max(x => x.Age);
        var linq_Min = dtos.Min(x => x.Age);


        #endregion

    }

    public class Dto
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public int No { get; set; }
        public int Gender { get; set; }
    }

    public class JoinDto
    {
        public int JoinSeq { get; set; }
        public string JoinName { get; set; } = "";

    }
}