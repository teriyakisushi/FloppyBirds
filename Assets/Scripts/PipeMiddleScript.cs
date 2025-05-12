using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript Logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject logicObj = GameObject.FindGameObjectWithTag("Logic");
        if (logicObj == null)
        {
            Debug.LogError("No GameObject with 'Logic' tag found!");
            return;
        }
        Logic = logicObj.GetComponent<LogicScript>();
        if (Logic == null)
        {
            Debug.LogError("No LogicScript component found on Logic GameObject!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Debug.Log("Bird Entered");
            Logic.AddScore(1);

        }
    }
}
