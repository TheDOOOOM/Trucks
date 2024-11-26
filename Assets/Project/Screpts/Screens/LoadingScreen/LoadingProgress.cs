using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingProgress : MonoBehaviour
{
    [SerializeField] private Image[] _images;
    [SerializeField] private Sprite _reachedTheMark;
    [SerializeField] private Sprite _nonreachedTheMark;

    public void Start()
    {
        LoadingNextScreen();
    }

    private async UniTaskVoid LoadingNextScreen()
    {
        int nextScreenIndex = SceneManager.GetActiveScene().buildIndex + 1;
        var progress = SceneManager.LoadSceneAsync(nextScreenIndex, LoadSceneMode.Single);
        int lastUpdatedIndex = -1;

        while (!progress.isDone)
        {
            float actualProgress = progress.progress;

            float scaledProgress = Mathf.Clamp01(actualProgress / 0.9f);

            int currentIndex = Mathf.FloorToInt(scaledProgress * _images.Length);
            currentIndex = Mathf.Clamp(currentIndex, 0, _images.Length - 1);

            if (currentIndex != lastUpdatedIndex)
            {
                for (int i = lastUpdatedIndex + 1; i <= currentIndex; i++)
                    _images[i].sprite = _reachedTheMark;


                lastUpdatedIndex = currentIndex;
            }

            await UniTask.Yield();
        }
        
    }
}