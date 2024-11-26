using System;
using System.Collections;
using System.Collections.Generic;
using Project.Screpts.Screens;
using Services;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    private DialogLauncher _dialogLauncher;

    public void Start()
    {
        _dialogLauncher = ServiceLocator.Instance.GetService<DialogLauncher>();
    }

    public void CloseScreen()
    {
        Destroy(gameObject);
    }

    public void ShowMenu()
    {
        _dialogLauncher.ShowMenuScreen();
    }
}