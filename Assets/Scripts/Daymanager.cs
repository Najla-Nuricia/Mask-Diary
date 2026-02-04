using UnityEngine;
using TMPro;

public class DayManager : MonoBehaviour
{
    [SerializeField] private int day = 1;
    [SerializeField] private TMP_Text dayText;
     [SerializeField] private TMP_Text dayTextIntro;

    public void NextDay()
    {
        day++;
        UpdateUI();
    }

    public int CurrentDay()
    {
        return day;
    }
    void UpdateUI()
    {
        dayText.text = dayTextIntro.text = $"Day {day}/10";
        
    }

    public bool IsEndDay()
    {
        return day > 12;
    }

    public void ResetDay()
    {
        day = 1;
        UpdateUI();
    }
}
