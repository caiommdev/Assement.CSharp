using Assessment.CSharp.Repository;

namespace Assement.CSharp;

public class Teste
{
    private IRepository _repository;

    public Teste(IRepository repo)
    {
        _repository = repo;
    }
    
    public void AdicionarX(int x)
    {
        if (x < 0)
            //acontece algo
        
        _repository.Creat(x);
    }
}