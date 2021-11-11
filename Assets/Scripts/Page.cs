using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.AddressableAssets;

public class Page : MonoBehaviour
{
    List<Item> items;
   
    void Awake()
    {
        items = new List<Item>( GetComponentsInChildren<Item>(true) );
        foreach (var item in items)
        {
            item.gameObject.SetActive(false);
        }
    }

    public void LoadItems(List<ItemData> itemData)
    {
        for (int i =0; i < items.Count; i++)
        {
            Item II = items[i];

            bool showItem = i < itemData.Count;

            II.gameObject.SetActive(showItem);


            if (showItem)
            {
                ItemData data = itemData[i];

                II.SetItemData(data);

                Addressables.LoadAssetAsync<Sprite>(data.addressableID)
                    .Completed += (handle) => II.SetItemIcon(handle.Result);

                StartCoroutine(DownloadImage(data.avatarLink, II.SetAvatar));
            }
        }

    }

    IEnumerator DownloadImage(string MediaUrl, Action<Texture2D> onSuccess)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError ||
            request.result == UnityWebRequest.Result.ProtocolError ||
            request.result == UnityWebRequest.Result.DataProcessingError
        )
            Debug.Log(request.error);
        else
            onSuccess.Invoke(((DownloadHandlerTexture)request.downloadHandler).texture);
    }
}
