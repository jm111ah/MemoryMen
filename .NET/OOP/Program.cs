

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

    #region 캡슐화
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

    #endregion

    #region 상속

    public class Parent
    {
        public void Money()
        {
            Console.WriteLine("돈");
        }
    }

    public class Son : Parent
    {
        public void Play()
        {
            Console.WriteLine("놀다");
        }
    }

    public class Me
    {
        public void Study()
        {
            Console.WriteLine("공부");
        }
    }

    #endregion

    #region 다형성

    #region 오버로딩
    public void Over(int a)
    {
        Console.WriteLine("오버로딩1");
    }

    public void Over(int a, int b)
    {
        Console.WriteLine("오버로딩2");
    }
    #endregion

    #region 오버라이딩
    public class OverParent
    {
        public virtual void OverMoney()
        {
            Console.WriteLine("부모 돈");
        }
    }

    public class OverSon : OverParent
    {
        public override void OverMoney()
        {
            Console.WriteLine("자식 돈");
        }
    }

    public class OverSon2 : OverParent
    {
        //public override void OverMoney()
        //{
        //    Console.WriteLine("자식2 돈");
        //}
    }

    #endregion

    #endregion

    public static void Main()
    {
        OverParent son = new OverSon();
        OverParent son2 = new OverSon2();
        son.OverMoney();
        son2.OverMoney();
    }
}



