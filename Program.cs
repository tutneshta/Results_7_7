using System;

namespace Results_7_7
{
    class Program
    {
        static void Main(string[] args)
        {

            Client client = new Client();
            
            
            Console.ReadKey();
        }


    }

    abstract class Delivery
    {
        private string Address;

        public string address
        {
            get
            {
                return Address;
            }
            set
            {
                if (value != null)
                {
                    Address = value;
                }
                else Console.WriteLine("введите адрес");

            }
        }


    }
     class Client
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
                else Console.WriteLine("введите имя");
            }
        }

        private string telephone;
        public string Telephone 
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
                else Console.WriteLine("введите телефон");
            }
        }



    }

    class HomeDelivery : Delivery
    {



    }

    class PickPointDelivery : Delivery
    {
        /* ... */
    }

    class ShopDelivery : Delivery
    {
        /* ... */
    }

    class Order<TDelivery, TStruct> where TDelivery : Delivery
    {
        public TDelivery Delivery;

        public int Number;

        public string Description;

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }

        // ... Другие поля
    }
}
