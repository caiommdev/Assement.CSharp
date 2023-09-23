using System.Diagnostics;
using Assessment.CSharp.Domain;
using Assessment.CSharp.Presentation.Interfaces;
using Assessment.CSharp.Repository;

namespace Assessment.CSharp.Presentation;

public class InitialMenu : IMenu
{
    private IRepository? _repository;
    private InsertMenu _insertMenu;
    private DeleteMenu _deleteMenu;
    private UpdateMenu _updateMenu;
    private ReadMenu _readMenu;

    
    public void ShowMenu()
    {
        Console.WriteLine("Bem Vindo ao programa de cadastro de Pinturas!\n" +
                          "Qual tipo de recurso você quer usar? Lista (1) ou Arquivo (2)?");
        string typeOfRepository = Console.ReadLine();

        _repository = SetRepositoryType(typeOfRepository);
        SetMenusRepository();
        ShowLastInsertedElementes();
        SetAction();
    }

    private IRepository? SetRepositoryType(string type)
    {
        switch (type)
        {
            case "1":
                return new ListRepository();
            case "2":
                return new FileRepository();
            default:
                Console.WriteLine($"{type} não é um tipo valido");
                return null;
        }
    }
    private void SetMenusRepository()
    {
        _deleteMenu = new DeleteMenu(_repository);
        _readMenu = new ReadMenu(_repository);
        _insertMenu = new InsertMenu(_repository);
        _updateMenu = new UpdateMenu(_repository);
    }
    private void ShowLastInsertedElementes()
    {
        List<Paint> lastElements = _repository.ReadLastElements();
        if (lastElements.FirstOrDefault() != null)
        {
            Console.WriteLine("Ultimos elementos cadastrados");
            foreach (var paint in lastElements)
            {
                Console.WriteLine($"Nome: {paint.Name}\n" +
                                  $"Id: {paint.Id}");
            }    
        }
    }

    private void SetAction()
    {
        string response = String.Empty;
        while(response != "0")
        {
            Console.WriteLine("Oque vc gostatia de fazer?\n" +
                              "Criar novo elemento (1)\n" +
                              "Alterar elemento    (2)\n" +
                              "Remover elemento    (3)\n" +
                              "Ver elemento        (4)\n" +
                              "SAIR                (0)\n");

            response = Console.ReadLine();

            switch (response)
            {
                case "1":
                    _insertMenu.ShowMenu();
                    continue;
                case "2":
                    _updateMenu.ShowMenu();
                    continue;
                case "3":
                    _deleteMenu.ShowMenu();
                    continue;
                case "4":
                    _readMenu.ShowMenu();
                    continue;
                case "0":
                    Console.WriteLine("Volte sempre!!!!");
                    break;
            }
        }
    }
}