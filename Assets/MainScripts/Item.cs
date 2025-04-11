using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum _ItemType
{
    Permanent,
    AllTime
}

/// <summary>
/// Скрипт будет менятся
/// </summary>
public class Item : MonoBehaviour
{
    public _ItemType itemType;

    public int[] _itemStats;

    public int PerceptionMin = 1;
    public int PerceptionMax = 10;
    [Space]
    public int AdaptationMin = 1;
    public int AdaptationMax = 10;
    [Space]
    public int ExistenceMin = 1;
    public int ExistenceMax = 10;

    private void Start()
    {
        RandomStats();
    }
    void RandomStats()
    {
        _itemStats = new int[3] {
            Random.Range(PerceptionMin, PerceptionMax),
            Random.Range(AdaptationMin, AdaptationMax),
            Random.Range(ExistenceMin, ExistenceMax)
        };
    }
}
