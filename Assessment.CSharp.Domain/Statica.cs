namespace Assessment.CSharp.Domain;

public static class StringExtensions
{
     public static string ToString(this Paint palavra)
     {
          return $"{palavra.Name}";
     }
}