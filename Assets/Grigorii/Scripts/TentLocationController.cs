using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentLocationController : Screen

{
    [SerializeField]
    private GameObject Inventory;
    [SerializeField]
    private GameObject Weapons;
    public void PhisicsExersice()
    {
    }

    public void Return()
    {
        ScreenManager.Instance.ShowScreen("Camp");
    }

    public void Bag()
    {

        Inventory.SetActive(!Inventory.activeSelf);
        Weapons.SetActive(Inventory.activeSelf);
    }
}
