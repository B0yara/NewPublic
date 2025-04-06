using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public struct Road
{

}

public class WorldController : MonoBehaviour
{
    public Transform[] Locations;

    [SerializeField]
    public float MovingDuration = 1f;
    public Transform Character;
    private Transform _currentLocation;
    private Coroutine _currentMoving;

    public void Start()
    {
        _currentLocation = FindClosestLocation(Character.position);
    }

    public Transform FindClosestLocation(Vector3 position)
    {
        Transform closest = null;
        float minDistance = float.MaxValue;
        foreach (var location in Locations)
        {
            float distance = Vector3.Distance(position, location.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = location;
            }
        }
        return closest;
    }

    public void Move(int point)
    {
        if (_currentLocation == Locations[point])
        {
            return;
        }

        if (_currentMoving != null)
        {
            StopCoroutine(_currentMoving);
        }
        _currentMoving = StartCoroutine(Moving(Locations[point]));
    }

    IEnumerator Moving(Transform newLocation)
    {
        var startPosition = Character.position;
        for (float t = 0; t < MovingDuration; t += Time.deltaTime)
        {
            Character.position = Vector3.Lerp(startPosition, _currentLocation.position, t);
            yield return null;
        }
        Character.position = _currentLocation.position;
        _currentLocation = newLocation;
    }
}
