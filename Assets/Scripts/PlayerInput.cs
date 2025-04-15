using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;


public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap; // Asigna tu Tilemap desde el Inspector
    [SerializeField] private Camera cam;
    private PlayerUI playerUI;
    private Player playerData;

    private readonly Vector3Int[] directions = { Vector3Int.up, Vector3Int.down, Vector3Int.left, Vector3Int.right };

    [SerializeField] private TileData tileData;
    
    private void Start()
    {
        playerUI = GetComponent<PlayerUI>();
        playerData = GetComponent<Player>();
    }

    void Update()
    {
        if (playerData.GetClics() <= 0) return;

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) // Detecta clic izquierdo
        {
            // Obtiene la posición del clic en el mundo
            Vector3 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0; // Asegúrate de que la profundidad sea 0

            // Convierte la posición del mundo a coordenadas de celda del Tilemap
            Vector3Int cellPosition = tilemap.WorldToCell(mouseWorldPos);

            // Verifica si hay un Tile en esa posición
            if (tilemap.HasTile(cellPosition))
            {
                if (CanBreakTile(cellPosition))
                {
                    int underScoreIndex = tilemap.GetTile(cellPosition).name.IndexOf('_');
                    int blockIndex = int.Parse(tilemap.GetTile(cellPosition).name.Substring(0, underScoreIndex));
                    tileData.DamageTile(cellPosition, 1f, blockIndex);
                    playerUI.RestClic();
                }
            }
        }
    }



    private bool CanBreakTile(Vector3Int tilePos)
    {
        // Si no hay un tile en esa posición, no hay nada que picar
        if (tilemap.GetTile(tilePos) == null) return false;
        
        if (tilePos.x > 5 || tilePos.x < 0) return false;

        // Revisar si hay al menos un tile vacío (null) alrededor
        foreach (Vector3Int dir in directions)
        {
            if (tilemap.GetTile(tilePos + dir) == null)
                return true; // Puede picarse si hay un espacio vacío al lado
        }
        Debug.Log("No se puede romper este tile.");
        return false; // Si todos los lados están ocupados, no se puede picar
    }
}
