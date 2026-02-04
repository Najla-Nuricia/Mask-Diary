[System.Serializable]
public class NarrativeData
{
    public DayData[] days;
}

[System.Serializable]
public class DayData
{
    public int day;
    public string title;
    public string narration;
    public DiaryData diary;
}

[System.Serializable]
public class DiaryData
{
    public string happy;
    public string sad;
    public string mixed;
}
