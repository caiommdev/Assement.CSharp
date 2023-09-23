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
        throw new NotImplementedException();
    }
}