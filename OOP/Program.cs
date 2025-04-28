

public class MemoryMan
{
    #region 추상화
    public abstract class PaymentService
    {
        public abstract void Pay(int price);
    }

    public class CreditCardPayment : PaymentService
    {
        public override void Pay(int price)
        {
            Console.WriteLine("크레딧 결제");
        }
    }

    public class CashPayment : PaymentService
    {
        public override void Pay(int price)
        {
            Console.WriteLine("현금 결제");
        }
    }

    #endregion

    public class BankService
    {
        private int money = 10000; // 캡슐화

        public int Withdraw(int price)
        {
            return money - price;
        }

        public void ChangeMoney(int price)
        {
            if (money - price < 0)
            {
                Console.WriteLine("음수 발생");
            }
            else
            {
                money = money - price;
                Console.WriteLine("정상 처리");
            }
        }
    }

    public static void Main()
    {
        BankService service = new BankService();
        int price = service.Withdraw(5000);
        service.ChangeMoney(price);
    }
}



