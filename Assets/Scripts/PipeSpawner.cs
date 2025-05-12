using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2.0f;
    public float genPipeHeightOffset = 5.0f;
    private float timer = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PipeSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            PipeSpawn();
            timer = 0;
        }
    }
    void PipeSpawn()
    {
        float lowestPoint = transform.position.y - genPipeHeightOffset;
        float topPoint = transform.position.y + genPipeHeightOffset;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, topPoint ),0), transform.rotation);
    }
}
