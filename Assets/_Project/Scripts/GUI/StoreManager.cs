using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [SerializeField] private GameObject storeUI;
    [SerializeField] private GameObject storeItemPrefab;
    [SerializeField] private ItemInfoUI itemInfoUI;
    [SerializeField] private Transform itemsHolder;
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private PlayerMoney playerMoney;

    #region Singleton
    private static StoreManager _instance;
    public static StoreManager Instance => _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public void CreateStoreItems(StoreItemsSO items)
    {
        storeUI.SetActive(true);
        for(int i = itemsHolder.childCount - 1; i >= 0; i--)
        {
            Destroy(itemsHolder.GetChild(i).gameObject);
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
        if (!playerMoney.HasMoney(storeSlot.ItemData.Price)) return;
        if(inventory.items.Count >= inventory.maxItems) return;
        
        playerMoney.SpendMoney(storeSlot.ItemData.Price);
        inventory.AddItem(storeSlot.itemPack.ItemData);
    }
}