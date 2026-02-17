using TMPro;
using System.Collections;
using UnityEngine;

public class NarrativeManager : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text introText;
    public TMP_Text diaryText;

    [Header("Typing Effect")]
    public AudioSource typingSFX;
    public float typingSpeed = 0.05f;

    [Header("Data")]
    public TextAsset narrativeJson;

    private NarrativeData narrativeData;
    private Coroutine typingCoroutine;

    private void Awake()
    {
        LoadNarrativeData();
    }

    void LoadNarrativeData()
    {
        narrativeData = JsonUtility.FromJson<NarrativeData>(narrativeJson.text);
    }

    public int GetTotalDays()
    {
        return narrativeData.days.Length;
    }



    public void ShowNarration(int currentDay)
    {
        string narration = GetNarrationText(currentDay);
        StartTyping(introText, narration);
    }

    string GetNarrationText(int day)
    {
        if (day - 1 < 0 || day - 1 >= narrativeData.days.Length)
            return "";

        return narrativeData.days[day - 1].narration;
    }


    public void WriteDiary(int currentDay, SocialMaskData mask)
    {
        string diary = GetDiaryText(currentDay, mask);
        StartTyping(diaryText, diary);
    }

    string GetDiaryText(int day, SocialMaskData mask)
    {
        if (day - 1 < 0 || day - 1 >= narrativeData.days.Length)
            return "";

        DayData dayData = narrativeData.days[day - 1];

        foreach (var entry in dayData.diaryEntries)
        {
            if (entry.mask == mask)
                return entry.text;
        }

        return "";
    }



    void StartTyping(TMP_Text targetText, string content)
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeText(targetText, content));
    }

    IEnumerator TypeText(TMP_Text targetText, string text)
    {
        targetText.text = "";

        foreach (char c in text)
        {
            targetText.text += c;

            if (typingSFX && typingSFX.clip)
                typingSFX.PlayOneShot(typingSFX.clip);

            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
