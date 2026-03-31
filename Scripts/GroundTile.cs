using UnityEngine;

public class GroundTile : MonoBehaviour
{
    [Header("components")]
    public float tileLength = 200f;
    public Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.z < player.position.z - tileLength)
        {
            transform.position += new Vector3(0, 0, tileLength * 3);
        }
    }
}

