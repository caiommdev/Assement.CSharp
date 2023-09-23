using Assessment.CSharp.Domain;

namespace Assessment.CSharp.Repository;

public interface IRepository
{
    void Creat(Paint paint);
    Paint Read(string name);
    void Update(string oldName,string newName, string newId, string newPrice, string newSale, string newCreationDate);
    void Delete(string name);
    List<Paint> ReadLastElements();
    List<Paint> ReadAllByName(string name);
}