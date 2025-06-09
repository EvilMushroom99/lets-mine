using UnityEngine;
using UnityEngine.Tilemaps;

public class PickaxeBlock : MonoBehaviour, IBlockeable
{
    public void DestroyBlock(Tilemap map, Vector3Int position, TileData tiledata, Player player)
    {
        map.SetTile(position, null);
        player.AddClics(4);
        AudioManager.Instance.PlayBox();
    }
}
