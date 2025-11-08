namespace Fabric.Repository;

public class PaymentRepository
{
    private readonly string _filePath = "Payments.txt";
    private readonly List<PaymentInfo> _payments;

    public PaymentRepository()
        => _payments = LoadPayments();
    
    public void Save(PaymentInfo payment)
    {
        _payments.Add(payment);
        SaveToFile();
    }

    public IEnumerable<PaymentInfo> GetAll()
        => _payments.AsReadOnly();
    
    private List<PaymentInfo> LoadPayments()
    {
        var payments = new List<PaymentInfo>();
        
        var lines = File.ReadAllLines(_filePath);
        foreach (var line in lines)
        {
            var parts = line.Split('|');
            if (parts.Length == 4)
            {
                var payment = new PaymentInfo
                {
                    Id = Guid.Parse(parts[0]),
                    TerminalType = int.Parse(parts[2]),
                    Amount = decimal.Parse(parts[3])
                };
                
                payment.SetDate(DateTime.Parse(parts[1]));
            
                payments.Add(payment);
            }
        }
        return payments;
    }

    private void SaveToFile()
    {
        var payments = _payments
            .Select(p => $"{p.Id}|{p.GetDatePayment():dd.MM.yyyy}|{p.TerminalType}|{p.Amount}");
        File.WriteAllLines(_filePath, payments);
    }
}