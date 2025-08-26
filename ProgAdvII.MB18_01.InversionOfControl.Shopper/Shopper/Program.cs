using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Shopper {
    class Program {
        static void Main(string[] args) {
            /* Dependency Injection
            var masterCard = new MasterCard(new EftTerminal());
            var shopperMaster = new Shopper(masterCard);
            shopperMaster.Charge();
            var visa = new Visa(new EftTerminal());
            var shopperVisa = new Shopper(visa);
            shopperVisa.Charge();*/

            /* my IoC Container
            Resolver resolver = new Resolver();
            resolver.Register<ICreditCard, MasterCard>();
            resolver.Register<ITerminal, EftTerminal>();
            var shopper = resolver.Resolve<Shopper>();*/

            var builder = new ContainerBuilder();
            builder.RegisterType<MasterCard>().As<ICreditCard>();
            builder.RegisterType<EftTerminal>().As<ITerminal>();
            builder.RegisterType<Shopper>();
            //builder.RegisterType<UsageCounter>();
            builder.RegisterType<UsageCounter>().SingleInstance();
            var container = builder.Build();
            var shopper = container.Resolve<Shopper>();

            shopper.Charge();

            for (int i = 0; i < 10; i++)
            {
                var useCounter = container.Resolve<UsageCounter>();
                useCounter.Use();
            }
        }
    }

    public class Shopper {
        private readonly ICreditCard creditCard;

        public Shopper(ICreditCard creditCard) {
            this.creditCard = creditCard;
        }

        public void Charge() {
            var chargeMessage = creditCard.Charge();
            Console.WriteLine(chargeMessage);
        }
    }

    public abstract class CreditCard : ICreditCard {
        public readonly ITerminal terminal;
        public CreditCard(ITerminal terminal) {
            this.terminal = terminal;
        }
        public void TrxTerminal() {
            this.terminal.Trx();
        }
        public abstract string Charge();
    }

    public class Visa : CreditCard {
        public Visa(ITerminal terminal) : base(terminal) { }
        public override string Charge() {
            base.TrxTerminal();
            return "Chaaaarging with the Visa!";
        }
    }

    public class MasterCard  : CreditCard {
        public MasterCard(ITerminal terminal) : base(terminal) { }
        public override string Charge() {
            base.TrxTerminal();
            return "Swiping the MasterCard!";
        }
    }

    public class EftTerminal : ITerminal {
        public void Trx() {
            Console.WriteLine("Do Eft-Transaction.");
        }
    }

    public interface ITerminal
    {
        void Trx();
    }

    public interface ICreditCard
    {
        string Charge();
    }
}
