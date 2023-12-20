using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMoney : MonoBehaviour
{
    private int _money = 5000;

    public UnityEvent<int> onUpdateMoney;

    public void AddMoney(int amount)
    {
        _money += amount;
        onUpdateMoney.Invoke(_money);
    }

    public bool SpendMoney(int amount)
    {
        if (_money >= amount)
        {
            _money -= amount;
            onUpdateMoney.Invoke(_money);
            return true;
        }

        return false;
    }
    
    public bool HasMoney(int amount)
    {
        return _money >= amount;
    }

    public int GetMoney()
    {
        return _money;
    }
}
