using UnityEngine;

public class gameover : MonoBehaviour
{
    private bool Gameover;
    private bool Rabbit;

    private void GameOver()
    {
        if (Rabbit == true)
        {
            Gameover = true;
        }
    }

    private void Update()
    {
        GameOver();
    }



}
