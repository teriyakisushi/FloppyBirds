using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float MoveSpeed;
    public float DeadZone = -19.0f;

    private LogicScript logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        MoveSpeed = logic.PipeMoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        MoveSpeed = logic.PipeMoveSpeed;
        PipeMove(MoveSpeed);
        if(transform.position.x < DeadZone)
        {
            KillPipe(gameObject);
        }
    }

    private void PipeMove(float mSpeed)
    {
        transform.position = transform.position + (Vector3.left * mSpeed) * Time.deltaTime;

    }

    void KillPipe(GameObject pipeObject)
    {
        Destroy(pipeObject);
    }
}
