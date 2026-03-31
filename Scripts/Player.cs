using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;// Speed at which the player moves left and right

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 move = Vector3.zero;

        if (Keyboard.current.leftArrowKey.isPressed)// Check if the left arrow key is pressed
            move += Vector3.left;// Move left

        if (Keyboard.current.rightArrowKey.isPressed)// Check if the right arrow key is pressed
            move += Vector3.right;// Move right

        move = move.normalized * moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + move);
    }
}