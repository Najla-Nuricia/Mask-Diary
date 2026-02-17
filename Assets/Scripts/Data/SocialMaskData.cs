using UnityEngine;

[CreateAssetMenu(fileName = "NewMask", menuName = "MaskDiary/Social Mask")]
public class SocialMaskData : ScriptableObject
{
    public string maskName;
    public RIASECType type;
    public Sprite maskIcon;
}

public enum RIASECType
{
    R, I, A, S, E, C
}

    

