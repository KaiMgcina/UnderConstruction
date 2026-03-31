using UnityEngine;

public class Barrel : MonoBehaviour
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
      
        Vector3 direction = new Vector3(0, 0, -1); // move forward along Z
        Vector3 targetPos = rb.position + direction * glideSpeed * Time.fixedDeltaTime;

        rb.MovePosition(targetPos);

       
        rb.AddTorque(Vector3.left * rollForce);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.LoseLife();
            Destroy(gameObject);
        }
    }
}
