using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the player
    public KeyCode upKey = KeyCode.W; // Key for moving up
    public KeyCode downKey = KeyCode.S; // Key for moving down
    public KeyCode leftKey = KeyCode.A; // Key for moving left
    public KeyCode rightKey = KeyCode.D; // Key for moving right

    void Update()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(upKey)) movement.y += 1; // Move up
        if (Input.GetKey(downKey)) movement.y -= 1; // Move down
        if (Input.GetKey(leftKey)) movement.x -= 1; // Move left
        if (Input.GetKey(rightKey)) movement.x += 1; // Move right

        //transform.position += movement.normalized * speed * Time.deltaTime; // Apply movement
        GetComponent<Rigidbody2D>().MovePosition(transform.position + movement.normalized * speed * Time.deltaTime);
    }
}
