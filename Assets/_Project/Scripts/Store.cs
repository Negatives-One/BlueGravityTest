using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField] private StoreItemsSO storeItems;
    [SerializeField] private GameObject storeItemPrefab;
    [SerializeField] private ItemInfoUI itemInfoUI;
    [SerializeField] private Transform itemsHolder;

    private void Start()
    {
        StoreItemsSO items = Instantiate(storeItems);
        CreateStoreItems(items);
    }

    private void CreateStoreItems(StoreItemsSO items)
    {
        while (itemsHolder.childCount > 0)
        {
            Destroy(itemsHolder.GetChild(0).gameObject);
        }

        foreach (ItemPack item in items.items)
        {
            GameObject storeItemObject = Instantiate(storeItemPrefab, itemsHolder);
            StoreSlot storeSlot = storeItemObject.GetComponent<StoreSlot>();
            storeSlot.SetupItem(item);
            storeSlot.ItemInfoUI = itemInfoUI;
            storeSlot.itemButton.onClick.AddListener(() => BuyItem(storeSlot));
        }
    }

    public void BuyItem(StoreSlot storeSlot)
    {
        //TODO: Add to Player Inventory
    }
}