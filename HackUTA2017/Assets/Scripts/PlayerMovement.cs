using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerMovementSpeed;
    public float jumpHeight;

    private void Update()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * playerMovementSpeed * Time.deltaTime, 0, 0));
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            transform.Translate(Vector2.up * jumpHeight * Time.deltaTime);
    }
}
