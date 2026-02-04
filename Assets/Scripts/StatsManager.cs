using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public int Happy;
    public int Angry;
    public int mixed;

    public void ApplyMask(SocialMask mask)
    {
        switch (mask)
        {
            case SocialMask.Happy:
                Happy++;
                break;
            case SocialMask.Angry:
                Angry++;
                break;
            case SocialMask.Mixed:
                mixed++;
                break;
        }
    }

    public void ResetStats()
    {
        Happy = Angry = mixed = 0;
    }
}
