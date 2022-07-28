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

    float inputX;

    public bool left = false;
   public bool right = false;

    LayerMask ground;

    Rigidbody2D rb;
   
    public bool canJump = false;

   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        


      



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

      


       jump();
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
