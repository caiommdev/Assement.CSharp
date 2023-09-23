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
        
    }
}