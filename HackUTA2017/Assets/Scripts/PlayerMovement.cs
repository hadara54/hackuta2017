using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerMovementSpeed;
    public float jumpHeight;

    Rigidbody2D rigid;
    Animator anim;

    bool hasJumped = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Awake()
    {
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //anim.SetFloat("Speed",Mathf.Abs(playerMovementSpeed));
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(Input.GetAxis("Horizontal") * playerMovementSpeed * Time.deltaTime, 0, 0));
            anim.SetInteger("setMove", 1);
        }
        else
            anim.SetInteger("setMove", 0);
       
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
