using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Entity : MonoBehaviour
{
    public  Stats EntityStats;
    /// <summary>
    /// Всегда должен принимать stats в длину 3 (Добавляет статы)
    /// </summary>
    /// <param name="stats"></param>
    public  void AddStats(int[] stats)
    {
        EntityStats.Perception += stats[0];
        EntityStats.Adaptation += stats[1];
        EntityStats.Existence += stats[2];
    }
    /// <summary>
    /// Всегда должен принимать stats в длину 3 (вычитает статы)
    /// </summary>
    /// <param name="stats"></param>
    public  void RemoveStats(int[] stats)
    {
        int[] minusStats = new int[3];
        minusStats[0] = -stats[0];
        minusStats[1] = -stats[1];
        minusStats[2] = -stats[2];

        AddStats(minusStats);
    }
} 
