using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float jumpHeight = 0f;
    [SerializeField] float jumpHeightx = 0f;
    public float jumpx;
    [SerializeField] float speed = 10.0f;
    [SerializeField] private LayerMask groundLayer;
    private BoxCollider2D boxCollider;
    public bool jumpReady;
    public float jumpCD = 1.2f;
    public float jumpCDCurrent = 0.0f;
    private Animator anim;
    private bool grounded;
    private Rigidbody2D body;

    float inputX;

   public bool left = false;
   public bool right = false;

    LayerMask ground;

    Rigidbody2D rb;
   
    public bool canJump = false;

   

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);


        anim.SetBool("Cat idle", horizontalInput != 0);
        
       // anim.SetTrigger("jump");



        // float h = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.A))
        {
            if(canJump == true)
            {
                
                rb.AddForce(new Vector2(-speed * 50 * Time.deltaTime,  0));
                if (canJump == true && (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.A)))
                {
                    left = true;
                    if (left == true)
                    {

                        canJump = false;
                        Invoke("catJumpLeft", 0.5f);
                       
                    }

                }
            }
          
        }
        else
        left = false;
        if (Input.GetKey(KeyCode.D))
        {
            if (canJump == true)
            {
              
                rb.AddForce(new Vector2(speed * 50 * Time.deltaTime, 0));
                if (canJump == true && (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.D)))
                {

                    right = true;
                    {
                        if (right == true)
                        {
                            canJump = false;
                            Invoke("catJumpRight", 0.5f);
                          
                        }
                    }



                }
            }

        }
        else
            right = false;



        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            jump();
            anim.SetTrigger("Grounded");
        }
        


    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        grounded = false;
      

    }





    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;

    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        canJump = true;

  
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canJump = false;
    }
    void jump()
    {
        if (canJump == true && left == false && right == false)
        {
            //catJump();
            if (Input.GetKey(KeyCode.Space))
            {
                canJump = false;
                Invoke("catJump", 0.5f);

               
            }

        }
  
       
    }
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    public void catJump()
    {

        rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
        Invoke("timer", 0.5f);
        print("mid");
    }
    public void catJumpLeft()
    {


       
        rb.AddForce(new Vector2(-jumpx * 10, jumpHeightx*10));
        Invoke("timer", 0.5f);
        print("left");
    }
    public void catJumpRight()
    {
        rb.AddForce(new Vector2(jumpx * 10, jumpHeightx*10));

        print("right");
        Invoke("timer", 0.5f);
    }
    public void timer()
    {

    }
    
}
