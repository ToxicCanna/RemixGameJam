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

    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    private SpriteRenderer spriteRenderer;

    private Tilemap floorTilemap;
    private Tilemap currentTilemap;

    private bool isDead = false;

    [SerializeField] private CameraMove playerCamera;

    private void Start()
    {
        targetPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameObject floorTilemapObject = GameObject.Find("FloorTilemap");
        if (floorTilemapObject != null)
        {
            floorTilemap = floorTilemapObject.GetComponent<Tilemap>();
        }
    }

    private void Update()
    {
        if (isDead) return;

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
            UpdateSprite("Up");
            MovementCheck();
        }
        if (Input.GetKeyDown(Down))
        {
            targetPosition = new Vector2(transform.position.x, transform.position.y - gridSize.y);
            UpdateSprite("Down");
            MovementCheck();
        }
        if (Input.GetKeyDown(Left))
        {
            targetPosition = new Vector2(transform.position.x - gridSize.x, transform.position.y);
            UpdateSprite("Left");
            MovementCheck();
        }
        if (Input.GetKeyDown(Right))
        {
            targetPosition = new Vector2(transform.position.x + gridSize.x, transform.position.y);
            UpdateSprite("Right");
            MovementCheck();
        }
    }
    void MovementCheck()
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
                    currentTilemap.SetTile(targetTilePos, null);
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
                TeleportToStair(tile);
                isMoving = false;
                return;
            }
        }
        isMoving = true;
    }
    private void TeleportToStair(CustomTile stairTile)
    {
        transform.position = stairTile.targetPosition;
        Debug.Log($"Player teleported to new location: {stairTile.targetPosition}");
        playerCamera.ChangeFloor(stairTile.targetPosition.x, stairTile.targetPosition.y);
    }
    private void MoveTowardsTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if ((Vector2)transform.position == targetPosition)
        {
            isMoving = false;
        }
    }
    public void SetDead()
    {
        isDead = true;
    }

    private void UpdateSprite(string direction)
    {
        switch (direction)
        {
            case "Up":
                spriteRenderer.sprite = upSprite;
                break;
            case "Down":
                spriteRenderer.sprite = downSprite;
                break;
            case "Left":
                spriteRenderer.sprite = leftSprite;
                break;
            case "Right":
                spriteRenderer.sprite = rightSprite;
                break;
        }
    }
}
