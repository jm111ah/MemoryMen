namespace DependencyInjection
{
    public class Greeter : IGreeter
    {
        public string GetName(string name)
        {
            return name;
        }
    }
}
