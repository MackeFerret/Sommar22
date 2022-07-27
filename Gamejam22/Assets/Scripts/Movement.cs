using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float jumpHeight = 0f;
    [SerializeField] float speed = 10.0f;
    [SerializeField] private LayerMask groundLayer;
    private BoxCollider2D boxCollider;

    float inputX;

    LayerMask ground;

    Rigidbody2D rb;
   
    public bool canJump = false;

   

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        


        rb = GetComponent<Rigidbody2D>();



        // float h = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.A))
        {
            if(canJump == true)
            {
                rb.AddForce(new Vector2(-speed * Time.deltaTime,  0));
            }
          
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (canJump == true)
            {
                rb.AddForce(new Vector2(speed  * Time.deltaTime, 0));
            }
          
        }

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
        if(canJump == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
            }

            //float h = Input.GetAxisRaw("Horizontal");
            // float v = Input.GetAxisRaw("Jump");
            // gameObject.transform.position = new Vector2(transform.position.x + (h * speed), transform.position.y + (v * jumpHeight));
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
