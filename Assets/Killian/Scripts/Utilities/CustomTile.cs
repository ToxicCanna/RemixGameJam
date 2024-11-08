using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "NewCustomTile", menuName = "Tiles/Custom Tile")]
public class CustomTile : TileBase
{
    public enum TileType { Empty, Wall, Door, Stair }
    public TileType tileType;
    public PlayerStats.KeyColor requiredKeyColor;
    public Vector3 targetPosition;

    public Sprite wallSprite;
    public Sprite doorSprite;
    public Sprite stairSprite;

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        base.GetTileData(position, tilemap, ref tileData);

        if (tileType == TileType.Wall)
        {
            tileData.sprite = wallSprite != null ? wallSprite : Resources.Load<Sprite>("Sprites/WallSprite");
        }
        else if (tileType == TileType.Door)
        {
            tileData.sprite = doorSprite != null ? doorSprite : Resources.Load<Sprite>("Sprites/DoorSprite");
        }
        else if (tileType == TileType.Stair)
        {
            tileData.sprite = stairSprite != null ? stairSprite : Resources.Load<Sprite>("Sprites/StairSprite");
        }
        else
        {
            tileData.sprite = null;
        }

        if (tileType == TileType.Wall || tileType == TileType.Door || tileType == TileType.Stair)
        {
            tileData.colliderType = Tile.ColliderType.Grid;
        }
        else
        {
            tileData.colliderType = Tile.ColliderType.None;
        }
    }
}
