

using System.Diagnostics;

public class Program
{
    public static async Task Main()
    {
        var st = Stopwatch.StartNew();

        Task t1 = Default_Hello(1);
        Task t2 = Default_Hello(2);
        Task t3 = Default_Hello(3);

        await Task.WhenAll(t1,t2, t3);

        st.Stop();
        Console.WriteLine(st.ElapsedMilliseconds);
    }

    public static async Task Default_Hello(int i)
    {
        Console.WriteLine($"{i}번째 Start");
        await Task.Delay(2000);
        Console.WriteLine($"{i}번째 End");
    }

}

