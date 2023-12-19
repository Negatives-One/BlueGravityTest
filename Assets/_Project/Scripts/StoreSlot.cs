using TMPro;
using UnityEngine;

public class StoreSlot : ItemSlot
{
    [SerializeField] private TMP_Text priceText;
    private ItemPack itemPack;
    
    public override void SetupItem(ItemPack itemPack)
    {
        base.SetupItem(itemPack);
        priceText.text = itemData.Price.ToString();
    }
}
