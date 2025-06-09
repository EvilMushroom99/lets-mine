using UnityEngine;
using UnityEngine.Tilemaps;

public class MultiplierBlock : MonoBehaviour, IBlockeable
{
    [SerializeField] private AudioManager audioManager;

    public void DestroyBlock(Tilemap map, Vector3Int position, TileData tiledata, Player player)
    {
        map.SetTile(position, null);
        player.AddGoldMultiplier();
        AudioManager.Instance.PlayBox();
    }
}
