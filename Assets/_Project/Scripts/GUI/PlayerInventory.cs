using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int maxItems = 15;
    [SerializeField] private EquipSlot hatSlot;
    [SerializeField] private EquipSlot hairSlot;
    [SerializeField] private EquipSlot clothSlot;

    [SerializeField] private ItemInfoUI itemInfoUI;
    [SerializeField] private GameObject inventoryParent;
    [SerializeField] private Transform inventoryHolder;
    [SerializeField] private GameObject inventoryItemPrefab;
    
    public UnityEvent onEquipedItemChanged;
    
    [SerializeField] private CharacterVisualController playerVisualController;
    
    [HideInInspector] public List<EquipItemDataSO> items = new List<EquipItemDataSO>();

    private void Start()
    {
        onEquipedItemChanged.AddListener(UpdatePlayerVisual);
        UpdatePlayerVisual();
    }

    public void AddItem(EquipItemDataSO item)
    {
        items.Add(item);
        UpdateInventoryItems();
    }
    public void RemoveItem(EquipItemDataSO item)
    {
        items.Remove(item);
        UpdateInventoryItems();
    }

    private void UpdateInventoryItems()
    {
        for(int i = inventoryHolder.childCount - 1; i >= 0; i--)
        {
            Destroy(inventoryHolder.GetChild(i).gameObject);
        }

        foreach (EquipItemDataSO item in items)
        {
            GameObject inventoryItemObject = Instantiate(inventoryItemPrefab, inventoryHolder);
            InventorySlot inventorySlot = inventoryItemObject.GetComponent<InventorySlot>();
            ItemPack itemPack = new ItemPack(item);
            inventorySlot.SetupItem(itemPack);
            inventorySlot.ItemInfoUI = itemInfoUI;
            inventorySlot.itemButton.onClick.AddListener(() => TryToEquip(item));
        }
    }

    private void TryToEquip(EquipItemDataSO i)
    {
        itemInfoUI.HideItemInfo();
        switch (i.equipInfo.equipmentType)
        {
            case EquipableInfoSO.EquipmentType.Hat:
                hatSlot.EquipInSlot(i);
                break;
            case EquipableInfoSO.EquipmentType.Hair:
                hairSlot.EquipInSlot(i);
                break;
            case EquipableInfoSO.EquipmentType.Cloth:
                clothSlot.EquipInSlot(i);
                break;
            default:
                Debug.Log("Cant, equip items of this type");
                break;
        }
    }

    private void UpdatePlayerVisual()
    {
        CharacterVisualInfoSO newVisual = ScriptableObject.CreateInstance<CharacterVisualInfoSO>();
        newVisual.currentBodyType = CharacterVisualInfoSO.BodyType.Type1;
        newVisual.hat = hatSlot.itemData == null ? null : hatSlot.itemData.equipInfo;
        newVisual.hair = hairSlot.itemData == null ? null : hairSlot.itemData.equipInfo;
        newVisual.cloth = clothSlot.itemData == null ? null : clothSlot.itemData.equipInfo;
        playerVisualController.ChangeCurrentVisual(newVisual);
    }

    public void Show()
    {
        inventoryParent.SetActive(true);
        UpdateInventoryItems();
        Time.timeScale = 0f;
    } 
    
    public void Hide()
    {
        Time.timeScale = 1f;
        inventoryParent.SetActive(false);
    }
}
