using UnityEngine;
using Newtonsoft.Json;

public class ItemData
{
    public string
        avatarLink,
        playerName,
        addressableID,
        name;
    public int
        quantity,
        price;

    [JsonIgnoreAttribute] public Sprite avatarSprite {private set; get;}
    [JsonIgnoreAttribute] public Sprite itemSprite {private set; get;}

    public void CacheAvatarSprite(Texture2D texture)
    {
        avatarSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(.5f, .5f));
    }

    public void CacheItemSprite(Sprite itemSprite)
    {
        this.itemSprite = itemSprite ;
    }
}
