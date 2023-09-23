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
        throw new NotImplementedException();
    }
}