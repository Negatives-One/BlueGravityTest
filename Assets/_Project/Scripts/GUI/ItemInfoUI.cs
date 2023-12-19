using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;
    [SerializeField] private TextMeshProUGUI itemPriceText;
    [SerializeField] private Vector2 positionOffset;
    [SerializeField] private RectTransform rt;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    public void ShowItemInfo(ItemDataSO itemData, Vector3 position)
    {
        gameObject.SetActive(true);
        itemNameText.text = itemData.ItemName;
        itemDescriptionText.text = itemData.Description;
        itemPriceText.text = "Price:" + itemData.Price;
        transform.position = position + new Vector3(positionOffset.x, positionOffset.y, 0);
        if (rt == null) rt = GetComponent<RectTransform>();

        foreach (RectTransform rTransform in rt.transform)
        {
            ForceLayoutUpdate(rTransform);
        }
    }

    void ForceLayoutUpdate(RectTransform rt)
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(rt);
        foreach (RectTransform rTransform in rt)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(rTransform);
        }
    }

    public void MoveItemInfo(Vector3 position)
    {
        transform.position = position + new Vector3(positionOffset.x, positionOffset.y, 0);
    }

    public void HideItemInfo()
    {
        gameObject.SetActive(false);
    }
}