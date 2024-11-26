using UnityEngine;

namespace Project.Screpts.Screens
{
    public class MenuScreen : BaseScreen
    {
        public void OpenSetting()
        {
            AudioManager.PlayButtonClick();
            Dialog.ShowSettingsScreen();
        }

        public void ShowShopScreen()
        {
            AudioManager.PlayButtonClick();
            Dialog.ShowShopScreen();
        }

        public void ShowGameScreen()
        {
            AudioManager.PlayButtonClick();
            Dialog.ShowGameScreen();
        }

        public void OutAppp()
        {
            AudioManager.PlayButtonClick();
            Application.Quit();
        }
    }
}