using UnityEngine;
using UnityEngine.UI;
using TMPro;




public class EndingManager : MonoBehaviour
{
    public MaskManager maskManager;

    public EndingData[] endings;

    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public Image illustrationImage;

    public GameObject endingPanel;

    public void DetermineEnding()
    {
        RIASECType result = maskManager.GetHighestRIASEC();
        ShowEnding(result);
    }

    void ShowEnding(RIASECType result)
    {
        foreach (var ending in endings)
        {
            if (ending.type == result)
            {
                titleText.text = ending.title;
                descriptionText.text = ending.description;
                illustrationImage.sprite = ending.illustration;

                endingPanel.SetActive(true);
                break;
            }
        }
    }
}
