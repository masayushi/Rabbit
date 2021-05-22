using UnityEngine;
using UnityEngine.SceneManagement;


public class Leave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Gamestart()
    {
        // 載入指定場景
        // 場景管理器 的 載入場景("場景名稱")
        // 場景管理器 的 載入場景(1)
        //SceneManager.LoadScene("遊戲場景");

        SceneManager.LoadScene("選單");

    }
}
