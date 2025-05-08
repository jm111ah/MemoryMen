#region 1번문제

//class Result
//{

//    /*
//     * Complete the 'finalState' function below.
//     *
//     * The function is expected to return a LONG_INTEGER.
//     * The function accepts 2D_INTEGER_ARRAY operations as parameter.
//     */

//    public static long finalState(List<List<int>> operations)
//    {
//        int maxIndex = 100001;
//        int[] diff = new int[maxIndex + 2];

//        foreach (var item in operations)
//        {
//            int first = item[0];
//            int second = item[1];
//            diff[first] += 1;
//            diff[second + 1] -= 1;
//        }

//        long sum = 0;
//        int current = 0;


//        for (int i = 1; i <= 100000; i++)
//        {
//            current += diff[i];
//            if (Math.Abs(current) % 2 == 1)
//                sum += i;
//        }

//        return sum;
//    }

//}

//class Solution
//{
//    public static void Main()
//    {

//        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

//        int operationsRows = Convert.ToInt32(Console.ReadLine().Trim());
//        int operationsColumns = Convert.ToInt32(Console.ReadLine().Trim());

//        List<List<int>> operations = new List<List<int>>();

//        for (int i = 0; i < operationsRows; i++)
//        {
//            operations.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(operationsTemp => Convert.ToInt32(operationsTemp)).ToList());
//        }

//        long result = Result.finalState(operations);

//        Console.WriteLine(result);

//        //textWriter.WriteLine(result);

//        //textWriter.Flush();
//        //textWriter.Close();
//    }
//}


#endregion


#region 2번 문제
//class Result
//{

//    public static List<int> sortBinaryNumbers(List<List<int>> bitArrays)
//    {

//        var indexedBits = new List<(int Index, List<int> Bits)>();

//        for (int i = 0; i < bitArrays.Count; i++)
//        {
//            var sortedBits = bitArrays[i].OrderByDescending(b => b).ToList(); 
//            indexedBits.Add((i, sortedBits));
//        }

//        indexedBits.Sort((a, b) =>
//        {
//            int len = Math.Min(a.Bits.Count, b.Bits.Count);
//            for (int i = 0; i < len; i++)
//            {
//                if (a.Bits[i] != b.Bits[i])
//                    return b.Bits[i].CompareTo(a.Bits[i]); 
//            }
//            return b.Bits.Count.CompareTo(a.Bits.Count); 
//        });

//        return indexedBits.Select(x => x.Index).ToList();
//    }

//}

//class Solution
//{
//    public static void Main(string[] args)
//    {
//        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

//        int bitArraysRows = Convert.ToInt32(Console.ReadLine().Trim());
//        int bitArraysColumns = Convert.ToInt32(Console.ReadLine().Trim());

//        List<List<int>> bitArrays = new List<List<int>>();

//        for (int i = 0; i < bitArraysRows; i++)
//        {
//            bitArrays.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(bitArraysTemp => Convert.ToInt32(bitArraysTemp)).ToList());
//        }

//        List<int> result = Result.sortBinaryNumbers(bitArrays);

//        Console.WriteLine(String.Join("\n", result));

//        //textWriter.WriteLine(String.Join("\n", result));

//        //textWriter.Flush();
//        //textWriter.Close();
//    }
//}

#endregion


#region 3번 문제

//class Result
//{

//    /*
//     * Complete the 'teamFormation' function below.
//     *
//     * The function is expected to return a LONG_INTEGER.
//     * The function accepts following parameters:
//     *  1. INTEGER_ARRAY score
//     *  2. INTEGER team_size
//     *  3. INTEGER k
//     */

//    public static long teamFormation(List<int> score, int team_size, int k)
//    {
//        int n = score.Count;
//        long total = 0;

//        var used = new HashSet<int>();

//        var leftHeap = new PriorityQueue<(int score, int index), (int negScore, int index)>();
//        var rightHeap = new PriorityQueue<(int score, int index), (int negScore, int index)>();

//        int l = 0, r = n - 1;

//        int leftCount = 0, rightCount = 0;
//        while (leftCount < k && l <= r)
//        {
//            leftHeap.Enqueue((score[l], l), (-score[l], l));
//            l++;
//            leftCount++;
//        }

//        while (rightCount < k && r >= l)
//        {
//            rightHeap.Enqueue((score[r], r), (-score[r], r));
//            r--;
//            rightCount++;
//        }

