using System.Collections.Generic;
using System.Linq;
using System;

namespace Pandora.Services;

public class AppItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }

    public string Icon { get; set; }

    // public AppItem(string? name, string? path)
    // {
    //     Name = name;
    //     Path = path;
    // }
}

public class AppService
{
    public List<AppItem> SearchApp(string? keyword)
    {
        var appItems = Enumerable.Range(1, 50)
            .Select(i => new AppItem
            {
                Id = i,
                Name = "应用名称-" + i,
                Path = "应用路径-" + i,
                Icon = "avares://../Assets/avalonia-logo.ico"
            })
            .ToList();

        if (!string.IsNullOrEmpty(keyword))
        {
            appItems = appItems
                .Where(x => x.Name.Contains(keyword))
                .ToList();
        }

        Console.WriteLine("SearchApp:输入关键字:" + keyword + " 应用数量:" + appItems.Count);

        return appItems;
    }
}