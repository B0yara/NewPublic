using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum _ItemType
{
    Permanent,
    AllTime
}

public class Item : MonoBehaviour
{
    public _ItemType itemType;

    public int[] _itemStats;

    
    public int stat1Min = 1;
    public int stat1Max = 10;
    [Space]
    public int stat2Min = 1;
    public int stat2Max = 10;
    [Space]
    public int stat3Min = 1;
    public int stat3Max = 10;

    private void Start()
    {
        RandomStats();
    }
    void RandomStats()
    {
        _itemStats = new int[3] {
            Random.Range(stat1Min, stat1Max),
            Random.Range(stat2Min, stat2Max),
            Random.Range(stat3Min, stat3Max)
        };
    }
}
