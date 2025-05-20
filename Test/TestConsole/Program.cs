

int N = int.Parse(Console.ReadLine());
int hansu = 1;
int hansuCount = 0;

while (true)
{
    if (hansu >= N)
    {
        Console.WriteLine(hansuCount);
        break;
    }

    if (N % hansu == 1)
    {
        hansuCount++;
    }

    hansu++;
}