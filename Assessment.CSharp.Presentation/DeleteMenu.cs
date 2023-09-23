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
        throw new NotImplementedException();
    }
}