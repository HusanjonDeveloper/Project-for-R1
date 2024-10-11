namespace Chat.Client.Pages.ChatPages;


public abstract class UserChatsBase : ComponentBase
{
    [Inject]
    private IChatIntegration chatIntegration { get; set; }
    
    [Inject]
    NavigationManager NavigationManager { get; set; }
    protected List<ChatDto> chats { get; set; } = new ();
    
    [Inject] AuthenticationStateProvider authenticationStateProvider { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var( statusCode ,response)= await chatIntegration.GetUserChats();

        if (statusCode == HttpStatusCode.OK)
        {
            chats = (List<ChatDto>)response;
        }
    }

    protected async Task SeeChat(Guid ChatId)
    {
        var chat = chats.First(c => c.Id == ChatId);

        var userId = await GetUserId();

        var userChat = chat.UserChats?.First(c => c.UserId == userId);
            
      
            
        NavigationManager.NavigateTo($"/see-chat/{userChat?.ToUserId}");
    }

    private async Task<Guid> GetUserId()
    {
        var stateProvider = (CustomAuthHandler)authenticationStateProvider;
        
        var sate = await stateProvider.GetAuthenticationStateAsync();

        ClaimsPrincipal user = sate.User;
        
        var userId = user.Claims.FirstOrDefault(c => c.Type 
                                                     == ClaimTypes.NameIdentifier)!.Value;
        
        return Guid.Parse(userId);
    }
    
}