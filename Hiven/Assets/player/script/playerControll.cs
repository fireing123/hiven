using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControll : MonoBehaviour
{

    public int move = 20;
    public int jump = 5;

    Rigidbody2D rb;

    public bool isground = false;

    void Start()
    {
        TryGetComponent(out rb);
    }

    
    void FixedUpdate()
    {
        Move(move);
        KeyEvent();
    }

    private void KeyEvent()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Jump(jump);
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
