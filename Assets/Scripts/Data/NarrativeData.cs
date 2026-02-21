using UnityEngine;
using TMPro;


[System.Serializable]
public class NarrativeData
{
    public DayData[] days;
}

[System.Serializable]
public class DayData
{
    public string narration;
    public ChoiceData[] choices;
    public DiaryEntry[] diaryEntries;
}

[System.Serializable]
public class ChoiceData
{
    public RIASECType type;
    public string choiceText;
}

[System.Serializable]
public class DiaryEntry
{
    public RIASECType type;
    [TextArea]
    public string text;
}

