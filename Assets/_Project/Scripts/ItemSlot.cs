using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    public UnityEvent<ItemDataSO, PointerEventData> OnPointerEnterSlot { get; } = new();
    public UnityEvent<ItemDataSO, PointerEventData> OnPointerExitSlot { get; } = new();
    public UnityEvent<ItemDataSO, PointerEventData> OnPointerMoveSlot { get; } = new();

    public ItemDataSO ItemData => itemData;

    public int ItemAmount => itemAmount;

    [SerializeField] protected Transform itemDataHolder;
    [SerializeField] protected Image itemImage;
    public Button itemButton;
    [SerializeField] private TextMeshProUGUI itemAmountText;
    [SerializeField] protected Vector2 pointerOffset = new Vector2(10, 10);
    public ItemInfoUI ItemInfoUI { get; set; }

    protected ItemDataSO itemData;
    protected int itemAmount = 1;
    protected int index;
    protected bool hasSubSprite;
    protected bool showInfoUI = true;


    public void EmptySlot()
    {
        HideSlot();
        itemData = null;
        itemImage.sprite = null;
    }

    [Button]
    public virtual void SetupItem(ItemPack itemPack)
    {
        itemData = Instantiate(itemPack.ItemData);
        if (itemData.CanStack)
            itemAmount = itemPack.Amount;
        else itemAmount = 1;
        
        ShowSlot();
    }

    protected void UpdateUI()
    {
        if (itemData == null)
        {
            Debug.LogError("No item data is assigned to " + name, gameObject);
            return;
        }
        
        itemImage.sprite = itemData.Icon;
        if (itemAmountText != null)
        {
            itemAmountText.gameObject.SetActive(ItemAmount > 1);
            itemAmountText.text = ItemAmount.ToString();
        }

        if (itemImage.transform.childCount > 0)
            itemImage.transform.GetChild(0).gameObject.SetActive(hasSubSprite);
    }

    public void ChangeItem(ItemDataSO itemData, int amount)
    {
        this.itemData = itemData;
        itemAmount = amount;
        ShowSlot();
    }

    protected void HideSlot()
    {
        itemDataHolder.gameObject.SetActive(false);
    }

    public void ShowSlot()
    {
        itemDataHolder.gameObject.SetActive(true);
        UpdateUI();
        itemDataHolder.gameObject.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!showInfoUI || itemData == null) return;
        ItemInfoUI.ShowItemInfo(itemData, eventData.position);
        itemImage.rectTransform.DOScale(new Vector2(1.1f, 1.1f), .15f).SetEase(Ease.OutBack);
        OnPointerEnterSlot.Invoke(itemData, eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (itemData == null) return;
        HideItemInfo();
        OnPointerExitSlot.Invoke(itemData, eventData);
    }

    public void HideItemInfo()
    {
        itemImage.rectTransform.DOScale(new Vector2(1f, 1f), .1f).SetEase(Ease.InExpo);
        ItemInfoUI.HideItemInfo();
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (itemData == null) return;
        ItemInfoUI.MoveItemInfo(eventData.position);
        OnPointerMoveSlot.Invoke(itemData, eventData);
    }
}