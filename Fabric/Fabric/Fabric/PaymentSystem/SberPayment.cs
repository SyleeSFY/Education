using Fabric.Repository;

namespace Fabric;

public class SberPayment : Payment
{
    private PaymentRepository _repository = new PaymentRepository();
    public override void Pay(decimal amount)
    {
        Console.WriteLine($"Проведение оплаты через Сбербанк");
        var newPayment = CreatePayment(amount);
        NewTransaction(newPayment);
    }
    protected override void NewTransaction(PaymentInfo payment)
    {
        Console.WriteLine($"[Терминал Сбербанк]");
        Console.WriteLine($"[Дата выписки {payment.GetDatePayment():dd.MM.yyyy} Сумма: {payment.Amount}]");
        SaveTransaction(payment);
    }

    protected override void SaveTransaction(PaymentInfo payment)
        => _repository.Save(payment);

    public override List<PaymentInfo> GetPayments()
        => _repository.GetAll().Where(p => p.TerminalType == (int)TerminalType.Sber).ToList();
    
    protected override PaymentInfo CreatePayment(decimal amount)
    {
        return new PaymentInfo()
        {
            Amount = amount,
            TerminalType = (int)TerminalType.Sber,
            Id = Guid.NewGuid()
        };
    }
}