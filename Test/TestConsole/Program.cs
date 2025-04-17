





using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;

public delegate void MM_Delegate(string message);

public class MemoryMan
{
    // 익명 함수
    public MM_Delegate mmDel = delegate (string message)
    {
        Console.WriteLine(message);
    };

    // 람다식
    public MM_Delegate mmDel2 = (message) => Console.WriteLine(message);
}

public class Program
{
    static void Main()
    {
        #region Action 
        Action del_Action1 = () => MM_Method(); 
		Action<string> del_Action2 = (a) => Console.WriteLine(a); // 파라미터 존재
        GoAction(del_Action1);
		#endregion
	}

	public static string MM_Method()
    {
        return "Hi";
    }

    public static void GoAction(Action action)
    {
        action();
    }
    
}



