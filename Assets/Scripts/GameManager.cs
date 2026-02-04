using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public DayManager dayManager;
    public StatsManager statsManager;
    public NarrativeManager narrativeManager;
    public EndingManager endingManager;
    public GameObject maskPanel;
    public GameObject mainMenuPanel;
    public GameObject introPanel;
    public GameObject DiaryPanel;


    public void StartGame()
    {
        mainMenuPanel.SetActive(false);
        introPanel.SetActive(true);

        maskPanel.SetActive(false);
        DiaryPanel.SetActive(false);

        narrativeManager.ShowNarration(dayManager.CurrentDay());
    }

    public void NextToMaskPanel()
    {
        introPanel.SetActive(false);
        maskPanel.SetActive(true);
    }

     

    private void Awake()
    {
        Instance = this;
    }

    public void ChooseHappy()
    {
        ChooseMask(SocialMask.Happy);
    }

    public void ChooseAngry()
    {
        ChooseMask(SocialMask.Angry);
    }

    public void ChooseMixed()
    {
        ChooseMask(SocialMask.Mixed);
    }

   
    private void ChooseMask(SocialMask mask)
    {
        statsManager.ApplyMask(mask);

        maskPanel.SetActive(false);
        DiaryPanel.SetActive(true); 

        narrativeManager.WriteDiary(dayManager.CurrentDay(), mask);
        
    }

    public void OnDiaryFinished()
    {
        DiaryPanel.SetActive(false);

        dayManager.NextDay(); 

        if (dayManager.IsEndDay())
        {
            endingManager.DetermineEnding();
        }
        else
        {
            introPanel.SetActive(true);
            narrativeManager.ShowNarration(dayManager.CurrentDay());
        }
    }


    public void ResetGame()
    {
        dayManager.ResetDay();
        statsManager.ResetStats();
    }
}
