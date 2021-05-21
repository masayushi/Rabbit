using UnityEngine;
using UnityEngine.SceneManagement;

public class Carrot : MonoBehaviour
{
    public GameObject gameOver;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("玩家"))
        {
            
        }
    }


}
