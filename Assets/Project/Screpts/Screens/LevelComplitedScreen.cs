using Project.Screpts.Screens;
using SO;
using UnityEngine;

public class LevelComplitedScreen : BaseScreen
{
    [SerializeField] private LevelsConfig _levelsConfig;

    public void Continue()
    {
        AudioManager.PlayButtonClick();
        _levelsConfig.LevelComplited();
        Dialog.ShowGameScreen();
    }

    public void ShowMenu()
    {
        AudioManager.PlayButtonClick();
        _levelsConfig.LevelComplited();
        Dialog.ShowMenuScreen();
    }
}