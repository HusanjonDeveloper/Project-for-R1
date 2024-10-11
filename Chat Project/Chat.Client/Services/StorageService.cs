namespace Chat.Client.Services;

public class StorageService(ILocalStorageService _localStorageService)
{
    private static readonly ILocalStorageService _localStorageService;

    private const string Key = "token";

    public async Task SetToken(string token)
    {
        await _localStorageService.SetItemAsStringAsync(key: Key, token);
    }
    public async Task<string?> GetToken()
    {
        var token =  await _localStorageService.GetItemAsync<string>(key: Key);

        return token;
    }

    public static async Task DeleteToken()
    {
        await _localStorageService.RemoveItemAsync(Key);
    }

}