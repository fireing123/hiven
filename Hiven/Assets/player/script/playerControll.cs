using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{

    public int move = 70;
    public int running = 140;
    public int jump = 5;

    Rigidbody2D rb;

    public bool isground = false;

    void Start()
    {
        TryGetComponent(out rb);
    }

    
    void FixedUpdate()
    {
        if (GameModeManger.isCanPlayerMove)
        {
            if (GameModeManger.isPlayerRun)
            {
                Move(running);
                Debug.Log("Run");
            } else
            {
                Move(move);
                Debug.Log("Move");
            }
        }
        KeyEvent();
    }

    private void KeyEvent()
    {
        if (Input.GetKey(KeyCode.Space) && GameModeManger.isCanPlayerJump)
        {
            Jump(jump);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameModeManger.Running();
            Debug.Log("Running");
        } 
        if (Input.GetKeyDown(KeyCode.T))
        {
            GameModeManger.Moving();
            Debug.Log("Moving");
        }

    }

    private void Move(int _move)
    {
        Vector3 vector = Vector3.zero;

        vector.x =  (float) (Input.GetAxisRaw("Horizontal") * _move * 0.001);

        transform.position += vector;
    }

    private void Jump(int _jump)
    {
        if (isground)
        {
            rb.AddForce(new Vector2(0, _jump), ForceMode2D.Impulse);
            isground = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isground = true;
        }
    }
}
