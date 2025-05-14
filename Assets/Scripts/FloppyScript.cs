using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class FloppyScript : MonoBehaviour
{
    public Rigidbody2D FloppyRigid2D;
    public float FloppyFlapStrength;
    public float FloppyRotationRate;
    public bool isBirdAlive = true;

    // Reference
    public LogicScript logic;

    // Rotating animation
    public float rotationDuration = 0.25f;
    private bool isRotating = false;
    private bool isAccing = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space)==true) <--- this statement was deprecated
        if (Keyboard.current.spaceKey.isPressed && isBirdAlive && !isRotating)
        {
            FloppyRigid2D.linearVelocity = Vector2.up * FloppyFlapStrength;
        }

        if (Keyboard.current.shiftKey.isPressed && isBirdAlive)
        {
            if (!isAccing)
            {
                logic.PipeSpeedUp(true);
                isAccing = true;
            }

            if (!isRotating)
            {
                StartCoroutine(Rotate360());
            }
        }
        else if (isAccing)
        {
            logic.PipeSpeedUp(false);
            isAccing = false;
        }
    }
    IEnumerator Rotate360()
    {
        isRotating = true;

        bool originalFreezeState = FloppyRigid2D.freezeRotation;
        FloppyRigid2D.freezeRotation = true;

        float startRotation = FloppyRigid2D.rotation;
        float targetRotation = startRotation - 360f;
        float elapsedTime = 0f;

        while (elapsedTime < rotationDuration)
        {
            // �����ֵ����
            float t = elapsedTime / rotationDuration;

            // ƽ����ת
            FloppyRigid2D.rotation = Mathf.Lerp(startRotation, targetRotation, t);

            // ����ʱ�����
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        FloppyRigid2D.rotation = targetRotation;
        FloppyRigid2D.freezeRotation = originalFreezeState;
        isRotating = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PipeMoveScript pipeScript = null;

        pipeScript = collision.gameObject.GetComponent<PipeMoveScript>();

        // �����ǰ����û���������鸸����
        if (pipeScript == null && collision.transform.parent != null)
        {
            pipeScript = collision.transform.parent.GetComponent<PipeMoveScript>();
        }
        if (pipeScript == null) Debug.LogWarning("NULL PTR IN PIPEMOVE");
        if (isAccing && pipeScript!= null)
        {
            // ��ȡPipe�ĸ�����
            GameObject pipeToDestroy = pipeScript.gameObject;
            Debug.Log("���ٹܵ�: " + pipeToDestroy.name);

            // kill pipe
            logic.DestroyPipe(pipeToDestroy);
        }
        else
        {
            isBirdAlive = false;
            logic.GameOver();
        }
    }
}
