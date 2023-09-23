using Assessment.CSharp.Domain;

namespace Assessment.CSharp.Repository;

public interface IRepository
{
    void Creat(int x);
    int Read();
    int Update();
    void Delete();
    List<Paint> ReadLastElements();
}