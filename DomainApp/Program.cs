using Billing.Domain.Entities;
using Billing.Domain.Entities.Tariffs;
using Billing.Domain.Repositories;
using Billing.Domain.Services;
using System;
using System.Linq;
using System.Threading;

namespace DomainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create client data
            Passport passport = new Passport(1111, 11111, "fn", "ln", "pn");
            Client client = new Client(passport);


            // Create sim card data
            Repository<SimCard> simCardRepo = new Repository<SimCard>();
            SimCardService simCardService = new SimCardService(simCardRepo);
            simCardService.AddSimCard("88005553535", 100);
            simCardService.AddSimCard("88005553536", 100);
            simCardService.AddSimCard("88005553537", 100);

            // Create tariff data
            CallAreaTarificationRule tarificationRule = new CallAreaTarificationRule(5, 10);
            Tariff tariff = new Tariff("Free 30 min");
            tariff.SetTarificationRule(tarificationRule);
            tariff.ActivateTariff();

            // Client change sim card with number 88005553535 and tariff
            SimCard simCard = simCardRepo.All().SingleOrDefault(x => x.PhoneNumber == "88005553535");

            simCardService.SellSimCard(simCard, client, tariff);


            // Call service
            Repository<Call> callRepo = new Repository<Call>();
            CallService callService = new CallService(simCardRepo, callRepo);

            // Calls test
            Console.WriteLine("Проверка звонков");
            // Try internal call (0 cost)
            Console.WriteLine("Звоню на внутренний номер, 5 секунд, стоимость 0");
            Console.WriteLine("Баланс " + simCard.Balance.Money);
            callService.DoCall("88005553535", "88005553536");
            Thread.Sleep(5000);
            Call callZeroCostInternal = callRepo.All().SingleOrDefault(x => x._phoneNumberFrom == "88005553535" && x.State == CallState.InProgress);
            callService.EndCall(callZeroCostInternal);

            Console.WriteLine("Звонок окончен.");
            Console.WriteLine("Стоимость " + callZeroCostInternal.Cost);
            Console.WriteLine("Баланс " + simCard.Balance.Money);

            //// Try internal call (10 cost)
            //Console.WriteLine("Звоню на внутренний номер, 32 секунды, стоимость 10");
            //Console.WriteLine("Баланс " + simCard.Balance.Money);
            //callService.DoCall("88005553535", "88005553536");
            //Thread.Sleep(32000);
            //Call call10CostInternal = callRepo.All().SingleOrDefault(x => x._phoneNumberFrom == "88005553535" && x.State == CallState.InProgress);
            //callService.EndCall(call10CostInternal);

            //Console.WriteLine("Звонок окончен.");
            //Console.WriteLine("Стоимость " + call10CostInternal.Cost);
            //Console.WriteLine("Баланс " + simCard.Balance.Money);

            // Try external call (10 cost)
            Console.WriteLine("Звоню на внутренний номер, 2 секунды, стоимость 20");
            Console.WriteLine("Баланс " + simCard.Balance.Money);
            callService.DoCall("88005553535", "33333");
            Thread.Sleep(2000);
            Call callExternal = callRepo.All().SingleOrDefault(x => x._phoneNumberFrom == "88005553535" && x.State == CallState.InProgress);
            callService.EndCall(callExternal);

            Console.WriteLine("Звонок окончен.");
            Console.WriteLine("Стоимость " + callExternal.Cost);
            Console.WriteLine("Баланс " + simCard.Balance.Money);


            Console.WriteLine("==============================");
            Console.WriteLine("Проверка: пополнение баланса");

            Console.WriteLine("Баланс до " + simCard.Balance.Money);
            simCard.Balance.PutMoney(100);
            Console.WriteLine("Баланс после " + simCard.Balance.Money);


            Console.WriteLine("==============================");
            Console.WriteLine("Проверка: смена тарифа");

            CallAreaTarificationRule tarificationRule2 = new CallAreaTarificationRule(0, 0);
            Tariff tariff2 = new Tariff("Free absolute");
            tariff2.SetTarificationRule(tarificationRule2);
            tariff2.ActivateTariff();

            simCard.SetTariff(tariff2);

            // Try external call (0 cost)
            Console.WriteLine("Звоню на внутренний номер после смены тарифа, 2 секунды, стоимость 0");
            Console.WriteLine("Баланс " + simCard.Balance.Money);
            callService.DoCall("88005553535", "33333");
            Thread.Sleep(2000);
            Call callExternalFree = callRepo.All().SingleOrDefault(x => x._phoneNumberFrom == "88005553535" && x.State == CallState.InProgress);
            callService.EndCall(callExternalFree);
            Console.WriteLine("Звонок окончен.");
            Console.WriteLine("Стоимость " + callExternalFree.Cost);
            Console.WriteLine("Баланс " + simCard.Balance.Money);

            Console.WriteLine("==============================");
            Console.WriteLine("Проверка: выставление счета");
            simCard.Tariff.SetSubscriptionFee(1000);

            Bill bill = new Bill(simCard);
            bill.SetUpBill();
            Console.WriteLine("Платить по счету: " + bill.Value);


            Console.ReadLine();
        }
    }
}
