using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shopper {
    class Program {
        static void Main(string[] args) {
            var masterCard = new MasterCard(new EftTerminal());
            var shopperMaster = new Shopper(masterCard);
            shopperMaster.Charge();

            var visa = new Visa(new EftTerminal());
            var shopperVisa = new Shopper(visa);
            shopperVisa.Charge();

            Console.ReadKey();
        }
    }

    public class Shopper {
        private readonly CreditCard creditCard;

        public Shopper(CreditCard creditCard) {
            this.creditCard = creditCard;
        }

        public void Charge() {
            var chargeMessage = creditCard.Charge();
            Console.WriteLine(chargeMessage);
        }
    }

    public abstract class CreditCard {
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
}
