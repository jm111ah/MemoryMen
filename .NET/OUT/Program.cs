


public class MemoryMan
{
    internal int Test(int width, out int height)
    {
        height = width;

        return width;
    }

    int RefTest(int width, ref int height)
    {
        return width;
    }

    internal static void Main()
    {
        #region out 기본형
        MemoryMan memory = new MemoryMan();
        var result = memory.Test(500, out int h);
        Console.WriteLine("width : {0}", result);
        Console.WriteLine("height : {0}", h);
        #endregion

        #region TryParse

        var tryParseTest = int.TryParse("123", out int tryParseResult);

        #endregion

        #region ref
        var paramRef = 200;
        memory.RefTest(100, ref paramRef);
        #endregion
    }

    class Dto
    {
        public int Seq { get; set; }
        public string Name { get; set; }

        public long MaxValue { get; set; }
        public DateTime dateTime { get; set; }
    }
}