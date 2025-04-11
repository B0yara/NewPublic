using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEntity : MonoBehaviour
{
    [SerializeField] private Entity entity;

    public TMPro.TextMeshPro Perception;
    public TMPro.TextMeshPro Adaptation;
    public TMPro.TextMeshPro Existence;
    public void UpdateStats()
    {
        Perception.text = entity.EntityStats.Perception.ToString();
        Adaptation.text = entity.EntityStats.Adaptation.ToString();
        Existence.text = entity.EntityStats.Existence.ToString();
    }
}
