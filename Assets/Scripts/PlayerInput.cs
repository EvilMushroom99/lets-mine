using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;


public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap; // Asigna tu Tilemap desde el Inspector
    private PlayerUI playerUI;
    private Player playerData;

    private readonly Vector3Int[] directions = { Vector3Int.up, Vector3Int.down, Vector3Int.left, Vector3Int.right };

    [SerializeField] private CoinCollector coinCollector;
    [SerializeField] private TileData tileData;

    private int lastY;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform followObj;
    [SerializeField] private Tile brokenStoneTile;
    
    private void Start()
    {
        playerUI = GetComponent<PlayerUI>();
        playerData = GetComponent<Player>();
        lastY = 0;
    }

    void Update()
    {
        if (playerData.GetClics() <= 0) return;

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) // Detecta clic izquierdo
        {
            // Obtiene la posici�n del clic en el mundo
            Vector3 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0; // Aseg�rate de que la profundidad sea 0

            // Convierte la posici�n del mundo a coordenadas de celda del Tilemap
            Vector3Int cellPosition = tilemap.WorldToCell(mouseWorldPos);

            // Verifica si hay un Tile en esa posici�n
            if (tilemap.HasTile(cellPosition))
            {
                if (CanBreakTile(cellPosition))
                {
                    int underScoreIndex = tilemap.GetTile(cellPosition).name.IndexOf('_');
                    int blockIndex = int.Parse(tilemap.GetTile(cellPosition).name.Substring(0, underScoreIndex));
                    tileData.DamageTile(cellPosition, 1f, blockIndex);
                    //Elimina los clics de la UI
                    playerUI.RestClic();

                    if (!tilemap.HasTile(cellPosition))
                    {
                        //Mueve la camara hacia abajo si bajamos 1 row
                        if (lastY > cellPosition.y)
                        {
                            lastY = cellPosition.y;
                            MoveCameraDown();
                        }
                    }
                }
            }
        }
    }



    private bool CanBreakTile(Vector3Int tilePos)
    {
        // Si no hay un tile en esa posici�n, no hay nada que picar
        if (tilemap.GetTile(tilePos) == null) return false;
        
        if (tilePos.x > 5 || tilePos.x < 0) return false;

        // Revisar si hay al menos un tile vac�o (null) alrededor
        foreach (Vector3Int dir in directions)
        {
            if (tilemap.GetTile(tilePos + dir) == null)
                return true; // Puede picarse si hay un espacio vac�o al lado
        }
        Debug.Log("No se puede romper este tile.");
        return false; // Si todos los lados est�n ocupados, no se puede picar
    }

    private void MoveCameraDown()
    {
        followObj.transform.position = new Vector3(3f, lastY, 0f);
    }
}
