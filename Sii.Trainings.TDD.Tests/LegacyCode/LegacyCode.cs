namespace Sii.Trainings.TDD.Tests.LegacyCode
{
    using System;

    public class LegacyCode
    {
        private readonly IWriter _writer;
        private bool _instanceIsRestaurantOpen;

        public LegacyCode(IWriter writer, bool isRestaurantOpen)
        {
            this._writer = writer;
            YetAnotherHorribleSingleton.Instance.WhyDoWeEvenDoThis();
            this._instanceIsRestaurantOpen = isRestaurantOpen;
        }

        public void WriteToConsole(string text)
        {
            Console.WriteLine(text);
        }

        public bool IsCustomerOk(Customer customer)
        {
            if (customer == null)
                return false;
            return this._instanceIsRestaurantOpen && customer.Age > 18;
        }

        public void Write()
        {
            this._writer.Write();
        }
    }

    public class Customer
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class YetAnotherHorribleSingleton
    {
        private static YetAnotherHorribleSingleton _instance;

        public static YetAnotherHorribleSingleton Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new YetAnotherHorribleSingleton();

                return _instance;
            }
        }

        public bool IsRestaurantOpen { get; set; }

        private YetAnotherHorribleSingleton()
        { }

        public void WhyDoWeEvenDoThis()
        {
            this.IsRestaurantOpen = DateTime.Now.Second % 2 == 0;
            Console.WriteLine("Hello world!");
        }
    }
}