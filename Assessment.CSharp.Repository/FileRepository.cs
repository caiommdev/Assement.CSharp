using System.Text.Json;
using Assessment.CSharp.Domain;

namespace Assessment.CSharp.Repository;

public class FileRepository : IRepository
{
    private FileStream _file;
    
    public void Creat(Paint paint)
    {
        string paintJson = JsonSerializer.Serialize(paint);
        using (StreamWriter writer = new StreamWriter(_file))
        {
            writer.Write(paintJson);
        }
    }

    public Paint Read(string name)
    {
        using (StreamReader reader = new StreamReader(_file))
        {
            while (!reader.EndOfStream)
            {
                string paintJsonLine = reader.ReadLine();
                Paint paint = JsonSerializer.Deserialize<Paint>(paintJsonLine);
                if (paint.Name == name)
                {
                    return paint;
                }
            }
        }
        return new Paint();
    }

    public List<Paint> ReadLastElements()
    {
        List<Paint> response = new List<Paint>();
        List<string> fileLines = AllFileLines();
        for (int i = 1; i <= fileLines.Count; i++)
        {
            if(response.Count == 5)
                break;
            Paint paint = JsonSerializer.Deserialize<Paint>(fileLines[fileLines.Count - i]);
            response.Add(paint);
        }

        return response;
    }

    private List<string> AllFileLines()
    {
        List<string> allLines = new List<string>();
        using (StreamReader reader = new StreamReader(_file))
        {
            while (!reader.EndOfStream)
            {
                allLines.Add(reader.ReadLine());
            }
        }

        return allLines;
    }
    public List<Paint> ReadAllByName(string name)
    {
        List<Paint> response = new List<Paint>();

        using (StreamReader reader = new StreamReader(_file))
        {
            while (!reader.EndOfStream)
            {
                string paintJsonLine = reader.ReadLine();
                Paint paint = JsonSerializer.Deserialize<Paint>(paintJsonLine);
                if (paint.Name.Contains(name))
                {
                    response.Add(paint);
                }
            }
        }

        return response;
    }

    public void Update(string oldName, string newName, string newId, string newPrice, string newSale, string newCreationDate)
    {
        using (StreamReader reader = new StreamReader(_file))
        {
            string allText = reader.ReadToEnd();
            while (!reader.EndOfStream)
            {
                string paintJsonLine = reader.ReadLine();
                Paint paint = JsonSerializer.Deserialize<Paint>(paintJsonLine);
                if (paint.Name == oldName)
                {
                    using (StreamWriter writer = new StreamWriter(_file))
                    {
                        allText.Replace(paint.Name, newName)
                            .Replace(paint.Id.ToString(), newId)
                            .Replace(paint.Price.ToString(), newPrice)
                            .Replace(paint.IsOnSale.ToString(), newSale)
                            .Replace(paint.CreationDate.ToString(), newCreationDate);
                        writer.Write(allText);
                    }
                    return;
                }
            }
        }
    }

    public void Delete(string name)
    {
        using (StreamReader reader = new StreamReader(_file))
        {
            string allText = reader.ReadToEnd();
            while (!reader.EndOfStream)
            {
                string paintJsonLine = reader.ReadLine();
                Paint paint = JsonSerializer.Deserialize<Paint>(paintJsonLine);
                if (paint.Name == name)
                {
                    using (StreamWriter writer = new StreamWriter(_file))
                    {
                        allText.Replace(paintJsonLine, "");
                        writer.Write(allText);
                    }
                    return;
                }
            }
        }
    }
}