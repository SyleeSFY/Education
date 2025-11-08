namespace Fabric;

public abstract class Terminal
{
    abstract public Payment CreatePaySystem();
    
    public void Pay(decimal amount)
        => CreatePaySystem().Pay(amount);
    
    public List<PaymentInfo> GetPayments()
        => CreatePaySystem().GetPayments();
    
    
}