using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // Get input from WASD or arrow keys
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a new vector for movement
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;

        // Move the player
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}
