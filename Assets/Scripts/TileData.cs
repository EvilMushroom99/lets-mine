using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileData : MonoBehaviour
{
    public Tilemap tilemap;
    [SerializeField] private PlayerUI playerUI;
    [SerializeField] private Player player;
    [SerializeField] private CameraMovement cameraMovement;
    [SerializeField] private CoinCollector coinCollector;
    [SerializeField] private TileLighting tileLighting;

    [SerializeField] private Dictionary<Vector3Int, float> tileHealth = new Dictionary<Vector3Int, float>();
    private readonly Vector3Int[] directions = { Vector3Int.up, Vector3Int.down, Vector3Int.left, Vector3Int.right };

    [SerializeField] private Transform vfxParent;

    [SerializeField] private Block[] block;
    [SerializeField]
    [Tooltip("Solo scripts que implementen IBlockeable")] 
    private MonoBehaviour[] blockScritps;  
    
    public void InitializeTiles()
    {
        //Grass Section
        for (int x = 0; x < 6; x++)
        {
            for (int y = -1500; y < 0; y++)
            {
                Vector3Int position = new(x, y, 0);

                int underScoreIndex = tilemap.GetTile(position).name.IndexOf('_');
                int blockIndex = int.Parse(tilemap.GetTile(position).name.Substring(0, underScoreIndex));
                Block currentBlock = block[blockIndex - 1];
                tileHealth[position] = currentBlock.maxHealth;
            }
        }
    }

    public void SetNewTile(Vector3Int position, Tile newTile)
    {
        int underScoreIndex = tilemap.GetTile(position).name.IndexOf('_');
        int blockIndex = int.Parse(tilemap.GetTile(position).name.Substring(0, underScoreIndex));
        Block currentBlock = block[blockIndex - 1];
        tileHealth[position] = currentBlock.maxHealth;
    }

    public void DamageTile(Vector3Int position, float damage, int indexBlock)
    {
        //Debug.Log("indexblock: " + indexBlock);

        if (tileHealth.ContainsKey(position))
        {
            Block currentBlock = block[indexBlock - 1];
            tileHealth[position] -= damage;

            //Debug.Log($"Tile en {position} tiene {tileHealth[position]} de vida restante.");

            if (tileHealth[position] <= 0)
            {
                DestroyTile(position, currentBlock);
            }
            else
            {
                AudioManager.Instance.PlayHit();
                tilemap.SetTile(position, currentBlock.GetState(tileHealth[position]));
                Instantiate(currentBlock.vfxHit, position + new Vector3(0.5f, 0.5f, 0f), Quaternion.identity);
            }
        }
    }

    void DestroyTile(Vector3Int position, Block brokenBlock)
    {
        blockScritps[brokenBlock.blockType].GetComponent<IBlockeable>().DestroyBlock(tilemap, position, this, player); // Borra el tile, segun el bloque
        tileHealth.Remove(position); // Lo elimina del diccionario de vida de bloques
        cameraMovement.MoveCameraDown(position);
        tileLighting.ChangeLight(position);
        Instantiate(brokenBlock.vfxDeath, position + new Vector3(0.5f, 0.5f, 0f), Quaternion.identity);
        //Debug.Log($"Tile en {position} ha sido destruido.");
    }
}
