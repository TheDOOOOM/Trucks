using Project.Screpts.Screens;
using Services;
using SO;
using TMPro;
using UnityEngine;

public class GameScreen : BaseScreen
{
    [SerializeField] private TextMeshProUGUI _textLevel;
    [SerializeField] private LevelsConfig _levelsConfig;
    [SerializeField] private PauseScreen _pauseScreen;
    [SerializeField] private Counter _counter;

    private GameLevel _gameLevel;

    public void OnEnable()
    {
        _counter.LevelComplited += LevelComplited;
    }

    public override void Init()
    {
        base.Init();
        _gameLevel = Instantiate(_levelsConfig.GetLevel());
        _textLevel.text = $"{_levelsConfig.LevelIndex + 1}";
        ServiceLocator.Instance.AddService(_counter);
    }

    public void LevelComplited()
    {
        Dialog.ShowLevelComplitd();
    }

    public void ShowPauseScreen()
    {
        AudioManager.PlayButtonClick();
        Instantiate(_pauseScreen, transform);
    }

    public override void Сlose()
    {
        ServiceLocator.Instance.RemoveService(_counter);
        Destroy(_gameLevel.gameObject);
        base.Сlose();
    }

    private void OnDisable()
    {
        _counter.LevelComplited -= LevelComplited;
    }
}