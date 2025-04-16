using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class InventoryUIView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemsCountText;
    [SerializeField] private TextMeshProUGUI weightText;

    public void SetItemsCount(int count)
    {
        itemsCountText.text = $"Items: {count}";
    }

    public void SetWeight(float weight, float maxWeight)
    {
        weightText.text = $"Weight: {weight}/{maxWeight}";
    }
}
