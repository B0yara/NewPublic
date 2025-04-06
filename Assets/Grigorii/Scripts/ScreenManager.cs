

using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;



public class ScreenManager : MonoBehaviour
{
    public static ScreenManager Instance => _instance;
    private static ScreenManager _instance;
    public List<Screen> Screens;

    void Awake()
    {
        _instance = this;
        Screens = GetComponentsInChildren<Screen>(true).ToList();
    }



    public void ShowScreen(string screenName)
    {
        var newScreen = Screens.Find((screen) => screen.Name == screenName);
        foreach (var screen in Screens)
        {
            {
                screen.gameObject.SetActive(false);
            }
        }
        if (newScreen != null)
        {
            newScreen.gameObject.SetActive(true);
        }
        else
        {
            ShowScreen("World");
        }
    }
}
