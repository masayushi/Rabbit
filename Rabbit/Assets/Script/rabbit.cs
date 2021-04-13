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
    public float lazer = 1f;

    [Header("檢查射線位移")]
    public Vector3 offset;

    [Header("跳躍蓄力值")]
    public float jumpPressure = 0f;

    [Header("蓄力最小值")]
    public float minijumpPressure = 3f;

    [Header("蓄力最大值")]
    public float maxjumpPressure = 5f;


    private Rigidbody2D rig;

    #endregion
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        lazer = 1f;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + offset, Vector3.right);
        Gizmos.DrawRay(transform.position + offset, Vector3.left);

        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position + offset, -Vector3.up);
    }

    /// <summary>
    /// 是否有碰到地板
    /// </summary>

    private bool onground;

    /// <summary>
    /// 是否碰到牆壁
    /// </summary>

    private bool Lkabe;

    private bool Rkabe;


    private void Checkwall()
    {
        RaycastHit2D hitL = Physics2D.Raycast(transform.position, Vector3.left, lazer, 1 << 11);

        if (hitL && hitL.transform.name == "牆壁(左)")
        {
            Lkabe = true;
        }
        else
        {
            Lkabe = false;
        }

        RaycastHit2D hitR = Physics2D.Raycast(transform.position, -Vector3.left, lazer, 1 << 12);

        if (hitR && hitR.transform.name == "牆壁(右)")
        {
            Rkabe = true;
        }
        else
        {
            Rkabe = false;
        }

        RaycastHit2D hitD = Physics2D.Raycast(transform.position, -Vector3.up, lazer, 1 << 8);

        if (hitR && hitR.transform.name == "地板")
        {
            onground = true;
        }
        else
        {
            onground = false;
        }
    }

    #region 控制系統


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
        float h = Input.GetAxis("Horizontal");

        float v = Input.GetAxis("Vertical");

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
        if (onground)
        {
            if (Input.GetKey("Jump"))
            {
                if (jumpPressure < maxjumpPressure)     // 如果當前蓄力值小於最大值
                {
                    jumpPressure += Time.deltaTime * 3f;     // 則每偵遞增當前蓄力值
                }
                else
                {
                    jumpPressure = maxjumpPressure;     // 達到最大值時，當前的蓄力值就等於最大蓄力值
                }
            }
        }

    }


    #endregion

}