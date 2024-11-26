using _PlatformJump._Screpts;
using Services;
using UnityEngine;

namespace Project.Screpts.Screens
{
    public class DialogLauncher : MonoBehaviour, IService
    {
        [SerializeField] private MenuScreen _menuScreen;
        [SerializeField] private SettingsScreen _settingsScreen;
        [SerializeField] private GarageScreen _garage;
        [SerializeField] private GameScreen _gameScreen;
        [SerializeField] private LevelComplitedScreen _complitedScreen;
        [SerializeField] private AudioManager _audioManager;


        private BaseScreen _activeScreen;

        private void Awake()
        {
            ServiceLocator.Init();
            ServiceLocator.Instance.AddService(this);
            ServiceLocator.Instance.AddService(_audioManager);
        }

        private void Start() => ShowMenuScreen();

        public void ShowMenuScreen()
        {
            _audioManager.PlayMenuMusick();
            ShowScreen(_menuScreen);
        }

        public void ShowShopScreen() => ShowScreen(_garage);
        public void ShowSettingsScreen() => ShowScreen(_settingsScreen);
        public void ShowLevelComplitd() => ShowScreen(_complitedScreen);

        public void ShowGameScreen()
        {
            _audioManager.PlayGame();
            ShowScreen(_gameScreen);
        }


        private void ShowScreen(BaseScreen screen)
        {
            _activeScreen?.Сlose();
            var instanceScreen = Instantiate(screen, transform);
            instanceScreen.Init();
            _activeScreen = instanceScreen;
        }
    }
}