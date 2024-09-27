using System.Net;
using Chat.Client.Models;
using Chat.Client.Repositories.Contracts;
using Microsoft.AspNetCore.Components;

public class LoginBase : ComponentBase
{
    [Inject]
    IUserIntegration UserIntegration { get; set; }

    [Inject]
    NavigationManager Manager { get; set; }

    [Inject]
    ILocalStorageService StorageService { get; set; }
    
    protected LoginModel Model = new();

    protected async Task LoginClicked()
    {

        var (statusCode, response) = await UserIntegration.Login(Model);

        bool isOk = statusCode == HttpStatusCode.OK;

        bool isBadRequest = statusCode == HttpStatusCode.BadRequest;



        if (isOk)
        {
            await StorageService.SetItemAsStringAsync("token", response);

            Manager.NavigateTo($"/login-successfully/{response}");
        }
        else if (isBadRequest)
            Manager.NavigateTo($"/error/{response}");


    }