using UnityEngine;
using UnityEngine.Tilemaps;

public class NormalBlock : MonoBehaviour, IBlockeable
{
    public void DestroyBlock(Tilemap map, Vector3Int position, TileData tiledata, Player player)
    {
        map.SetTile(position, null);
    }
}
