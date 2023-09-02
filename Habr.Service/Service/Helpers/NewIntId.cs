using Habr.Service.Domain.Commons;
using Habr.Service.Service.Extentions;

namespace Habr.Service.Service.Helpers;

public static class NewIntId
{
    public static async Task<int> GetLastId<T>(this string pathOfData) where T : Auditable
    {
        var source = await pathOfData.ReadJsonFromFileAsync<List<T>>();
        if (string.IsNullOrEmpty(source.ToString()))
            return 0;

        var lastItem = source.Last();
        return lastItem.Id + 1;
    }
}