//        for (int t = 0; t < team_size; t++)
//        {
//            while (leftHeap.Count > 0 && used.Contains(leftHeap.Peek().index)) leftHeap.Dequeue();
//            while (rightHeap.Count > 0 && used.Contains(rightHeap.Peek().index)) rightHeap.Dequeue();

//            (int score, int index) leftTop = leftHeap.Count > 0 ? leftHeap.Peek() : (-1, -1);
//            (int score, int index) rightTop = rightHeap.Count > 0 ? rightHeap.Peek() : (-1, -1);

//            (int score, int index) selected;
//            if (Compare(leftTop, rightTop) <= 0)
//            {
//                selected = leftHeap.Dequeue();
//                used.Add(selected.index);

//                if (l <= r)
//                {
//                    leftHeap.Enqueue((score[l], l), (-score[l], l));
//                    l++;
//                }
//            }
//            else
//            {
//                selected = rightHeap.Dequeue();
//                used.Add(selected.index);

//                if (l <= r)
//                {
//                    rightHeap.Enqueue((score[r], r), (-score[r], r));
//                    r--;
//                }
//            }

//            total += selected.score;
//        }

//        return total;
//    }

//    private static int Compare((int score, int index) a, (int score, int index) b)
//    {
//        if (a.score != b.score)
//            return b.score.CompareTo(a.score);
//        return a.index.CompareTo(b.index);
//    }

//}

//class Solution
//{
//    public static void Main(string[] args)
//    {
//        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

//        int scoreCount = Convert.ToInt32(Console.ReadLine().Trim());

//        List<int> score = new List<int>();

//        for (int i = 0; i < scoreCount; i++)
//        {
//            int scoreItem = Convert.ToInt32(Console.ReadLine().Trim());
//            score.Add(scoreItem);
//        }

//        int team_size = Convert.ToInt32(Console.ReadLine().Trim());

//        int k = Convert.ToInt32(Console.ReadLine().Trim());

//        long result = Result.teamFormation(score, team_size, k);

//        textWriter.WriteLine(result);

//        textWriter.Flush();
//        textWriter.Close();
//    }
//}

#endregion

#region 4번 문제

class Result
{

    /*
     * Complete the 'findBreakDuration' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     *  3. INTEGER t
     *  4. INTEGER_ARRAY start
     *  5. INTEGER_ARRAY finish
     */

    public static int findBreakDuration(int n, int k, int t, List<int> start, List<int> finish)
    {
        int N = n + 1;
        int windowSize = Math.Min(k + 1, N);
        var g = new long[N];
        g[0] = start[0];
        for (int i = 1; i < n; i++)
            g[i] = start[i] - finish[i - 1];
        g[n] = t - finish[n - 1];

        long curr = 0;
        for (int i = 0; i < windowSize; i++)
            curr += g[i];
        long best = curr;
        for (int i = windowSize; i < N; i++)
        {
            curr += g[i] - g[i - windowSize];
            if (curr > best) best = curr;
        }

        return (int)best;
    }

}
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        int startCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> start = new List<int>();

        for (int i = 0; i < startCount; i++)
        {
            int startItem = Convert.ToInt32(Console.ReadLine().Trim());
            start.Add(startItem);
        }

        int finishCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> finish = new List<int>();

        for (int i = 0; i < finishCount; i++)
        {
            int finishItem = Convert.ToInt32(Console.ReadLine().Trim());
            finish.Add(finishItem);
        }

        int result = Result.findBreakDuration(n, k, t, start, finish);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

#endregion

#region 5번 문제

//class Result
//{

//    /*
//     * Complete the 'getMinimumCost' function below.
//     *
//     * The function is expected to return a LONG_INTEGER.
//     * The function accepts following parameters:
//     *  1. INTEGER_ARRAY cost
//     *  2. INTEGER minWeight
//     */

//    public static long getMinimumCost(List<int> cost, int minWeight)
//    {
//        int n = cost.Count;
//        long[] c = new long[n];
//        for (int i = 0; i < n; i++) c[i] = cost[i];
//        for (int i = 1; i < n; i++)
//        {
//            c[i] = Math.Min(c[i], 2 * c[i - 1]);
//        }
//        long ans = long.MaxValue;
//        long total = 0;
//        long rem = minWeight;
//        for (int i = n - 1; i >= 0; i--)
//        {
//            long w = 1L << i;
//            long cnt = rem / w;
//            if (cnt > 0)
//            {
//                total += cnt * c[i];
//                rem -= cnt * w;
//            }
//            if (rem > 0) ans = Math.Min(ans, total + c[i]);
//            else ans = Math.Min(ans, total);
//        }
//        return ans;
//    }

