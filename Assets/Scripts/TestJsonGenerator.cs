using UnityEngine;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

public class TestJsonGenerator : MonoBehaviour
{

    void Awake()
    {
        var pages = GeneratePages();

        string json = JsonConvert.SerializeObject(pages, Formatting.Indented);

        File.Delete(MarketLoader.pagesPath);
        File.WriteAllText(MarketLoader.pagesPath, json);

    }

    List<PageData> GeneratePages()
    {
        int
            itemCount = 100,
            fullPages = itemCount / 6,
            lastPageItems = itemCount % 6;

        List<PageData> pages = new List<PageData>();

        for (int i = 0; i < fullPages; i++)
        {
            PageData pageData = new PageData();

            pageData.leftButtonAvailable = (i > 0);
            pageData.rightButtonAvailable = true;
            pageData.closeButtonAvailable = false;
            pageData.items = GenerateItems(6);

            pages.Add(pageData);
        }

        PageData lastPageData = new PageData();

        lastPageData.leftButtonAvailable = true;
        lastPageData.rightButtonAvailable = false;
        lastPageData.closeButtonAvailable = true;
        lastPageData.items = GenerateItems(lastPageItems);

        pages.Add(lastPageData);

        return pages;
    }

    private List<ItemData> GenerateItems(int count)
    {
        List<ItemData> items = new List<ItemData>();

        for (int j = 0; j < count; j++)
        {
            ItemData itemData = new ItemData();
            itemData.avatarLink = "http://free-profile-pics.com/profile-pictures/01232014/download/eagle-profile-picture-180x180.png";
            itemData.playerName = "XXX_VASYA_XXX";
            itemData.price = Random.Range(30, 151);
            itemData.quantity = Random.Range(5, 71);

            RandomItem(itemData);

            items.Add(itemData);
        }

        return items;
    }


    void RandomItem(ItemData itemData)
    {
        (string, string)[] names = new (string, string)[]
        {
            ("wheat", "Пшеница"),
            ("mushrooms", "Грибы"),
            ("corn", "Кукуруза"),
            ("butter", "Масло")
        };

        (itemData.addressableID, itemData.name) = names[Random.Range(0, names.Length)];
    }

}
