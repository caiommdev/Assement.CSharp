using Assessment.CSharp.Domain;
using Assessment.CSharp.Presentation.Interfaces;
using Assessment.CSharp.Repository;

namespace Assessment.CSharp.Presentation;

public class ReadMenu : IMenu
{
    private IRepository _repository;

    public ReadMenu(IRepository repository)
    {
        _repository = repository;
    }
    public void ShowMenu()
    {
        Console.WriteLine("+++ Leitura de Pintura +++");
        Console.WriteLine("Informe o nome da pintura");
        string name = Console.ReadLine();
        List<Paint> paints = _repository.ReadAllByName(name);
        if (paints.FirstOrDefault() == null)
        {
            Console.WriteLine("Pintura não encontrada\n");
            return;
        }

        int index = 0;
        foreach (var paint in paints)
        {
            Console.WriteLine($"\n{paint.Name}, {index}\n");
            index++;
        }
        
        Console.WriteLine("========Escolha uma das opções========");
        int op = int.Parse(Console.ReadLine());

        Paint selectPaint = paints[op];
        Console.WriteLine($"\nNome:{selectPaint.Name}\n " +
                          $"ID:{selectPaint.Id}\n" +
                          $"Preço:{selectPaint.Price}\n" +
                          $"Está a venda:{selectPaint.IsOnSale}\n" +
                          $"Data de criação:{selectPaint.CreationDate}\n" +
                          $"Idade: {selectPaint.CalculatePaintYear()}\n");
    }
}