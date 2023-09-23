using System.Globalization;

namespace Assessment.CSharp.Domain;

public class Paint
{
    public string Name { get; set; }
    public int Id { get; set; }
    public bool IsOnSale { get; set; }
    public Decimal Price { get; set; }
    public DateTime CreationDate { get; set; }

    public int CalculatePaintYear()
    {
        int year = DateTime.Now.Year - CreationDate.Year;

        if (DateTime.Now.Day < CreationDate.Day && DateTime.Now.Month < CreationDate.Month)
            year--;

        return year;
    }

    public void RegisName()
    {
        Console.WriteLine("Informe o nome da Pintura");
        string name = Console.ReadLine();
        Name = name;
    }
    
    public void RegisId()
    {
        Console.WriteLine("Informe o id da Pintura");
        string id = Console.ReadLine();
        Id = int.Parse(id);
    }
    
    public void RegisOnSale()
    {
        Console.WriteLine("Informe se a Pintura está em promoção (Sim ou Nao)");
        string onSale = Console.ReadLine();
        
        IsOnSale = false;
        
        if (onSale.ToLower() == "sim")
            IsOnSale = true;
    }

    public void RegisPrice()
    {
        Console.WriteLine("Informe o preço da Pintura");
        string price = Console.ReadLine();
        Price = int.Parse(price);
    }
    
    public void RegisCreationDate()
    {
        Console.WriteLine("Informe a data de criação da Pintura");
        string date = Console.ReadLine();
        CreationDate = DateTime.Parse(date, CultureInfo.CurrentCulture).Date;
        //ddmmYYYY dd-mm-YYYY dd/mm/YYYY
    }
}