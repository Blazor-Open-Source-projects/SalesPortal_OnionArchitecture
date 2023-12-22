using Blazored.LocalStorage;

namespace SalesPortal.WebApp.Infrastructure.Extensions
{
    public static class LocalStorageExtension
    {
        public const string TokenName = "token";
        public const string CompanyName = "companyName";
        public const string CompanyId = "companyId";


        public static bool IsCompanyLoggedIn(this ISyncLocalStorageService localStorageService)
        {
            return !string.IsNullOrEmpty(GetToken(localStorageService));
        }

        public static string GetCompanyName(this ISyncLocalStorageService localStorageService) 
        {
            return localStorageService.GetItem<string>(CompanyName);
        }
        public static async Task<string> GetCompanyNameAsync(this ILocalStorageService localStorageService)
        {
            return await localStorageService.GetItemAsync<string>(CompanyName);
        }


        public static void SetCompanyName(this ISyncLocalStorageService localStorageService,string value)
        {
            localStorageService.SetItem<string>(CompanyName, value);
        }
        public static async Task SetCompanyNameAsync(this ILocalStorageService localStorageService, string value)
        {
            await localStorageService.SetItemAsync<string>(CompanyName, value);
        }

        public static Guid GetCompanyId(this ISyncLocalStorageService localStorageService)
        {
            return localStorageService.GetItem<Guid>(CompanyId);
        }
        public static async Task<Guid> GetCompanyId(this ILocalStorageService localStorageService)
        {
            return await localStorageService.GetItemAsync<Guid>(CompanyId);
        }

        public static void SetCompanyId(this ISyncLocalStorageService localStorageService,Guid id)
        {
                localStorageService.SetItem<Guid>(CompanyId, id);
        }
        public static async Task SetCompanyIdAsync(this ILocalStorageService localStorageService, Guid id)
        {
            await localStorageService.SetItemAsync<Guid>(CompanyId, id);
        }
        public static string GetToken(this ISyncLocalStorageService localStorageService)
        {
            var token = localStorageService.GetItem<string>(TokenName);
            if (string.IsNullOrEmpty(token))
                return "";
            return token;
        }
        public static async Task<string> GetTokenAsync(this ILocalStorageService localStorageService)
        {
            var token =await localStorageService.GetItemAsync<string>(TokenName);
            if (string.IsNullOrEmpty(token))
                return "";
            return token;
        }


        public static void SetToken(this ISyncLocalStorageService localStorageService,string token)
        {
            localStorageService.SetItem<string>(TokenName, token);  
        }
        public static async Task SetToken(this ILocalStorageService localStorageService, string token)
        {
            await localStorageService.SetItemAsync<string>(TokenName, token);
        }
    }
}
