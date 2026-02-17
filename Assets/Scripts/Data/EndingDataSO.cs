using UnityEngine;

[CreateAssetMenu(fileName = "NewEnding", menuName = "Game/Ending")]
public class EndingData : ScriptableObject
{
    public RIASECType type;
    public string title;
    [TextArea]
    public string description;
    public Sprite illustration;
}

