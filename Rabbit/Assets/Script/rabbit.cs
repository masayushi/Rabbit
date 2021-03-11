using UnityEngine;

public class rabbit : MonoBehaviour
{
    private void jump()
    {
        Input.GetKeyDown(KeyCode.Space);
    }

    private void idou()
    {
        float speed = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        transform.Rotate(0, speed, 0);
    }


    private void Update()
    {
        jump();
        idou();
    }


}
