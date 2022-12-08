using Microsoft.VisualBasic;

abstract class Delivery
{
    public string Address;
    public int PhoneNumber;
    public int OrderID;
      
}

class HomeDelivery : Delivery
{
    public string IntervalsDel { get; set; }  //Интервалы доставки, удобные клиенту

    private int Distance; //Расстояние от МКАД для определения стоимости доставки
    public object Couriers; //Проверка наличия курьеров
    public void Courier()
    {
        bool CourierNalich = true;
        Console.WriteLine(CourierNalich ? "Заказ курьером доступен" : "Свободных курьеров нет");
    }
}

class PickPointDelivery : Delivery
{
    public string PointAddress;

}

class ShopDelivery : Delivery
{
    public string ShopAddress;
}

class Order<TDelivery, TStruct, TClient, TTovar> 
    where TDelivery : Delivery
    where TClient: Client
    where TTovar: Tovar
{
    public TDelivery Delivery;

    public TClient Client;

    public object Number;

    public TTovar Tovar;

    public static double OrderSum; //Сумма заказа

    public void DisplayAddress()
    {
        Console.WriteLine(Delivery.Address);
    }

    class Sale
    {
        public string Sales;

        public double SumSales()
        {
            if (OrderSum > 100000)
            {
                Console.WriteLine("Ваша скидка - 10%");
                OrderSum = OrderSum * 0.9;
                return OrderSum;
            }
            else
            {
                return OrderSum;
            }
        }
    }
}

public class Client
{
    public double age;

    public void SayYourAge()
    {
        Console.WriteLine("Мне {0} лет", Age);
    }

    public double Age
    {
        get
        {
            return age;
        }
        set
        {
            if (value < 18)
            {
                Console.WriteLine("Для создания заказа клиент должен быть не младше 18 лет");
            }
            else
            {
                age = value;
            }
        }
    }

    protected string Name { get; set; }
}

class Tovar
{
    public string Description;
    public int Amount;
    public string TovarName;

    public void Kolich()
    {
        if (Amount == 0)
        {
            Console.WriteLine("Товара нет в наличии.");
        }
    }
}


class Products: Tovar
{
    public string SrokGodn; //Срок годности продукции

    public void SrokExp()
    {
        bool SrokExp = true;
        Console.WriteLine(SrokExp ? "Товар доступен для продажи" : "Срок годности истёк. Требуется замена продукции");
    }
}
