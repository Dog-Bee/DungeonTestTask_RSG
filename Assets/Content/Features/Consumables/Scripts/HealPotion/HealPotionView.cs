using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealPotionView : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI countText;
    
    public Button Button => button;

    public void SetCount(int count)
    {
        countText.text = count.ToString();
        button.interactable = count > 0;
    }
    
}
