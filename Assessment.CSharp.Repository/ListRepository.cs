using System.Globalization;
using Assessment.CSharp.Domain;

namespace Assessment.CSharp.Repository;

public class ListRepository : IRepository
{
    private List<Paint> _allPaints = new List<Paint>();
    public void Creat(Paint paint)
    {
        _allPaints.Add(paint);
    }

    public Paint Read(string name)
    {
        foreach (var paint in _allPaints)
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
        Paint paint = Read(name);
        _allPaints.Remove(paint);
    }

    public List<Paint> ReadLastElements()
    {
        return new List<Paint>();
    }

    public List<Paint> ReadAllByName(string name)
    {
        List<Paint> results = new List<Paint>();
        foreach (var paint in _allPaints)
        {
            if (paint.Name.Contains(name))
                results.Add(paint);
        }

        return results;
    }
}