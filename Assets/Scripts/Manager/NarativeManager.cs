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


    public void WriteDiary(int currentDay, RIASECType type)
    {
        Debug.Log("WriteDiary DAY: " + currentDay);
        Debug.Log("WriteDiary TYPE: " + type);

        string diary = GetDiaryText(currentDay, type);
        StartTyping(diaryText, diary);
    }

    string GetDiaryText(int day, RIASECType type)
    {
        if (day - 1 < 0 || day - 1 >= narrativeData.days.Length)
        return "";

        DayData dayData = narrativeData.days[day - 1];
        
        foreach (var entry in dayData.diaryEntries)
        {
            Debug.Log("ENTRY TYPE: " + entry.type);
            if (entry.type == type)
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

    public void SetupChoices(int currentDay)
    {
        Debug.Log("SetupChoices DIPANGGIL, day = " + currentDay);

        DayData dayData = GetDay(currentDay);

        Debug.Log("Jumlah choices: " + dayData.choices.Length);
        Debug.Log("Jumlah buttons: " + choiceButtons.Length);

        for (int i = 0; i < choiceButtons.Length; i++)
        {
            if (i < dayData.choices.Length)
            {
                ChoiceData choice = dayData.choices[i];

                choiceButtons[i].gameObject.SetActive(true);

                TMP_Text txt = choiceButtons[i].GetComponentInChildren<TMP_Text>();

                if (txt == null)
                {
                    Debug.LogError("TMP_Text TIDAK DITEMUKAN di button index " + i);
                }
                else
                {
                    txt.text = choice.choiceText;
                    Debug.Log("Set text: " + choice.choiceText);
                }

                choiceButtons[i].onClick.RemoveAllListeners();

                ChoiceData capturedChoice = choice;
                int capturedDay = currentDay;

                choiceButtons[i].onClick.AddListener(() =>
                {
                    OnChoiceSelected(capturedChoice, capturedDay);
                });
            }
            else
            {
                choiceButtons[i].gameObject.SetActive(false);
            }
        }
    }
    void OnChoiceSelected(ChoiceData choice, int currentDay)
    {
        DayData dayData = GetDay(currentDay);

        foreach (var entry in dayData.diaryEntries)
        {
            if (entry.type == choice.type)
            {
                StartTyping(diaryText, entry.text);
                break;
            }
        }
    }


}
