using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataSO", menuName = "Blue Gravity/ItemDataSO")]
public class ItemDataSO : ScriptableObject
{
    [SerializeField] private Sprite icon;

    [SerializeField] private string itemName;

    [TextArea] [SerializeField] private string description;
    [SerializeField] private int price = 10;

    [SerializeField] private bool canStack;

    public Sprite Icon
    {
        get => icon;
        set => icon = value;
    }

    public string ItemName
    {
        get => itemName;
        set => itemName = value;
    }

    public bool CanStack
    {
        get => canStack;
        set => canStack = value;
    }

    public string Description
    {
        get => description;
        set => description = value;
    }

    public int Price
    {
        get => price;
        set => price = value;
    }
}

[Serializable]
public class ItemPack
{
    public EquipItemDataSO ItemData;

    public ItemPack(EquipItemDataSO itemData)
    {
        ItemData = itemData;
    }
}