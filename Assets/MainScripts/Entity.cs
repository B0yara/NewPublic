using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Entity : MonoBehaviour
{
    public  Stats EntityStats;
    /// <summary>
    /// ������ ������ ��������� stats � ����� 3 (��������� �����)
    /// </summary>
    /// <param name="stats"></param>
    public  void AddStats(int[] stats)
    {
        EntityStats.Perception += stats[0];
        EntityStats.Adaptation += stats[1];
        EntityStats.Existence += stats[2];
    }
    /// <summary>
    /// ������ ������ ��������� stats � ����� 3 (�������� �����)
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
