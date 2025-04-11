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

    [Space]
    [SerializeField] private int PerceptionMin = 1;
    [SerializeField] private int PerceptionMax = 10;

    [Space]
    [SerializeField] private int AdaptationMin = 1;
    [SerializeField] private int AdaptationMax = 10;

    [Space]
    [SerializeField] private int ExistenceMin = 1;
    [SerializeField] private int ExistenceMax = 10;

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
