using UnityEngine;
using UnityEngine.Tilemaps;

public class TileLighting : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private int maxwidth;
    [SerializeField] private int maxheight;

    [SerializeField] private Tile blackTile;
    [SerializeField] private Tile semiBlackTile;

    private readonly Vector3Int[] directions = { Vector3Int.up, Vector3Int.down, Vector3Int.left, Vector3Int.right };

    private void Start()
    {
        CreateTileLighting();
    }

    public void CreateTileLighting()
    {
        for (int x = 0; x < maxwidth; x++)
        {
            for (int y = maxheight; y < -2; y++)
            {
                Vector3Int position = new Vector3Int(x, y, 0);

                tilemap.SetTile(position, blackTile);
            }

            tilemap.SetTile(new Vector3Int(x, -2, 0), semiBlackTile);
        }
    }

    public void ChangeLight(Vector3Int pos)
    {
        foreach (Vector3Int dir in directions)
        {
            if (tilemap.GetTile(pos + dir) != null)
            {
                tilemap.SetTile(pos + dir, null);
                ChangeLightAdjacent(pos + dir);
            }

        }
    }

    private void ChangeLightAdjacent(Vector3Int pos)
    {
        foreach (Vector3Int dir in directions)
        {
            if (tilemap.GetTile(pos + dir) != null)
            {
                tilemap.SetTile(pos + dir, semiBlackTile);
            }
        }
    }
}
