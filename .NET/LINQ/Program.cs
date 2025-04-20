
public class MemoryMan
{
    public static void Main()
    {

        #region 기본

        List<Dto> dtos = new List<Dto>
        {
            new Dto{Age = 10, Name = "영수", No = 2},
            new Dto{Age = 20, Name = "영철", No = 3},
            new Dto{Age = 30, Name = "영식", No = 1}
        };

        var filter = dtos.Where((x) => x.Age == 10 || x.Age == 20); // Age 값이 10 or 20 인 데이터만 필터링

        var order = dtos.OrderBy(x => x.No); // 오름차순 정렬
        var order2 = dtos.OrderByDescending(x => x.No); // 내림차순 정렬

        var name = dtos.Select(x => x.Name); // 이름 데이터만 추출

        var index = dtos.Where((x, y) => y == 0); // index 0번째 필터링

        #endregion

    }

    public class Dto
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public int No { get; set; }
    }
}