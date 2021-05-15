using UnityEngine;

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

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(moveInput * speed, rig.velocity.y);
    }

    private void Update()
    {
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

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        CheckWall();
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(feetPos.position, Vector3.down * lenth);
    }

    private void CheckWall()
    {
        RaycastHit2D hit =  Physics2D.Raycast(feetPos.position, Vector3.down, lenth, 1 << 10);



        if (hit && hit.transform.name == "斜坡")
        {
            slope = true;
            print(transform.name);
        }
        else
        {
            slope = false;
        }

        if (slope == true)
        {
            speed = 0;
        }
        else
        {
            speed = 5;
        }
    }
}
