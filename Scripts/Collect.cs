using UnityEngine;

public class Collect : MonoBehaviour
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
       
        Vector3 direction = new Vector3(0, 0, -1);
        Vector3 targetPos = rb.position + direction * glideSpeed * Time.fixedDeltaTime;

        rb.MovePosition(targetPos);

       
        rb.AddTorque(Vector3.left * rollForce);//makes the collectible roll
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))// Check if the collided object has the Player tag
        {
            GameManager.instance.AddPoints(1);//Player gains a point when collecting this item
            Destroy(gameObject);
        }
    }
}