using System.Globalization;
using System.Text.Json;
using Assessment.CSharp.Domain;

namespace Assessment.CSharp.Repository;

public class FileRepository : IRepository
{
    private string _filePath = @"/Users/caiomotamarinho/RiderProjects/Assement.CSharp/Assessment.CSharp.Repository/base-de-dados.json";
    private List<Paint> _paints = new();
    private string _fileText;
    
    public void Creat(Paint paint)
    {
        _fileText = File.ReadAllText(_filePath);
        
        if(_fileText != "")
            _paints = JsonSerializer.Deserialize<List<Paint>>(_fileText);
        
        _paints.Add(paint);
        SaveData();
    }
    
    public Paint Read(string name)
    {
        GetData();
        foreach (var paint in _paints)
        {
            if (paint.Name == name)
            {
                return paint;
            }
        }

        return new Paint();
    }

    public List<Paint> ReadLastElements()
    {
        var response = new List<Paint>();
        
        GetData();
        for (int i = _paints.Count-1; i >= 0; i--)
        {
            if (response.Count == 5)
                break;
            response.Add(_paints[i]);
        }

        return response;
    }

    public List<Paint> ReadAllByName(string name)
    {
        var response = new List<Paint>();
        
        GetData();
        foreach (var paint in _paints)
        {
            if (paint.Name.Contains(name))
            {
                response.Add(paint);
            }
        }

        return response;
    }

    public void Update(string oldName, string newName, string newId, string newPrice, string newSale, string newCreationDate)
    {
        GetData();
        
        Paint paint = Read(oldName);
        _paints.Remove(paint);
        
        paint.Name = newName;
        paint.Id = int.Parse(newId);
        paint.Price = decimal.Parse(newPrice);
        
        paint.IsOnSale = false;
        if (newSale=="sim")
            paint.IsOnSale = true;
        
        paint.CreationDate = DateTime.Parse(newCreationDate, CultureInfo.CurrentCulture);
        
        _paints.Add(paint);
       
        SaveData();
    }

    public void Delete(string name)
    {
        GetData();
        
        Paint paint = Read(name);
        _paints.Remove(paint);
        
        SaveData();
    }

    private void GetData()
    {
        _fileText = File.ReadAllText(_filePath);
        _paints = JsonSerializer.Deserialize<List<Paint>>(_fileText);
    }

    private void SaveData()
    {
        _fileText = JsonSerializer.Serialize(_paints);
        File.WriteAllText(_filePath,_fileText);
        
    }
}