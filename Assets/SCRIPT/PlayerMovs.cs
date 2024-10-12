using UnityEngine;

public class PlayerMovs : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float ceilingForce = 20f;
    public float GroundForce = 20f;
    [SerializeField] float horizontalForce;
   
   

    public Animator anim;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Debug.Log(verticalInput);

        // Handle horizontal movement
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);


        // Flip the sprite horizontally if moving left
        if (horizontalInput < 0)
        {
            anim.SetFloat("run", Mathf.Abs(horizontalInput));
            spriteRenderer.flipX = true;

        }
        else if (horizontalInput > 0)
        {
            anim.SetFloat("run", Mathf.Abs(horizontalInput));
            spriteRenderer.flipX = false;

        }

        if (verticalInput > 0)
        {

           
            spriteRenderer.flipY = true;
            rb.AddForce(Vector2.up * GroundForce, ForceMode2D.Force);
        }
        else if (verticalInput < 0)
        {

          
            spriteRenderer.flipY = false ;
            rb.AddForce(Vector2.down * ceilingForce, ForceMode2D.Force);
        }


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ceiling"))
        {
            // Add force in the horizontal direction to help the player stay on the ceiling
            float horizontalInput = Input.GetAxis("Horizontal");
            rb.AddForce(Vector2.right * horizontalInput * horizontalForce, ForceMode2D.Force);

            // Add force in the upward direction to counteract gravity and keep the player on the ceiling
            rb.AddForce(Vector2.up * ceilingForce, ForceMode2D.Force);
        }
    }
}

