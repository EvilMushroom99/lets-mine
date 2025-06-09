using UnityEngine;
using UnityEngine.Tilemaps;
using System.Threading.Tasks;

public class AllSidesBlock : MonoBehaviour, IBlockeable
{
    private readonly Vector3Int[] directionsUp = { Vector3Int.up, Vector3Int.up * 2, Vector3Int.up * 3, Vector3Int.up * 4 };
    private readonly Vector3Int[] directionsDown = { Vector3Int.down, Vector3Int.down * 2, Vector3Int.down * 3, Vector3Int.down * 4 };
    private readonly Vector3Int[] directionsRight = { Vector3Int.right, Vector3Int.right * 2, Vector3Int.right * 3, Vector3Int.right * 4 };
    private readonly Vector3Int[] directionsLeft = { Vector3Int.left, Vector3Int.left * 2, Vector3Int.left * 3, Vector3Int.left * 4 };

    public void DestroyBlock(Tilemap map, Vector3Int position, TileData tiledata, Player player)
    {
        map.SetTile(position, null);
        DamageTiles(position, map, tiledata, player);
        AudioManager.Instance.PlayBox();
    }

    private async void DamageTiles(Vector3Int pos, Tilemap tilemap, TileData tiledata, Player player)
    {
        for (int i = 0; i < 4; i++)
        {
            Vector3Int dir = directionsUp[i];
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
            dir = directionsDown[i];
            newPos = pos + dir;
            if (tilemap.GetTile(newPos) != null)
            {
                if (newPos.x > -1 && newPos.x < 6)
                {
                    int underScoreIndex = tilemap.GetTile(newPos).name.IndexOf('_');
                    int blockIndex = int.Parse(tilemap.GetTile(newPos).name.Substring(0, underScoreIndex));
                    tiledata.DamageTile(newPos, player.bombDamage, blockIndex);
                }
            }

            dir = directionsRight[i];
            newPos = pos + dir;
            if (tilemap.GetTile(newPos) != null)
            {
                if (newPos.x > -1 && newPos.x < 6)
                {
                    int underScoreIndex = tilemap.GetTile(newPos).name.IndexOf('_');
                    int blockIndex = int.Parse(tilemap.GetTile(newPos).name.Substring(0, underScoreIndex));
                    tiledata.DamageTile(newPos, player.bombDamage, blockIndex);
                }
            }

            dir = directionsLeft[i];
            newPos = pos + dir;
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
