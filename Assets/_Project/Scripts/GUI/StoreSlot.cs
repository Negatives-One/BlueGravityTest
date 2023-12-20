using TMPro;
using UnityEngine;

public class StoreSlot : ItemSlot
{
    [SerializeField] private TMP_Text priceText;
    public ItemPack itemPack;
    
    public override void SetupItem(ItemPack receivedItemPack)
    {
        base.SetupItem(receivedItemPack);
        priceText.text = itemData.Price.ToString();
        this.itemPack = receivedItemPack;
    }
}
