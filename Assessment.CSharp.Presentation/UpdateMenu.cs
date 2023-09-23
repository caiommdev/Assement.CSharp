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
                          $"Idade: {paint.CalculatePaintYear()}");
        
        Console.WriteLine("Escreva as novas prorpiedades em ordem (nome até data de criação)");
        
        string newName = Console.ReadLine();
        string newId = Console.ReadLine();
        string newPrice = Console.ReadLine();
        string newSale = Console.ReadLine();
        string newCreationDate = Console.ReadLine();
        _repository.Update(newName, newId, newPrice, newSale, newCreationDate);
    }
}