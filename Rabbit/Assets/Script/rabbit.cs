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
    public float jump = 1;

    [Header("跳躍距離"), Range(0, 15)]
    public float jumpkyouri = 1f;

    [Header("檢查地板射線")]
    public float lazer = 0.5f;

    [Header("檢查射線位移")]
    public Vector3 offset;

    /// <summary>
    /// 是否有碰到地板
    /// </summary>
    private bool onground = true;

    private Rigidbody2D rig;

    #endregion
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        lazer = 0.5f;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + offset, Vector3.right);
        Gizmos.DrawRay(transform.position + offset, Vector3.left);
        Gizmos.DrawRay(transform.position + offset, Vector3.down);
    }

    /// <summary>
    /// 是否碰到地板
    /// </summary>
    private bool Lkabe;

    private bool Rkabe;

    private void Checkwall()
    {
        RaycastHit2D hitL = Physics2D.Raycast(transform.position, Vector3.left, lazer);

        if (hitL && hitL.transform.name == "牆壁(左)" )
        {
            Lkabe = true;
        }
        else
        {
            Lkabe = false;
        }

        RaycastHit2D hitR = Physics2D.Raycast(transform.position, Vector3.left, lazer);

        if (hitR && hitR.transform.name == "牆壁(右)")
        {
            Lkabe = true;
        }
        else
        {
            Lkabe = false;
        }
    }

    /// <summary>
    /// 控制系統
    /// </summary>


    private void Update()
    {
        Checkwall();
    }

    private void FixedUpdate()
    {
        Jump();
        Idou();
    }

    /// <summary>
    /// 操作方法
    /// </summary>
    private void Idou()
    {
        float h = Input.GetAxisRaw("Horizontal");

        float v = Input.GetAxisRaw("Vertical");

        rig.velocity = ((transform.forward) * idoukyouri * Time.deltaTime) + transform.up * rig.velocity.y;

        rig.AddForce(new Vector2(h * idoukyouri, 0), ForceMode2D.Force);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rig.AddForce(new Vector2(-250, 0), ForceMode2D.Force);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rig.AddForce(new Vector2(250, 0), ForceMode2D.Force);
        }

        print(transform.position);

    }

    /// <summary>
    /// 跳躍控制
    /// </summary>
    private void Jump()
    {

        if (Input.GetKeyDown(KeyCode.Space) && onground)
        {
            onground = false;

            rig.AddForce(new Vector2(0, 500), ForceMode2D.Force);
        }

      Collider2D hit = Physics2D.OverlapCircle(transform.position + offset, lazer, 1 << 8);


        if (hit) onground = true;
    }
}

