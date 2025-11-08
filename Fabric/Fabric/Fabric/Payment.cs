namespace Fabric;

public abstract class Payment
{
    protected abstract void NewTransaction(PaymentInfo paymentInfo);
    protected abstract void SaveTransaction(PaymentInfo payment);
    protected abstract PaymentInfo CreatePayment(decimal amount);
    public abstract List<PaymentInfo> GetPayments();
    public abstract void Pay(decimal amount);
}