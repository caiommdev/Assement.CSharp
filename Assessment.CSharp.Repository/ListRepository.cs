using System.Globalization;
using Assessment.CSharp.Domain;

namespace Assessment.CSharp.Repository;

public class ListRepository : IRepository
{
    private List<Paint> allPaints = new List<Paint>();
    public void Creat(Paint paint)
    {
        allPaints.Add(paint);
    }

    public Paint Read(string name)
    {
        foreach (var paint in allPaints)
        {
            if (paint.Name == name)
                return paint;
        }

        return new Paint();
    }

    public void Update(string oldName,string newName, string newId, string newPrice, string newSale, string newCreationDate)
    {
        Paint paint = Read(oldName);
        paint.Name = newName;
        paint.Id = int.Parse(newId);
        paint.Price = decimal.Parse(newPrice);
        paint.IsOnSale = bool.Parse(newSale);
        paint.CreationDate = DateTime.Parse(newCreationDate, CultureInfo.CurrentCulture);
    }

    public void Delete(string name)
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
}