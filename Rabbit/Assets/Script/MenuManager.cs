using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] RectTransform fader;

    #region 開啟與結束遊戲

    /// <summary>
    /// 延遲呼叫，等音效播完
    /// </summary>

    public void DelayStartGame()
    {
        // 延遲呼叫("方法名稱"，延遲秒數)
        // Invoke();
        Invoke("Gamestart", 0.8f);
    }

    /// <summary>
    /// 延遲呼叫，等音效播完
    /// </summary>

    public void DelayQuitgame()
    {
        Invoke("QuitGame", 0.8f);
    }

    /// <summary>
    /// 開始遊戲
    /// </summary>
    private void Gamestart()
    {
        // 載入指定場景
        // 場景管理器 的 載入場景("場景名稱")
        // 場景管理器 的 載入場景(1)
        //SceneManager.LoadScene("遊戲場景");

        SceneManager.LoadScene(1);

    }

    /// <summary>
    /// 離開遊戲
    /// </summary>
    private void QuitGame()
    {
        //退出遊戲
        //語法：應用程式.離開遊戲(); -> 應用程式 的 離開遊戲 
        Application.Quit();
    }

    #endregion

    private void Start()
    {
        fader.gameObject.SetActive(true);

        LeanTween.scale(fader, new Vector3(1, 1, 1), 0);

        LeanTween.scale(fader, Vector3.zero, 0.5f).setOnComplete(() =>
       {
           fader.gameObject.SetActive(false);
       });
    }


    public void OpenMenuScene()
    {
        fader.gameObject.SetActive(true);

        LeanTween.scale(fader, Vector3.zero, 0f);

        LeanTween.scale(fader, new Vector3(1, 1, 1), 0.5f).setOnComplete(() =>
        {
            SceneManager.LoadScene(0);
        });
    }


    private void OpenGameScene()
    {
        fader.gameObject.SetActive(true);

        LeanTween.scale(fader, Vector3.zero, 0f);

        LeanTween.scale(fader, new Vector3(1, 1, 1), 0.5f).setOnComplete(() =>
        {
            SceneManager.LoadScene(1);
        });
    }

    private void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
