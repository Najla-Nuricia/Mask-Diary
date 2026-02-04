using UnityEngine;
using TMPro;
using System;
using UnityEngine.AI;
using Unity.VisualScripting;

public class DayManager : MonoBehaviour
{
    [SerializeField] private int day = 1;
    [SerializeField] private TMP_Text dayText;
    [SerializeField] private TMP_Text dayTextIntro;

    [SerializeField] private NarrativeData narrativeData;

     [SerializeField] private NarrativeManager narrativemanager;

    public void NextDay()
    {
        day++;
        UpdateUI();
    }

    public int TotalDays()
    {
        return narrativemanager.GetTotalDays();
    }

    public bool IsEndDay()
    {
        return day > TotalDays();
    }

    public int CurrentDay()
    {
        return day;
    }

    void UpdateUI()
    {
        dayText.text = dayTextIntro.text = $"Day {day}/{TotalDays()}" ;
    }

    public void ResetDay()
    {
        day = 1;
        UpdateUI();
    }
}
