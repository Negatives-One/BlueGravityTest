using System;
using System.Collections;
using System.Collections.Generic;
using Coffee.UIEffects;
using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private Sprite defaultEquipSlotImage;
    [SerializeField] private Image slotImage;
    [SerializeField] private Color effectColor;
    [SerializeField] private UIEffect slotEffect;
    public EquipableInfoSO.EquipmentType slotType;
    [HideInInspector] public EquipItemDataSO itemData;
    void Start()
    {
        
    }
    
    public void UnequipInSlot()
    {
        inventory.AddItem(itemData);
        itemData = null;
        slotEffect.enabled = true;
        slotImage.color = effectColor;
        slotImage.sprite = defaultEquipSlotImage;
        inventory.onEquipedItemChanged.Invoke();
    }

    public void EquipInSlot(EquipItemDataSO newItem)
    {
        if (itemData != null)
        {
            UnequipInSlot();
        }
        else
        {
            itemData = newItem;
            slotImage.sprite = itemData.Icon;
            inventory.RemoveItem(newItem);
            slotEffect.enabled = false;
            slotImage.color = Color.white;
        }
        inventory.onEquipedItemChanged.Invoke();
    }
}
