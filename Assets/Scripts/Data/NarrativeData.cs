using UnityEngine;

[System.Serializable]
public class NarrativeData
{
    public DayData[] days;
}


[System.Serializable]
public class DayData
{
    public string narration;
    public DiaryEntry[] diaryEntries;
}


[System.Serializable]
public class DiaryEntry
{
    public SocialMaskData mask;
    [TextArea]
    public string text;
}
