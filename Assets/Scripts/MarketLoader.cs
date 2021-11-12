using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using System.IO;
using System.Text;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

public class MarketLoader : MonoBehaviour
{
    [SerializeField] MarketWindow marketWindow;


    void Awake()
    {
        LoadPagesData();
    }

    public void LoadPagesData()
    {
        string json = File.ReadAllText(MarketDataGenerator.pagesPath);

        JArray save = JArray.Parse(json);

        IEnumerable<JToken> pages = save.Children();

        List<PageData> pageDatas = new List<PageData>();

        foreach (var item in pages)
        {
            PageData pageData = (PageData) JsonConvert.DeserializeObject(item.ToString(), typeof(PageData));

            pageDatas.Add(pageData);
        }

        marketWindow.SetPageData(pageDatas);
    }


}
