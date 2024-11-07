using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "NewFloorTile", menuName = "Tiles/Floor Tile")]
public class FloorTile : TileBase
{
    public Sprite floorSprite; // A sprite for the floor

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        base.GetTileData(position, tilemap, ref tileData);
        tileData.sprite = floorSprite;
        tileData.colliderType = Tile.ColliderType.None;
    }
}
