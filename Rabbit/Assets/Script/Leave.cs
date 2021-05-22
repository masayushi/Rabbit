using UnityEngine;
using UnityEngine.SceneManagement; 


public class Leave : MonoBehaviour
{

    private bool gameOver;

    private void Update()
    {
        if (gameOver) return;
    }
    public  void StartGame()
    {
        // 載入指定場景
        // 場景管理器 的 載入場景("場景名稱")
        // 場景管理器 的 載入場景(1)
        //SceneManager.LoadScene("遊戲場景");

        SceneManager.LoadScene(0);
    }

    private void GameOver()
    {
        if (!gameOver)
        {
            gameOver = false;
            StopAllCoroutines();
        }
    }

}
