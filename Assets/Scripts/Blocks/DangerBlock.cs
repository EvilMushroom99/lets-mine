using UnityEngine;
using UnityEngine.Tilemaps;
using System.Threading.Tasks;

public class DangerBlock : MonoBehaviour, IBlockeable
{
    private readonly Vector3Int[] directions = { Vector3Int.up, Vector3Int.down, Vector3Int.left, Vector3Int.right };
    [SerializeField] private Tile[] stoneTiles;

    public async void DestroyBlock(Tilemap map, Vector3Int position, TileData tiledata, Player player)
    {
        map.SetTile(position, null);
        //Aca instanciar particula de transformacion o algo asi
        await Task.Delay(250);
        map.SetTile(position, stoneTiles[0]);
        tiledata.SetNewTile(position, stoneTiles[0]);
        AudioManager.Instance.PlayBox();
    }
}
