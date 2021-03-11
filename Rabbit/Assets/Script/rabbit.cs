using UnityEngine;

public class rabbit : MonoBehaviour
{
    #region 欄位
    [Header("移動距離"), Range(0, 5)]
    public float idou = 0.5f;

    [Header("垂直跳躍高度"), Range(0, 10)]
    public float jump = 1;

    [Header("跳躍距離"), Range(0, 15)]
    public float jumpkyouri = 1.2f;

    public Transform Rabbit;

    #endregion

    private void Start()
    {
        print("兔子座標" + Rabbit.position);
        Move();
    }


    private void Move()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.right);
        Gizmos.DrawRay(transform.position, Vector3.left);
        Gizmos.DrawRay(transform.position, Vector3.up);
        Gizmos.DrawRay(transform.position, Vector3.down);
    }






}
