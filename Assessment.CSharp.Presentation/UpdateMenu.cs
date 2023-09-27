using Assessment.CSharp.Domain;
using Assessment.CSharp.Presentation.Interfaces;
using Assessment.CSharp.Repository;

namespace Assessment.CSharp.Presentation;

public class UpdateMenu : IMenu
{
    private IRepository _repository;
    
    public UpdateMenu(IRepository repository)
    {
        _repository = repository;
    }
    public void ShowMenu()
    {
        Console.WriteLine("+++ Alteração de Pintura +++");
        Console.WriteLine("Informe o nome da pintura");
        string name = Console.ReadLine();
        Paint paint = _repository.Read(name);

        Console.WriteLine($"\nNome:{paint.Name}\n " +
                          $"ID:{paint.Id}\n" +
                          $"Preço:{paint.Price}\n" +
                          $"Está a venda:{paint.IsOnSale}\n" +
                          $"Data de criação:{paint.CreationDate}\n" +
                          $"Idade: {paint.CalculatePaintYear()}\n");
        
        Console.WriteLine("Escreva as novas prorpiedades");

        Console.Write("Nome:");
        string newName = Console.ReadLine();
        
        Console.Write("ID:");
        string newId = Console.ReadLine();
        
        Console.Write("Preço:");
        string newPrice = Console.ReadLine();
        
        Console.Write("Em promoção:");
        string newSale = Console.ReadLine();
        
        Console.Write("Data de criação:");
        string newCreationDate = Console.ReadLine();
        _repository.Update(name, newName, newId, newPrice, newSale, newCreationDate);
    }
}