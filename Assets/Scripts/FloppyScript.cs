using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FloppyScript : MonoBehaviour
{
    public Rigidbody2D FloppyRigid2D;
    public float FloppyFlapStrength;
    public bool isBirdAlive = true;
    public LogicScript logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
         // if (Input.GetKeyDown(KeyCode.Space)==true) <--- this statement was deprecated
        if (Keyboard.current.spaceKey.isPressed && isBirdAlive)
        {
            FloppyRigid2D.linearVelocity = Vector2.up * FloppyFlapStrength;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isBirdAlive = false;
        logic.GameOver();
    }
}
