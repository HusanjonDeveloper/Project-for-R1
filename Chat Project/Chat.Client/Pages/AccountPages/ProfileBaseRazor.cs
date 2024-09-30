using System.Net;
using Chat.Client.Constants;
using Chat.Client.DTOs;
using Microsoft.AspNetCore.Components;

namespace Chat.Client.Pages.AccountPages;

public class ProfileBaseRazor : ComponentBase
{
    [Inject]
    private IUserIntegration UserIntegration { get; set; }
    
    [Inject]
    private NavigationManager Navigation { get; set; }
    protected string ImgUrl { get; set; }
    protected UserDto? User { get; set; }
    
    protected string Bio { get; set; }

    protected byte Age { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var (statusCode, response) = await UserIntegration.GetProfile(Age);

        if (statusCode == HttpStatusCode.OK)
        {
            User = (UserDto)response!;

            if (User.PhotoData != null)
            {
                ImgUrl = $"data:image/jpeg;base64,{Convert.ToBase64String(User.PhotoData)}";
            }
            else
            {
                ImgUrl = UrlConstants.DefaultImgUrl;
            }
        }
        else
        {
            var error = (string)response!;
        }
    }


    protected async Task UpdateAge()
    {
        var (statusCode, response) = await UserIntegration.UpdateAge(Age);

        Navigation.Refresh(true);
    }

    protected async Task UpdateBio()
    {
        var (statusCode, response) = await UserIntegration.UpdateBio(Bio);
        Navigation.Refresh(true);
    }
}