using System;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(PlayerMoneyModel)+"_Default", menuName = "RSG/Currency/"+nameof(PlayerMoneyModel))]
public class PlayerMoneyModel : ScriptableObject
{
    private int _moneyAmount;
    
    public Action<int> OnMoneyChanged;
    public int MoneyAmount => _moneyAmount;
    
    public void AddMoney(int amount)
    {
        _moneyAmount += amount;
        OnMoneyChanged?.Invoke(_moneyAmount);
    }

    public bool SpendMoney(int amount)
    {
        if (_moneyAmount < amount) return false;
        
        _moneyAmount -= amount;
        OnMoneyChanged?.Invoke(_moneyAmount);
        return true;
    }

    public void Reset()
    {
        _moneyAmount = 0;
        OnMoneyChanged?.Invoke(_moneyAmount);
    }
}
