using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 6.5f;

    private const float FallThreshold = -6f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float fixedX;


void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fixedX = transform.position.x;
    }

void Update()
    {
        // Lock X position so platforms don't push the player
        Vector3 pos = transform.position;
        pos.x = fixedX;
        transform.position = pos;

        if (Input.anyKeyDown && isGrounded)
        {
            rb.linearVelocity = new Vector2(0f, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }

        if (transform.position.y < FallThreshold)
            GameManager.Instance.GameOver();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
            isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
            isGrounded = false;
    }
}
