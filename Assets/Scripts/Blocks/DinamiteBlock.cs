using UnityEngine;
using UnityEngine.Tilemaps;

public class DinamiteBlock : MonoBehaviour, IBlockeable
{
    private readonly Vector3Int[] directions = { Vector3Int.up, Vector3Int.down, Vector3Int.left, Vector3Int.right };

    public void DestroyBlock(Tilemap map, Vector3Int position, TileData tiledata, Player player)
    {
        map.SetTile(position, null);
        ExplodeBomb(position, map, tiledata, player);
    }

    private void ExplodeBomb(Vector3Int pos, Tilemap tilemap, TileData tiledata, Player player)
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
                    ExplodeBombAdjacent(newPos, tilemap, tiledata, player);
                }
            }

        }
    }

    private void ExplodeBombAdjacent(Vector3Int pos, Tilemap tilemap, TileData tiledata, Player player)
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
        }
    }
}
