

using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private Vector2Int Size;

    [SerializeField]
    private InvetoryCell CellPrefab;

    private InvetoryCell[,] _cells;

    private Dictionary<InvetoryCell, Weapon> WeaponList;


    void Awake()
    {
        WeaponList = new();
        _cells = new InvetoryCell[Size.x, Size.y];
        for (var x = 0; x < Size.x; x++)
        {
            for (var y = 0; y < Size.x; y++)
            {
                _cells[x, y] = Instantiate(CellPrefab, transform);
            }
        }
    }

    public bool TryToPlace(Weapon weapon)
    {
        var cellID = GetClosestCell(weapon.transform.position);
        var cells = new List<InvetoryCell>();
        if (cellID.x < 0 || !CheckFit(cellID, weapon.Size, out cells))
        {
            return false;
        }
        WeaponList.Add(cells[0], weapon);
        weapon.transform.position = cells[0].transform.position;
        foreach (var cell in cells)
        {
            cell.PlaceWeapon(weapon);
        }


        return true;
    }




    public bool CheckFit(Vector2Int cellID, Vector2Int weaponSize, out List<InvetoryCell> cells)
    {
        cells = new List<InvetoryCell>();
        for (var x = 0; x < weaponSize.x; x++)
        {
            for (var y = 0; y < weaponSize.y; y++)
            {
                var newX = cellID.x + x;
                var newY = cellID.y + y;
                if (newX >= Size.x || newY >= Size.y)
                {
                    return false;
                }

                var cell = _cells[newX, newY];
                if (!cell.IsEmpty)
                {
                    return false;
                }
                cells.Add(cell);
            }
        }
        return true;
    }

    private Vector2Int GetClosestCell(Vector2 weaponPos)
    {
        var distance = 200f;
        var result = new Vector2Int(-1, -1);
        for (var x = 0; x < Size.x; x++)
        {
            for (var y = 0; y < Size.x; y++)
            {
                var newDistance = Vector2.Distance(_cells[x, y].transform.position, weaponPos);
                if (newDistance < distance)
                {
                    distance = newDistance;
                    result.x = x;
                    result.y = y;
                }
            }
        }
        Debug.Log(distance);
        return result;
    }

    public void RemoveWeapon(Weapon weapon)
    {

        foreach (var cell in _cells)
        {
            if (WeaponList.ContainsKey(cell))
            {
                WeaponList.Remove(cell);
            }
            cell.RemoveWeapon(weapon);
        }
    }

}
