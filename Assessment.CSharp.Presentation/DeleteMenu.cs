using Assessment.CSharp.Domain;
using Assessment.CSharp.Presentation.Interfaces;
using Assessment.CSharp.Repository;

namespace Assessment.CSharp.Presentation;

public class DeleteMenu : IMenu
{
    private IRepository _repository;
    public DeleteMenu(IRepository repository)
    {
        _repository = repository;
    }
    public void ShowMenu()
    {
        Console.WriteLine("+++ Deleção de Pintura +++");
        Console.WriteLine("Informe o nome da pintura");
        string name = Console.ReadLine();
        Paint paint = _repository.Read(name);

        Console.WriteLine($"\nNome:{paint.Name}\n " +
                          $"ID:{paint.Id}\n" +
                          $"Preço:{paint.Price}\n" +
                          $"Está a venda:{paint.IsOnSale}\n" +
                          $"Data de criação:{paint.CreationDate}\n" +
                          $"Idade: {paint.CalculatePaintYear()}\n");
        
        Console.WriteLine("Você gostaria mesmo de deletar essa pintura? S/N");
        string response = Console.ReadLine();
        
        if (response.ToLower() == "s")
            _repository.Delete(name);
    }
}