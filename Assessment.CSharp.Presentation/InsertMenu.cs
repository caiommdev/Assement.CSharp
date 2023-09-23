using Assessment.CSharp.Domain;
using Assessment.CSharp.Presentation.Interfaces;
using Assessment.CSharp.Repository;

namespace Assessment.CSharp.Presentation;

public class InsertMenu : IMenu
{    
    private IRepository _repository;

    public InsertMenu(IRepository repository)
    {
        _repository = repository;
    }
    public void ShowMenu()
    {
        var paint = new Paint();
        Console.WriteLine("+++ Cadastro de Pintura +++");
        
        paint.RegisName();
        paint.RegisId();
        paint.RegisPrice();
        paint.RegisCreationDate();
        paint.RegisOnSale();

        _repository.Creat(paint);
    }
}