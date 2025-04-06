using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;

[System.Serializable]
public struct MapPoint
{
    public string Name;
    public Transform transform;
}

public class WorldController : Screen
{
    public MapPoint[] Locations;

    [SerializeField]
    public float MovingDuration = 1f;
    public GameObject EnterButton;
    public Transform Character;
    private MapPoint _currentLocation;
    private Coroutine _currentMoving;

    public void Start()
    {
        _currentLocation = FindClosestLocation(Character.position);
    }

    public MapPoint FindClosestLocation(Vector3 position)
    {
        MapPoint closest = Locations[0];
        float minDistance = float.MaxValue;
        foreach (var location in Locations)
        {
            float distance = Vector3.Distance(position, location.transform.position);
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
        if (_currentLocation.transform == Locations[point].transform)
        {
            return;
        }

        if (_currentMoving != null)
        {
            StopCoroutine(_currentMoving);
        }
        _currentMoving = StartCoroutine(Moving(Locations[point]));
        EnterButton.SetActive(false);
    }

    IEnumerator Moving(MapPoint newLocation)
    {
        var startPosition = Character.position;
        for (float t = 0; t < 1; t += Time.deltaTime / MovingDuration)

        {
            Character.position = Vector3.Lerp(startPosition, newLocation.transform.position, t);
            yield return null;
        }
        _currentLocation = newLocation;
        Character.position = _currentLocation.transform.position;
        EnterButton.SetActive(true);
    }

    public void Enter()
    {
        ScreenManager.Instance.ShowScreen(_currentLocation.Name);
    }


}
