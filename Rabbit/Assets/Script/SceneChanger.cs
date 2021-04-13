using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [Header("連接到其他場景")]
    public string GoToScene;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("usagi_T"))
        {
            SceneManager.LoadScene(GoToScene);
        }
    }

}
