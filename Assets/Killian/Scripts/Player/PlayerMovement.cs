using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 gridSize = new Vector2(1, 1);
    private Vector2 targetPosition;
    private bool isMoving = false;

    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Left;
    public KeyCode Right;

    private void Start()
    {
        targetPosition = transform.position;
    }

    private void Update()
    {
        if (!isMoving)
        {
            HandleInput();
        }
        if (isMoving)
        {
            MoveTowardsTarget();
        }
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(Up))
        {
            targetPosition = new Vector2(transform.position.x, transform.position.y + gridSize.y);
            MovementCheck();
        }
        if (Input.GetKeyDown(Down))
        {
            targetPosition = new Vector2(transform.position.x, transform.position.y - gridSize.y);
            MovementCheck();
        }
        if (Input.GetKeyDown(Left))
        {
            targetPosition = new Vector2(transform.position.x - gridSize.x, transform.position.y);
            MovementCheck();
        }
        if (Input.GetKeyDown(Right))
        {
            targetPosition = new Vector2(transform.position.x + gridSize.x, transform.position.y);
            MovementCheck();
        }
    }
    void MovementCheck()
    {
        isMoving = true;
    }
    private void MoveTowardsTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if((Vector2)transform.position == targetPosition)
        {
            isMoving = false;
        }
    }
    
}
