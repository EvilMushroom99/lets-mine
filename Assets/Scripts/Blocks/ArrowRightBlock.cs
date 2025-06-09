using UnityEngine;
using UnityEngine.Tilemaps;
using System.Threading.Tasks;

public class ArrowRightBlock : MonoBehaviour, IBlockeable
{
    private readonly Vector3Int[] directions = { Vector3Int.right, Vector3Int.right * 2, Vector3Int.right * 3, Vector3Int.right * 4 };

    public void DestroyBlock(Tilemap map, Vector3Int position, TileData tiledata, Player player)
    {
        map.SetTile(position, null);
        DamageTiles(position, map, tiledata, player);
        AudioManager.Instance.PlayBox();
    }

    private async void DamageTiles(Vector3Int pos, Tilemap tilemap, TileData tiledata, Player player)
    {
        foreach (Vector3Int dir in directions)
        {
            Vector3Int newPos = pos + dir;
            if (tilemap.GetTile(newPos) != null)
            {
                if (newPos.x > -1 && newPos.x < 6)
                {
                    int underScoreIndex = tilemap.GetTile(newPos).name.IndexOf('_');
                    int blockIndex = int.Parse(tilemap.GetTile(newPos).name.Substring(0, underScoreIndex));
                    tiledata.DamageTile(newPos, player.bombDamage, blockIndex);
                }
            }
            await Task.Delay(100);
        }
    }
}
