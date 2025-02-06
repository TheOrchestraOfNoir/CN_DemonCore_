using UnityEngine;

public class PlayerMovementWithJump : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f; // Speed of the player
    public KeyCode upKey = KeyCode.W; // Key for moving up
    public KeyCode downKey = KeyCode.S; // Key for moving down
    public KeyCode leftKey = KeyCode.A; // Key for moving left
    public KeyCode rightKey = KeyCode.D; // Key for moving right

    [Header("Jump Settings")]
    public float jumpPower = 10f; // Power of each jump
    public int maxJumps = 3; // Maximum number of jumps allowed in the air
    public KeyCode jumpKey = KeyCode.Space; // Key for jumping

    [Header("Ground Check")]
    public Transform groundCheck; // Reference to a ground-checking object
    public float groundCheckRadius = 0.2f; // Radius of ground detection
    public LayerMask groundLayer; // Layers that count as "ground"

    private Rigidbody2D rb;
    private int jumpCount; // Tracks the number of jumps remaining
    private bool isGrounded; // Tracks whether the player is on the ground

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Handle movement input
        HandleMovement();

        // Handle jumping input
        if (Input.GetKeyDown(jumpKey) && jumpCount > 0)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        // Check if the player is grounded
        CheckGrounded();
    }

    private void HandleMovement()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(upKey)) movement.y += 1; // Move up
        if (Input.GetKey(downKey)) movement.y -= 1; // Move down
        if (Input.GetKey(leftKey)) movement.x -= 1; // Move left
        if (Input.GetKey(rightKey)) movement.x += 1; // Move right

        // Apply movement
        rb.MovePosition(transform.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    private void CheckGrounded()
    {
        // Detect if the player is grounded using Physics2D.OverlapCircle
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            // Reset jump count when grounded
            jumpCount = maxJumps;
        }
    }

    private void Jump()
    {
        // Apply jump force
        rb.velocity = new Vector2(rb.velocity.x, jumpPower);

        // Decrease the jump count
        jumpCount--;
        Debug.Log($"Jump! Remaining jumps: {jumpCount}");
    }

    void OnDrawGizmosSelected()
    {
        // Visualize the ground check area in the editor
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}

