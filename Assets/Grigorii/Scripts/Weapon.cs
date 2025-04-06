using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum WeaponType
{
    empty,
    Knife,
    Bow,
    Book
}

public class Weapon : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public WeaponType Type;
    public Vector2Int Size;

    public InventoryController inventory;
    private Vector2 _startPosition;


    void Start()
    {
        _startPosition = transform.position;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        inventory.RemoveWeapon(this);
        transform.SetAsLastSibling();
        Debug.Log("BeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag");
        if (!inventory.TryToPlace(this))
        {
            transform.position = _startPosition;
        }
    }
}
