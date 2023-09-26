using System.Globalization;
using System.Text.Json;
using Assessment.CSharp.Domain;

namespace Assessment.CSharp.Repository;

public class FileRepository : IRepository
{
    private string _filePath = @"/Users/caiomotamarinho/RiderProjects/Assement.CSharp/Assessment.CSharp.Repository/base-de-dados.json";
    private List<Paint> _paints;
    private string _fileText;
    
    public void Creat(Paint paint)
    {
        _fileText = File.ReadAllText(_filePath);
        
        if(_fileText != "")
            _paints = JsonSerializer.Deserialize<List<Paint>>(_fileText);
        
        _paints.Add(paint);
        _fileText = JsonSerializer.Serialize(_paints);
        File.WriteAllText(_filePath,_fileText);
    }
    
    public Paint Read(string name)
    {
        _fileText = File.ReadAllText(_filePath);
        _paints = JsonSerializer.Deserialize<List<Paint>>(_fileText);
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
        
        _fileText = File.ReadAllText(_filePath);
        _paints = JsonSerializer.Deserialize<List<Paint>>(_fileText);
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
        
        _fileText = File.ReadAllText(_filePath);
        _paints = JsonSerializer.Deserialize<List<Paint>>(_fileText);
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
        _fileText = File.ReadAllText(_filePath);
        _paints = JsonSerializer.Deserialize<List<Paint>>(_fileText);
        
        Paint paint = Read(oldName);
        _paints.Remove(paint);
        
        paint.Name = newName;
        paint.Id = int.Parse(newId);
        paint.Price = decimal.Parse(newPrice);
        paint.IsOnSale = bool.Parse(newSale);
        paint.CreationDate = DateTime.Parse(newCreationDate, CultureInfo.CurrentCulture);
        
        _paints.Add(paint);
       
        _fileText = JsonSerializer.Serialize(_paints);
       File.WriteAllText(_filePath,_fileText);
    }

    public void Delete(string name)
    {
        _fileText = File.ReadAllText(_filePath);
        _paints = JsonSerializer.Deserialize<List<Paint>>(_fileText);
        
        Paint paint = Read(name);
        _paints.Remove(paint);
        
        _fileText = JsonSerializer.Serialize(_paints);
        File.WriteAllText(_filePath,_fileText);
    }
}