//}

//class Solution
//{
//    public static void Main(string[] args)
//    {
//        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

//        int costCount = Convert.ToInt32(Console.ReadLine().Trim());

//        List<int> cost = new List<int>();

//        for (int i = 0; i < costCount; i++)
//        {
//            int costItem = Convert.ToInt32(Console.ReadLine().Trim());
//            cost.Add(costItem);
//        }

//        int minWeight = Convert.ToInt32(Console.ReadLine().Trim());

//        long result = Result.getMinimumCost(cost, minWeight);

//        textWriter.WriteLine(result);

//        textWriter.Flush();
//        textWriter.Close();
//    }
//}

#endregion

#region 6번 문제

//class Result
//{

//    /*
//     * Complete the 'classifyEdges' function below.
//     *
//     * The function is expected to return a STRING_ARRAY.
//     * The function accepts WEIGHTED_INTEGER_GRAPH g as parameter.
//     */

//    /*
//     * For the weighted graph, <name>:
//     *
//     * 1. The number of nodes is <name>Nodes.
//     * 2. The number of edges is <name>Edges.
//     * 3. An edge exists between <name>From[i] and <name>To[i]. The weight of the edge is <name>Weight[i].
//     *
//     */

//    public static List<string> classifyEdges(int gNodes, List<int> gFrom, List<int> gTo, List<int> gWeight)
//    {
//        int n = gNodes, m = gFrom.Count;
//        var adj = new List<(int to, int w)>[n + 1];
//        for (int i = 1; i <= n; i++) adj[i] = new List<(int, int)>();
//        for (int i = 0; i < m; i++)
//        {
//            int u = gFrom[i], v = gTo[i], w = gWeight[i];
//            adj[u].Add((v, w));
//            adj[v].Add((u, w));
//        }

//        const long INF = long.MaxValue / 4;
//        var dist1 = new long[n + 1];
//        var dist2 = new long[n + 1];
//        for (int i = 1; i <= n; i++) { dist1[i] = INF; dist2[i] = INF; }

//        Dijkstra(1, dist1, adj);
//        Dijkstra(n, dist2, adj);

//        long best = dist1[n];
//        var result = new List<string>(m);

//        for (int i = 0; i < m; i++)
//        {
//            int u = gFrom[i], v = gTo[i], w = gWeight[i];
//            bool onShortest = (dist1[u] + w + dist2[v] == best) ||
//                            (dist1[v] + w + dist2[u] == best);
//            result.Add(onShortest ? "YES" : "NO");
//        }

//        return result;
//    }


//    private static void Dijkstra(int src, long[] dist, List<(int to, int w)>[] adj)
//    {
//        var pq = new PriorityQueue<(int node, long d), long>();
//        dist[src] = 0;
//        pq.Enqueue((src, 0), 0);

//        while (pq.Count > 0)
//        {
//            var (u, d) = pq.Dequeue();
//            if (d > dist[u]) continue;

//            foreach (var (v, w) in adj[u])
//            {
//                long nd = d + w;
//                if (nd < dist[v])
//                {
//                    dist[v] = nd;
//                    pq.Enqueue((v, nd), nd);
//                }
//            }
//        }
//    }
//}

//class Solution
//{
//    public static void Main(string[] args)
//    {
//        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

//        string[] gNodesEdges = Console.ReadLine().TrimEnd().Split(' ');

//        int gNodes = Convert.ToInt32(gNodesEdges[0]);
//        int gEdges = Convert.ToInt32(gNodesEdges[1]);

//        List<int> gFrom = new List<int>();
//        List<int> gTo = new List<int>();
//        List<int> gWeight = new List<int>();

//        for (int i = 0; i < gEdges; i++)
//        {
//            string[] gFromToWeight = Console.ReadLine().TrimEnd().Split(' ');

//            gFrom.Add(Convert.ToInt32(gFromToWeight[0]));
//            gTo.Add(Convert.ToInt32(gFromToWeight[1]));
//            gWeight.Add(Convert.ToInt32(gFromToWeight[2]));
//        }

//        List<string> result = Result.classifyEdges(gNodes, gFrom, gTo, gWeight);

//        textWriter.WriteLine(String.Join("\n", result));

//        textWriter.Flush();
//        textWriter.Close();
//    }
//}

#endregion