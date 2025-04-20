
#region Func
//public class MemoryMan
//{
//    public static void Main()
//    {
//        Func<int, int, int> memoryFunc = (a, b) => a + b;
//        int a = memoryFunc(1, 2);

//        int b = FuncMethod(memoryFunc(1, 1), memoryFunc(2, 2));

//        Func<int, int, int> memoryFunc2 = (a, b) => FuncMethod(a, b);

//        int result = memoryFunc2(1, 2);
//    }

//    public string ActionMethod(ActionDto dto)
//    {
//        return dto.LastName + dto.FirstName;
//    }

//    public static int FuncMethod(int a, int b)
//    {
//        return a + b;
//    }


//}

//public class ActionDto
//{
//    public string LastName { get; set; } = "";
//    public string FirstName { get; set; } = "";
//}
#endregion


#region Action

//public class Program
//{
//	static void Main()
//	{
//		int[] ints = {1,2,3,4,5,6,7,8,9 };

//		Action del_Action1 = () => MM_Method();

//		foreach (int i in ints)
//		{
//			if (i % 2 == 0)
//			{
//				GoAction(del_Action1);
//			}
//		}

//		Action<string> del_Action2 = (a) => Console.WriteLine("방가방가" +  a); 
//		del_Action2("메모리맨");
//	}

//	public static void MM_Method()
//	{
//		Console.WriteLine("Action Method");
//	}

//	public static void GoAction(Action action)
//	{
//		action();
//	}

//}
#endregion


#region Predicate

//public class MemoryMan
//{
//	public static void Main()
//	{
//		List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 }; // List 데이터 

//		Predicate<int> predicate = (x) => x % 2 == 0; // 람다식으로 Predicate 정의, 조건은 짝수 데이터일 경우 true

//		int getInt = numbers.Find(predicate); // 첫번째 짝수 추출, 결과 : 2

//		List<int> arrGetInt = numbers.FindAll(predicate); // 결과 : 2,4,6,8
//	}
//}

#endregion


#region Delegate

public class Program
{
    // 1. 델리게이트 정의
    public delegate void CallbackDelegate(string result);

    // 2. 콜백을 받는 메서드
    public static void ProcessData(int number, CallbackDelegate callback)
    {
        // 처리 로직
        string result = $"숫자 {number} 처리 완료";

        // 콜백 실행
        callback(result);
    }

    // 3. 콜백으로 사용할 메서드
    public static void ShowResult(string message)
    {
        Console.WriteLine("콜백 메시지: " + message);
    }

    public static void Main()
    {
        // 4. 콜백 전달 및 실행
        ProcessData(42, ShowResult);
    }
    }
#endregion