using System.Collections.Generic;
using UnityEngine;

public class MaskManager : MonoBehaviour
{
    public List<SocialMaskData> allMasks;

    private Dictionary<SocialMaskData, int> maskScores =
        new Dictionary<SocialMaskData, int>();

    void Start()
    {
        foreach (var mask in allMasks)
        {
            maskScores[mask] = 0;
        }
    }

    public void ApplyMask(SocialMaskData mask)
    {
        maskScores[mask]++;
    }

    public RIASECType GetHighestRIASEC()
    {
        Dictionary<RIASECType, int> typeScores =
            new Dictionary<RIASECType, int>();


        foreach (RIASECType type in System.Enum.GetValues(typeof(RIASECType)))
        {
            typeScores[type] = 0;
        }


        foreach (var pair in maskScores)
        {
            RIASECType type = pair.Key.type;
            typeScores[type] += pair.Value;
        }


        RIASECType highest = RIASECType.R;
        int max = -1;

        foreach (var pair in typeScores)
        {
            if (pair.Value > max)
            {
                max = pair.Value;
                highest = pair.Key;
            }
        }

        return highest;
    }

}
