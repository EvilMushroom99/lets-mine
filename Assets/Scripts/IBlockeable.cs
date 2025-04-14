using UnityEngine;
using UnityEngine.Tilemaps;

public interface IBlockeable
{
    public void DestroyBlock(Tilemap tilemap, Vector3Int position, TileData tiledata, Player player);
}
