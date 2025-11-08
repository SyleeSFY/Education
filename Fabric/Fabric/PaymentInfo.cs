namespace Fabric;

public class PaymentInfo
{
    private DateTime _date { get; set; }
    public Guid Id { get; set; }
    public int TerminalType { get; set; }
    public decimal Amount { get; set; }

    public PaymentInfo()
        => _date = DateTime.Today;
    
    public DateTime GetDatePayment()
        => _date;
    
    public void SetDate(DateTime date)
        => _date = date;
}

