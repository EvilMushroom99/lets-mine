using UnityEngine;
using UnityEngine.Tilemaps;

public class GoldBlock : MonoBehaviour, IBlockeable
{
    [SerializeField] private int gold;

    public void DestroyBlock(Tilemap map, Vector3Int position, TileData tiledata, Player player)
    {
        map.SetTile(position, null);
        player.AddGold(gold);
    }
}
