using UnityEngine;

public class Hammer : MonoBehaviour
{
    public float rollForce = 10f;
    public float glideSpeed = 10f;
    public Transform player;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        
    }

    void FixedUpdate()
    {
        
        Vector3 direction = new Vector3(0, 0, -1); // move forward along Z axis
        Vector3 targetPos = rb.position + direction * glideSpeed * Time.fixedDeltaTime;

        rb.MovePosition(targetPos);

      
        rb.AddTorque(Vector3.left * rollForce);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))// Check if the collided object has the Player tag
        {
            GameManager.instance.LoseLife();//Player loses a life when hit by the hammer
            Destroy(gameObject);
        }
    }
}