using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private int lastY;

    private void Start() 
    {
        lastY = 0;
    }

    //Esta funcion mueve la camara hacia abajo teniendo en cuenta cual es el bloque que esta mas abajo
    public void MoveCameraDown(Vector3Int cellPosition)
    {
        if (lastY > cellPosition.y) lastY = cellPosition.y;
        transform.position = new Vector3(3f, lastY, 0f);
    }

    //Si agrego un boton en la UI para subir, esta funcion es la que tiene que llamar
    public void MoveCameraUp()
    {
        transform.position = new Vector3(3f, lastY * 3, 0f);
    }
}
