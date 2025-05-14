using UnityEngine;

public class bgCloud : MonoBehaviour
{
    public float CloudMoveSpeed = 2.5f;
    public float CloudMoveMultiplier = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * CloudMoveSpeed) * Time.deltaTime;
        // Move the cloud to the right when it goes off screen
        if (transform.position.x < -31.0f)
        {
            transform.position = new Vector3(30.0f, transform.position.y, transform.position.z);
        }
    }
}
