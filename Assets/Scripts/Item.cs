using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    [SerializeField] Image avatar, itemIcon;
    [SerializeField] TextMeshProUGUI playerName, itemQuantity, itemName, itemPrice;

    public void SetData(ItemData itemData)
    {
        playerName.text = itemData.playerName;
        itemQuantity.text = "x"+ itemData.quantity.ToString();
        itemName.text = itemData.name;
        itemPrice.text = itemData.price.ToString();
    }

    public void SetItemSprite(Sprite itemIconSprite)
    {
        itemIcon.sprite = itemIconSprite;
    }

    public void SetAvatarSprite(Sprite avatarSprite)
    {
        avatar.sprite = avatarSprite;
    }
}
