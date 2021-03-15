using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class rabbit : MonoBehaviour
{
    #region 欄位

    public Transform Rabbit;

    [Header("移動")]
    public float idou;

    [Header("移動距離"), Range(0, 10)]
    public float idoukyouri = 1;

    [Header("垂直跳躍高度"), Range(0, 10)]
    public float jump = 15;

    [Header("跳躍距離"), Range(0, 15)]
    public float jumpkyouri = 1.2f;

    [Header("檢查地板射線")]
    public float lazer = 1f;

    [Header("檢查射線位移")]
    public Vector2 offset;


    private bool onground = true;

    private Rigidbody2D rig;

    #endregion
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.right);
        Gizmos.DrawRay(transform.position, Vector3.left);
        Gizmos.DrawRay(transform.position, Vector3.up);
        Gizmos.DrawRay(transform.position, Vector3.down);
    }

    private void Checkwall()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, lazer, 1 << 11);

        print(hit.transform.name);
    }

    /// <summary>
    /// 控制系統
    /// </summary>


    private void Update()
    {
        Idou();
    }

    private void FixedUpdate()
    {
        Jump();
    }

    /// <summary>
    /// 操作方法
    /// </summary>
    private void Idou()
    {
        float h = Input.GetAxisRaw("Horizontal");

        float v = Input.GetAxisRaw("Vertical");

        // rig.velocity = ((transform.forward + transform.forward) * idoukyouri * Time.deltaTime) + transform.up * rig.velocity.y;

        // rig.AddForce(new Vector2(h * idoukyouri, 0), ForceMode2D.Force);

    }

    private void Jump()
    {

        if (Input.GetKeyUp(KeyCode.Space) && onground)
        {
            onground = false;

            // rig.AddForce(new Vector2(0, 15), ForceMode2D.Impulse);
        }

    }


