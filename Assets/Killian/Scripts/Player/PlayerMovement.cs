using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Vector2 gridSize = new Vector2(1, 1);
    private Vector2 targetPosition;
    private bool isMoving = false;

    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Left;
    public KeyCode Right;

    private Tilemap[] floorTilemaps;
    private Tilemap currentTilemap;
    private int currentFloor;

    private void Start()
    {
        targetPosition = transform.position;
        floorTilemaps = UnityEngine.Object.FindObjectsByType<Tilemap>(FindObjectsSortMode.None);
        if (currentFloor >= 0 && currentFloor < floorTilemaps.Length)
        {
            currentTilemap = floorTilemaps[currentFloor];
        }
        else
        {
            Debug.LogError("Current floor index is out of range!");
        }
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
        foreach (var tilemap in floorTilemaps)
        {

            Vector3Int targetTilePos = currentTilemap.WorldToCell(targetPosition);

        CustomTile tile = currentTilemap.GetTile<CustomTile>(targetTilePos);

            if (tile != null)
            {
                if (tile.tileType == CustomTile.TileType.Wall)
                {
                    Debug.Log("Can't move into a wall!");
                    isMoving = false;
                    return;
                }
                else if (tile.tileType == CustomTile.TileType.Door)
                {
                    if (PlayerStats.Instance.CanPay(tile.requiredKeyColor))
                    {
                        Debug.Log("Door unlocked!");
                        isMoving = true;
                        return;
                    }
                    else
                    {
                        Debug.Log("This door is locked!");
                        isMoving = false;
                        return;
                    }
                }
                else if (tile.tileType == CustomTile.TileType.Stair)
                {
                    SwitchFloor(tile.targetFloor, tile.targetPosition);
                    isMoving = true;
                    return;
                }
            }
        }
        isMoving = true;
    }
    private void MoveTowardsTarget()
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if ((Vector2)transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    private void SwitchFloor(int targetFloor, Vector3 targetPosition)
    {
        this.currentFloor = targetFloor;

        currentTilemap = floorTilemaps[currentFloor];

        this.targetPosition = targetPosition;
        transform.position = targetPosition;

        Debug.Log($"Switched to floor {currentFloor} at position {targetPosition}");
    }
}
