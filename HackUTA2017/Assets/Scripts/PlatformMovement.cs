using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float moveDistX, moveDistY, moveSpeedX, moveSpeedY;
    float startPositionX, startPositionY, maxPositionX, minPositionX, maxPositionY, minPositionY;
    bool hasReachedTopX, hasReachedBottomX, hasReachedTopY, hasReachedBottomY;
    private void Awake()
    {
        startPositionX = transform.position.x;
        startPositionY = transform.position.y;
        maxPositionX = startPositionX + moveDistX;
        minPositionX = startPositionX - moveDistX;
        maxPositionY = startPositionY + moveDistY;
        minPositionY = startPositionY - moveDistY;
        hasReachedBottomX = true;
        hasReachedBottomY = true;
        hasReachedTopX = false;
        hasReachedTopY = false;
        if (moveSpeedX <= 0)
        {
            hasReachedBottomX = false;
            hasReachedTopX = false;
        }
        if (moveSpeedY <= 0)
        {
            hasReachedBottomY = false;
            hasReachedTopY = false;
        }
    }

    private void Update()
    {
        if (hasReachedBottomX)
        {
            transform.Translate(Vector2.right * moveSpeedX * Time.deltaTime);
            Debug.Log("Moving Right");
            if (transform.position.x >= maxPositionX)
            {
                hasReachedBottomX = false;
                hasReachedTopX = true;
                Debug.Log("Reached The Right");
            }
        }
        if (hasReachedTopX)
        {
            transform.Translate(Vector2.left * moveSpeedX * Time.deltaTime);
            Debug.Log("Moving Left");
            if (transform.position.x <= minPositionX)
            {
                hasReachedTopX = false;
                hasReachedBottomX = true;
                Debug.Log("Reached The Left");
            }
        }
        if (hasReachedBottomY)
        {
            transform.Translate(Vector2.up * moveSpeedY * Time.deltaTime);
            Debug.Log("Moving Up");
            if (transform.position.y >= maxPositionY)
            {
                hasReachedTopY = true;
                hasReachedBottomY = false;
                Debug.Log("Reached The Top");
            }
        }
        if (hasReachedTopY)
        {
            transform.Translate(Vector2.down * moveSpeedY * Time.deltaTime);
            Debug.Log("Moving Down");
            if (transform.position.y <= minPositionY)
            {
                hasReachedBottomY = true;
                hasReachedTopY = false;
                Debug.Log("Reached The Bottom");
            }
        }
    }
}
