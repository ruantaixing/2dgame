using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed;
    float dir;
    bool isGrounded;
    public float jumpForce = 5;
    private int extraJump;
    public int extraJumpValue = 1;
    Rigidbody2D body;
    Animator aniem;
    bool isRightFace = true;
    [SerializeField] Transform groundcheck;
    [SerializeField] LayerMask ground;
    [SerializeField] LayerMask wallLayer;

    private CapsuleCollider2D capCollider;

    // Start is called before the first frame update
    void Start()
    {
        extraJump = extraJumpValue;
        body = GetComponent<Rigidbody2D>();
        aniem = GetComponent<Animator>();
        capCollider = GetComponent<CapsuleCollider2D>();
    }


    private void Update()
    {
        if (isGrounded == true) extraJump = extraJumpValue;
        if (Input.GetKeyDown(KeyCode.Space) && extraJump > 0)
        {
            Jump();
            extraJump--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJump == 0 && isGrounded == true)
        {
            Jump();

        }


    }

    void FixedUpdate()
    {
        isGround();
        //Debug.Log(isGrounded);
        aniem.SetBool("isGround", isGrounded);
        float dir = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(dir * speed * Time.fixedDeltaTime, body.velocity.y);
        aniem.SetFloat("speed", Mathf.Abs(dir));

        if (isRightFace && dir < 0 || !isRightFace && dir > 0)
            Flip();

    }

    void Flip()
    {
        isRightFace = !isRightFace;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpForce);

    }
    bool isGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, 0.1f, ground);
        return isGrounded;
    }
    bool onWall()
    {
        RaycastHit2D raycasthit = Physics2D.BoxCast(capCollider.bounds.center, capCollider.bounds.size, 0, new Vector2(
            transform.localScale.x, 0), 0.1f, wallLayer);
        return raycasthit.collider != null;
    }

    public bool canAttack()
    {
        return dir == 0 && isGrounded && !onWall();
    }


}
