using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [SerializeField] private GameObject storeUI;
    [SerializeField] private GameObject storeItemPrefab;
    [SerializeField] private ItemInfoUI itemInfoUI;
    [SerializeField] private Transform itemsHolder;

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