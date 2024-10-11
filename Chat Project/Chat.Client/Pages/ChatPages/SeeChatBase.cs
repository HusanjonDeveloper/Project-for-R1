namespace Chat.Client.Pages.ChatPages;


public abstract class SeeChatBase : ComponentBase
{
    [Inject] IChatIntegration chatIntegration { get; set; }
    
    protected ChatDto Chat { get; set; } = new();
    
    protected string Text { get; set; }
    
    protected List<MessageDto> Messages { get; set; } = new();
    
    [Parameter]
    public Guid ToUserId { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var (statusCode, response) = await chatIntegration.GetUserChat(ToUserId);

        if (statusCode == HttpStatusCode.OK)
        {
            Chat = (ChatDto)response;
             
            var (statusCode1, response1) = 
                await chatIntegration.GetChatMessage(Chat.Id);

            if (statusCode1 == HttpStatusCode.OK)
            {
                Messages = (List<MessageDto>)response1;
            }
        }
       
    }

    protected async Task SendMessage()
    {
        var (statusCode, response) = await chatIntegration.SendTextMessage(Chat.Id, Text);

        if (statusCode == HttpStatusCode.OK)
        {
            var message = (MessageDto)response;
            Messages.Add(message);
            Text = string.Empty;
        }
    }
}