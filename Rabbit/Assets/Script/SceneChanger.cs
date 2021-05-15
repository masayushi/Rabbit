using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [Header("連接到其他場景")]
    public string GoToScene;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("玩家"))
        {
            SceneManager.LoadScene(GoToScene);
        }
    }


    private void Quitgame()
    {
        //退出遊戲
        //語法：應用程式.離開遊戲(); -> 應用程式 的 離開遊戲 
        Application.Quit();
    }
}
