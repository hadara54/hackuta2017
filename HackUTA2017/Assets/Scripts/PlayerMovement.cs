using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerMovementSpeed;
    public float jumpHeight;

    Rigidbody2D rigid;

    bool hasJumped = false;

    private void Awake()
    {
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * playerMovementSpeed * Time.deltaTime, 0, 0));
       
    }
    private void FixedUpdate()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && !hasJumped)
        {
            rigid.AddForce(Vector2.up * jumpHeight * Time.fixedDeltaTime);
            hasJumped = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            hasJumped = false;
    }
}
