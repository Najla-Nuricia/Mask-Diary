using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public int Happy;
    public int Angry;
    public int mixed;

    public void ResetStats()
    {
        Happy = Angry = mixed = 0;
    }
}
