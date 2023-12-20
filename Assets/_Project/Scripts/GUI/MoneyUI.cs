using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private PlayerMoney playerMoney;
    private void OnEnable()
    {
        UpdateMoney(playerMoney.GetMoney());
        playerMoney.onUpdateMoney.AddListener(UpdateMoney);
    }
    
    private void OnDisable()
    {
        playerMoney.onUpdateMoney.RemoveListener(UpdateMoney);
    }

    private void UpdateMoney(int money)
    {
        moneyText.text = money.ToString();
    }
}
