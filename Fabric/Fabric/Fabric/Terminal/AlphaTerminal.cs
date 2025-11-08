namespace Fabric;

public class AlphaTerminal : Terminal
{
    public override Payment CreatePaySystem()
        => new AlphaPayment();
}