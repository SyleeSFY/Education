namespace Fabric;

public class SberBankTerminal : Terminal
{
    public override Payment CreatePaySystem()
        =>  new SberPayment();
}