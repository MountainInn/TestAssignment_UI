using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    [SerializeField] Image avatar, itemIcon;
    [SerializeField] TextMeshProUGUI playerName, itemQuantity, itemName, itemPrice;

    public void SetItemData(ItemData itemData)
    {
        playerName.text = itemData.playerName;
        itemQuantity.text = "x"+ itemData.quantity.ToString();
        itemName.text = itemData.name;
        itemPrice.text = itemData.price.ToString();
    }

    public void SetItemIcon(Sprite itemIconSprite)
    {
        itemIcon.sprite = itemIconSprite;
    }

    public void SetAvatar(Texture2D avatarTexture)
    {
        avatar.sprite = Sprite.Create(avatarTexture, new Rect(0, 0, avatarTexture.width, avatarTexture.height), new Vector2(.5f, .5f));
    }

}
