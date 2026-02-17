using UnityEngine;

[CreateAssetMenu(
    fileName = "EndingData",
    menuName = "Game/Ending Data"
)]
public class EndingDataSO : ScriptableObject
{
    public string endingId;
    public Sprite endingImage;

    [TextArea(4, 10)]
    public string endingText;
}
