using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Mau : MonoBehaviour
{
    public Image FillBar;
    public TextMeshProUGUI valueText;
    public void SetHealth(int currentHealth, int maxHealth)
    {
        if (FillBar == null || valueText == null)
        {
            Debug.LogError("UI components are not assigned in Mau script!");
            return;
        }
        valueText.text = currentHealth.ToString() + " / " + maxHealth.ToString();
        FillBar.fillAmount = (float)currentHealth / maxHealth;
    }
}