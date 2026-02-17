using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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
    public Button[] choiceButtons;

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

    public DayData GetDay(int currentDay)
    {
        return narrativeData.days[currentDay - 1];
    }

    void GetButtontext()
    {
        for (int i = 0; i < choiceButtons.Length; i++)
        {
            if (i < dayData.choices.Length)
            {
                ChoiceData choice = dayData.choices[i];

                choiceButtons[i].gameObject.SetActive(true);

                TMP_Text txt = choiceButtons[i].GetComponentInChildren<TMP_Text>();
                txt.text = choice.choiceText;

                choiceButtons[i].onClick.RemoveAllListeners();
                choiceButtons[i].onClick.AddListener(() =>
                {
                    OnChoiceSelected(choice);
                });
            }
            else
            {
                choiceButtons[i].gameObject.SetActive(false);
            }
        }
    }

}
