using UnityEngine;
using UnityEngine.Events;

public class rabbittry : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed;
    public float jumpForce;
    private float moveInput;

    private bool onground;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    public bool slope;
    public float lenth;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;


    private AudioSource aud;

    [Header("跳躍音效")]
    public AudioClip jumpsound;

 



    private void Start()
    {
        aud = GetComponent<AudioSource>();
        rig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(moveInput * speed, rig.velocity.y);
    }

    private void Update()
    {
        #region 位移、翻面判定

        onground = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }


        if (onground == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rig.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rig.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        //防止二段跳
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
            if (onground == false)
            {
                aud.PlayOneShot(jumpsound, Random.Range(0f, 0f));
            }
        }

        CheckSlope();
        #endregion

        #region 音效調整(跳躍時按跳躍不再有音效)

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            if (isJumping == true)
            {
                aud.PlayOneShot(jumpsound, Random.Range(0.8f, 1f));
            }
        }
        else if (onground == false)
        {
            aud.PlayOneShot(jumpsound, Random.Range(0f, 0f));
        }

        #endregion


    }

    #region 斜坡操作設定
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(feetPos.position, Vector3.down * lenth);
        Gizmos.DrawRay(feetPos.position, Vector3.left * lenth);
        Gizmos.DrawRay(feetPos.position, Vector3.right * lenth);
    }

    private void CheckSlope()
    {
        RaycastHit2D hit = Physics2D.Raycast(feetPos.position, Vector3.down, lenth, 1 << 10);

        #region 偵測斜坡

        if (hit && hit.transform.name == "斜坡" || hit && hit.transform.name == "斜坡地板區(斜坡)" || hit && hit.transform.name == "第一斜坡(斜坡)") {slope = true;}  else {slope = false;}

        if (slope == true){speed = 0;}  else {speed = 5;}
        
        #endregion 
    }

    #endregion


}
