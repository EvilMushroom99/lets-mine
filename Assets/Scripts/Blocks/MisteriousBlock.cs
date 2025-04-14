using UnityEngine;
using UnityEngine.Tilemaps;

public class MisteriousBlock : MonoBehaviour, IBlockeable
{
    [SerializeField]
    [Tooltip("Solo scripts que implementen IBlockeable")]
    private MonoBehaviour[] blockScritps;

    public void DestroyBlock(Tilemap map, Vector3Int position, TileData tiledata, Player player)
    {
        blockScritps[Random.Range(0, blockScritps.Length)].GetComponent<IBlockeable>().DestroyBlock(map, position, tiledata, player); // Borra el tile, segun el bloque
    }
}
