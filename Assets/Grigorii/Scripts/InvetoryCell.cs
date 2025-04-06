
using UnityEngine;

public class InvetoryCell : MonoBehaviour
{
    private Weapon _weapon = null;

    public bool IsEmpty => _weapon == null;

    internal void PlaceWeapon(Weapon weapon)
    {
        _weapon = weapon;
    }

    internal void RemoveWeapon(Weapon weapon)
    {
        if (_weapon == weapon)
        {
            _weapon = null;
        }
    }
}
