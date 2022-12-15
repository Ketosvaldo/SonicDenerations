using UnityEngine;
using UnityEngine.XR;

public class SonicController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sprite;
    public float speed, maxSpeed, aceleration, jumpForce, deceleration;
    public bool isIdle, isWalk, isRun, isJumping, isGround, isBrake;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent <SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Run(horizontal);
        Jump();
    }

    void Run(float horizontal)
    {
        if (horizontal != 0)
        {
            //Caso en que apenas empiece a correr
            if (rb.velocity.x == 0)
            {       
                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
                isIdle = false;
                isWalk = true;
            }
            //Caso en que de repente quiera cambiar de direccion mientras avanza
            else if ((horizontal * Mathf.Abs(rb.velocity.x)) != rb.velocity.x)
            {
                rb.velocity = new Vector3(rb.velocity.x + (horizontal * deceleration), rb.velocity.y);
                if(isRun)
                    isBrake = true;
            }
            //Caso en el que la aceleracion hace su trabajo
            else if (Mathf.Abs(rb.velocity.x) < (maxSpeed - 2))
            {
                rb.velocity = new Vector2(horizontal * (Mathf.Abs(rb.velocity.x) + aceleration), rb.velocity.y);
                isWalk = true;
                isRun = false;
                isBrake = false;
            }
            //Caso en el que llega a su maxima velocidad
            else
            {
                isIdle = false;
                isRun = true;
                isWalk = false;
                rb.velocity = new Vector2(horizontal * maxSpeed, rb.velocity.y);
            }
        }
        else
        {
            isRun = false;
            isWalk = false;
            isIdle = true;
            isBrake = false;
        }

        //FlipSprite
        if (horizontal > 0)
            sprite.flipX = false;
        else if (horizontal < 0)
            sprite.flipX = true;
            
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            isGround = true;
            //rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGround = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGround = true;
    }
}
