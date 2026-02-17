using UnityEngine;


public class EndingManager : MonoBehaviour
{
    public StatsManager statsManager;

    public EndingType currentEnding;
    public GameObject EndingPanel;

    public void DetermineEnding()
    {
        if (statsManager.Angry >= 7)
            currentEnding = EndingType.Sad;
        else if (statsManager.Happy >= 7)
            currentEnding = EndingType.Happy;
        else if (statsManager.mixed >= 5)
            currentEnding = EndingType.Happy;
        else
            currentEnding = EndingType.Happy;

        ShowEnding();
    }

    void ShowEnding()
    {
        
    }
}
