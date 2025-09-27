

using System.Diagnostics;
using System.Net.Http;

public class Program
{
    private static readonly HttpClient httpClient = new HttpClient();
    private static int successCount = 0;
    private static int errorCount = 0;

    public static async Task Main()
    {
        Console.WriteLine("=== API 호출 테스트 ===");
        
        // 설정
        string baseUrl = "https://localhost:7193";
        int totalRequests = 100000; // 총 호출 개수
        
        Console.WriteLine($"Base URL: {baseUrl}");
        Console.WriteLine($"총 호출 개수: {totalRequests}");
        Console.WriteLine();

        var stopwatch = Stopwatch.StartNew();

        // API 호출
        await MakeRequests(baseUrl, totalRequests);

        stopwatch.Stop();

        // 결과 출력
        Console.WriteLine();
        Console.WriteLine("=== 결과 ===");
        Console.WriteLine($"총 호출 개수: {totalRequests}");
        Console.WriteLine($"성공: {successCount}");
        Console.WriteLine($"실패: {errorCount}");
        Console.WriteLine($"걸린 시간: {stopwatch.ElapsedMilliseconds}ms");
    }

    private static async Task MakeRequests(string baseUrl, int totalRequests)
    {
        var tasks = new List<Task>();

        for (int i = 1; i <= totalRequests; i++)
        {
            tasks.Add(MakeRequest(baseUrl, i));
        }

        await Task.WhenAll(tasks);
    }

    private static async Task MakeRequest(string baseUrl, int requestId)
    {
        try
        {
            string url = $"{baseUrl}/Get";
            
            var response = await httpClient.GetAsync(url);
            
            if (response.IsSuccessStatusCode)
            {
                Interlocked.Increment(ref successCount);
                Console.WriteLine($"요청 #{requestId}: 성공");
            }
            else
            {
                Interlocked.Increment(ref errorCount);
                Console.WriteLine($"요청 #{requestId}: 실패 - {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Interlocked.Increment(ref errorCount);
            Console.WriteLine($"요청 #{requestId}: 예외 - {ex.Message}");
        }
    }
}

