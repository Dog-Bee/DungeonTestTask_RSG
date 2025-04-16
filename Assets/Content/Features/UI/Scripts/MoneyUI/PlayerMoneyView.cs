using TMPro;
using UnityEngine;

public class PlayerMoneyView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;

    public void SetMoney(int money)
    {
        moneyText.text = $"Money: {money}";
    }
}
