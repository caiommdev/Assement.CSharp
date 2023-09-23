using Assessment.CSharp.Domain;

namespace Assessment.CSharp.Repository;

public class FileRepository : IRepository
{
    public void Creat(Paint paint)
    {
        Console.WriteLine($"Salvo em arquivo {paint}");
    }

    public Paint Read(string name)
    {
        throw new NotImplementedException();
    }

    public List<Paint> ReadLastElements()
    {
        return new List<Paint>();
    }

    public List<Paint> ReadAllByName(string name)
    {
        throw new NotImplementedException();
    }

    public void Update(string oldName, string newName, string newId, string newPrice, string newSale, string newCreationDate)
    {
        throw new NotImplementedException();
    }

    public void Delete(string name)
    {
        throw new NotImplementedException();
    }
}