namespace Fabric;

class Program
{
    static void Main(string[] args)
    {
        Terminal alpha = new AlphaTerminal();
        Terminal sber = new SberBankTerminal();
        
        alpha.Pay(100);
        sber.Pay(100);

        Console.WriteLine(string.Join("\n", alpha.GetPayments()
            .Select(p => $"ID: {p.Id}, Date: {p.GetDatePayment():dd.MM.yyyy}, Amount: {p.Amount}, PaymentSystem: {(TerminalType)p.TerminalType}")));
        
        Console.WriteLine(string.Join("\n", sber.GetPayments()
            .Select(p => $"ID: {p.Id}, Date: {p.GetDatePayment():dd.MM.yyyy}, Amount: {p.Amount}, PaymentSystem: {(TerminalType)p.TerminalType}")));

        Console.WriteLine();
    }
}