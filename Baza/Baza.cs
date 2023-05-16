using HurtowniaData;
using HurtowniaDomain;

namespace HurtowniaBaza
{
    public class Baza
    {
        //wypisywanie wszystkich rekordow z tabeli Delivery
       public static void GetDeliveriesAll()
        {
            using var context = new HurtowniaContext();
            var deliveries = context.Deliveries.ToList();
            foreach (var delivery in deliveries)
            {
                Console.WriteLine(delivery.Id + " " + delivery.supplierName + " " + delivery.quantity + " " + delivery.towarName);
            }
            
        }


        //dodawnia danych do Tabeli Delivery
        public static void AddDelivery(string dostawca,decimal cenaNetto,decimal cenaBrutto, string nazwaTowaru,DateTime data, int ilosc)
        {
            var Delivery = new Delivery { supplierName = dostawca, priceNetto = cenaNetto, towarName = nazwaTowaru, priceBrutto = cenaBrutto, deliveryDate = data, quantity = ilosc };
            using var context = new HurtowniaContext();
            context.Deliveries.Add(Delivery);
            context.SaveChanges();
        }

        //wyszukiwanie danych o danym id z tabeli delivery 
        public static void GetDeliveriesById(int identyfikator)
        {
            using var context = new HurtowniaContext();
            var deliveries = context.Deliveries.Where(s => s.Id.Equals(identyfikator)).ToList();

            foreach( var delivery in deliveries)
            {
                Console.WriteLine($"{delivery.Id} {delivery.towarName} {delivery.supplierName} {delivery.priceNetto} {delivery.priceBrutto} {delivery.deliveryDate}");
            }
        }

        //wyszukiwanie rekordow w tabeli delivery o szukanym nazwie dostawcy
        public static void GetDeliveriesBySupplierName(string suplier)
        {
            using var context = new HurtowniaContext();
            var deliveries = context.Deliveries.Where(s => s.supplierName.Equals(suplier)).ToList();

            foreach (var delivery in deliveries)
            {
                Console.WriteLine($"{delivery.Id} {delivery.towarName} {delivery.supplierName} {delivery.priceNetto} {delivery.priceBrutto} {delivery.deliveryDate}");
            }
        }
    }
}