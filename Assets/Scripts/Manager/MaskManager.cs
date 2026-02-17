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
}
