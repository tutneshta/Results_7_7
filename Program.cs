using System;

namespace Results_7_7
{
    class Program
    {
        static void Main(string[] args)
        {

        }

    }

    class Person
    {
        private string Name;

        public string name
        {
            get
            {
                return Name;
            }
            set
            {
                if (value != null)
                {
                    Name = value;
                }
            }
        }


        private string Telephone;

        public string telephone
        {
            get
            {
                return Telephone;
            }
            set
            {
                if (value != null)
                {
                    Telephone = value;
                }

            }
        }

        private static int AdultAge = 18;

        public static int adultAge
        {
            get
            {
                return AdultAge;
            }

        }



        public Person()
        {

        }
        public Person(string name)
        {
            this.name = name;
        }
        public Person(string name, string telephone)
        {
            this.name = name;

            this.telephone = telephone;
        }

        public virtual void DisplayText()
        {
            Console.WriteLine("Выводит информацию");

            Console.WriteLine($"Имя: {name}  Телефон: {telephone}");
        }


    }

    class Client : Person
    {
        private string ClientAdress;

        public string clientAddress
        {
            set
            {
                if (value != null)
                {
                    ClientAdress = value;
                }

            }
            get
            {
                return ClientAdress;
            }
        }

        private string TypeDelivery;

        public string typeDelivery
        {
            get
            {
                return TypeDelivery;
            }
            set
            {
                if (value != null)
                {
                    TypeDelivery = value;
                }
            }
        }

        private static int Age;

        public static int age
        {
            get
            {
                return Age;
            }
            set
            {
                if (value >= adultAge)
                {
                    Age = value;
                }
                else Console.WriteLine("Вам нет 18 лет");
            }
        }

        public Client(string clientAddress, string name) : base(name)
        {
            this.clientAddress = clientAddress;
        }

        public Client() { }

        public override void DisplayText()
        {
            Console.WriteLine("Выводит информацию о клиенте");

            Console.WriteLine($"Имя: {name}  Адрес доставки: {clientAddress}");
        }

    }

    class Courier<T> : Person
    {
        private T Id;

        public T id
        {
            get
            {
                return Id;
            }
            set
            {
                if (value != null)
                {
                    Id = value;
                }
            }
        }

        public Courier(string name, T id) : base(name)
        {
            this.id = id;
        }
        public Courier()
        {

        }

        public override void DisplayText()
        {
            Console.WriteLine("Выводит информацию о курьере");

            Console.WriteLine($"Имя: {name}  identifier: {id} ");
        }
    }

    abstract class Delivery
    {
        Client client = new Client();

        public string Address
        {
            get
            {
                return client.clientAddress;
            }
        }

        private DateTime DateDelivery;

        public DateTime dateDelivery
        {
            get
            {
                return DateDelivery;
            }
            set
            {
                DateDelivery = value;
            }
        }

        public abstract void DisplayInfo();

    }

    abstract class DeliveryPoint
    {
        private string PointAddress;

        public string pointAddress
        {
            get
            {
                return PointAddress;
            }
            set
            {
                if (value != null)
                {
                    PointAddress = value;
                }
            }
        }

        public abstract void DisplayPointAddress();

    }

    class PickupPoint : DeliveryPoint
    {
        public string pickupPointAddress
        {
            get
            {
                return pointAddress;
            }
            set
            {
                if (value != null)
                {
                    pointAddress = value;
                }
            }
        }

        public PickupPoint(string pickupPointAddress)
        {
            this.pickupPointAddress = pickupPointAddress;
        }

        public PickupPoint() { }

        public override void DisplayPointAddress()
        {
            Console.WriteLine("Выводит адрес пункта самовывоза");

            Console.WriteLine($"Адрес: {pickupPointAddress}");
        }
    }

    class PickupShop : DeliveryPoint
    {
        public string pickupShopAddress
        {
            get
            {
                return pointAddress;
            }
            set
            {
                pointAddress = value;
            }
        }

        public override void DisplayPointAddress()
        {
            Console.WriteLine("Выводит информацию о магазине");

            Console.WriteLine($"Адрес магазина: {pickupShopAddress}");
        }
    }

    class HomeDelivery : Delivery
    {
        Courier<string> courier = new Courier<string>();

        public override void DisplayInfo()
        {
            Console.WriteLine("Выводит информация о доставке на дом");

            Console.WriteLine($"Адрес доставки: {Address} Дата доставки: {dateDelivery} Курьер: {courier.name}");
        }
    }

    class PickPointDelivery : Delivery
    {
        PickupPoint pickupPoint = new PickupPoint();

        public override void DisplayInfo()
        {
            Console.WriteLine("Выводит информация о самовывозе");

            Console.WriteLine($"Адрес доставки: {pickupPoint.pickupPointAddress} Дата доставки: {dateDelivery} ");
        }
    }

    class ShopDelivery : Delivery
    {
        PickupShop pickupShop = new PickupShop();

        public override void DisplayInfo()
        {
            Console.WriteLine("Выводит информация о магазине");

            Console.WriteLine($"Адрес доставки: {pickupShop.pickupShopAddress} Дата доставки: {dateDelivery} ");
        }
    }

    class Order<TDelivery, TStruct> where TDelivery : Delivery
    {
        public TDelivery Delivery;

        protected int Number;

        public int number
        {
            get
            {
                return Number;
            }
        }

        public string Description;

        public void CreateOrder()
        {
            Client client = new Client();

            Console.WriteLine($"Имя клиента: {client.name}, телефон: {client.telephone}");

            HomeDelivery homeDelivery = new HomeDelivery();

            PickPointDelivery pickPointDelivery = new PickPointDelivery();

            ShopDelivery shopDelivery = new ShopDelivery();

            Product product = new Product();

            string[] TypeDelivery = new string[] { "homeDelivery", "pickPointDelivery", "shopDelivery" };

            foreach (var item in TypeDelivery)
            {
                if (item.Equals(homeDelivery))
                {
                    Console.WriteLine($"номер заказа: {number}");

                    homeDelivery.DisplayInfo();

                    product.DisplayProduct<string>();

                    Console.WriteLine(Description);

                }
                else if (item.Equals(shopDelivery))
                {
                    Console.WriteLine($"номер заказа: {number}");

                    shopDelivery.DisplayInfo();

                    product.DisplayProduct<string>();

                    Console.WriteLine(Description);
                }
                else if (item.Equals(pickPointDelivery))
                {
                    Console.WriteLine($"номер заказа: {number}");

                    pickPointDelivery.DisplayInfo();

                    product.DisplayProduct<string>();

                    Console.WriteLine(Description);
                }
            }
        }
    }
    class Product
    {

        protected string Name;

        public string name { get; set; }

        protected string TypeProduct;

        public string typeProduct { get; set; }

        protected int Weight;

        public int weight { get; set; }

        public Product() { }
        public Product(string name, string typeProduct, int weight)
        {
            Name = name;

            TypeProduct = typeProduct;

            Weight = weight;
        }

        public void DisplayProduct<T>()
        {
            Console.WriteLine($"Название продукта: {name}, тип продукта: {typeProduct}, вес продукта: {weight}");
        }
    }
}
