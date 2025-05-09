


#region 1번문제

class Result
{

    /*
     * Complete the 'finalState' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts 2D_INTEGER_ARRAY operations as parameter.
     */

    public static long finalState(List<List<int>> operations)
    {
        int maxIndex = 100001;
        int[] diff = new int[maxIndex + 2];

        foreach (var item in operations)
        {
            int first = item[0];
            int second = item[1];
            diff[first] += 1;
            diff[second + 1] -= 1;
        }

        long sum = 0;
        int current = 0;


        for (int i = 1; i <= 100000; i++)
        {
            current += diff[i];
            if (Math.Abs(current) % 2 == 1)
                sum += i;
        }

        return sum;
    }

}

class Solution
{
    public static void Main()
    {
        int operationsRows = Convert.ToInt32(Console.ReadLine().Trim());
        int operationsColumns = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> operations = new List<List<int>>();

        for (int i = 0; i < operationsRows; i++)
        {
            operations.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(operationsTemp => Convert.ToInt32(operationsTemp)).ToList());
        }

        long result = Result.finalState(operations);

        Console.WriteLine(result);

    }
}


#endregion