using HurtowniaData;
using HurtowniaDomain;
using HurtowniaBaza;
/*using (HurtowniaContext context = new HurtowniaContext()) //tworzenie bazy jak nie jest stworzona
{
    context.Database.EnsureCreated();
}*/
//Baza.AddDelivery("staney",1000,2000,"piweczko",DateTime.Now,100);
Baza.GetDeliveriesAll();
Console.WriteLine("podaj identyfikator ktory chcesz wyszukac");
int whereId = int.Parse(Console.ReadLine());
Baza.GetDeliveriesById(whereId);        //wyszukiwanie rekordow w tabeli delivery po szukanym ID
Baza.GetDeliveriesBySupplierName("karol");      //wyszukiwanie rekordow w tabeli delivery po szukanym dostawcy
