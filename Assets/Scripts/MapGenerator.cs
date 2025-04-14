using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileData tiledata;

    [Header("Base")]
    [SerializeField] private int maxwidth;
    [SerializeField] private int maxheight;
    [Space]
    [SerializeField] private int section1Start;
    [SerializeField] private int section1End;
    [SerializeField] private int section2Start;
    [SerializeField] private int section2End;
    [SerializeField] private int section3Start;
    [SerializeField] private int section3End;
    [SerializeField] private int section4Start;
    [SerializeField] private int section4End;
    [SerializeField] private int section5Start;
    [SerializeField] private int section5End;

    //Tiles
    [Header("Tiles Section 1")]
    [SerializeField] private Tile[] tilesSection1;
    [SerializeField] private Tile[] tilesSection2;
    [SerializeField] private Tile[] tilesSection3;
    [SerializeField] private Tile[] tilesSection4;
    [SerializeField] private Tile[] tilesSection5;
    [Space]
    [SerializeField] private Tile decorationTileLeft;
    [SerializeField] private Tile decorationTileRight;

    [Header("Probabilities")]
    [SerializeField] private float[] section1Prob;
    [SerializeField] private float[] section2Prob;
    [SerializeField] private float[] section3Prob;
    [SerializeField] private float[] section4Prob;
    [SerializeField] private float[] section5Prob;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateMap();
    }

    void CreateMap()
    {
        Section1();
        Section2();
        Section3();
        Section4();
        Section5();
        DecorationSection();
    }

    void Section1()
    {
        for (int x = 0; x < maxwidth; x++)
        {
            for (int y = section1End; y < section1Start; y++)
            {
                Vector3Int position = new Vector3Int(x, y, 0);

                tilemap.SetTile(position, GetRandomTile(tilesSection1, section1Prob));
            }
        }
    }


    void Section2()
    {
        for (int x = 0; x < maxwidth; x++)
        {
            for (int y = section2End; y < section2Start; y++)
            {
                Vector3Int position = new Vector3Int(x, y, 0);

                tilemap.SetTile(position, GetRandomTile(tilesSection2, section2Prob));
            }
        }
    }

    void Section3()
    {
        for (int x = 0; x < maxwidth; x++)
        {
            for (int y = section3End; y < section3Start; y++)
            {
                Vector3Int position = new Vector3Int(x, y, 0);

                tilemap.SetTile(position, GetRandomTile(tilesSection3, section3Prob));
            }
        }
    }

    void Section4()
    {
        for (int x = 0; x < maxwidth; x++)
        {
            for (int y = section4End; y < section4Start; y++)
            {
                Vector3Int position = new Vector3Int(x, y, 0);

                tilemap.SetTile(position, GetRandomTile(tilesSection4, section4Prob));
            }
        }
    }

    void Section5()
    {
        for (int x = 0; x < maxwidth; x++)
        {
            for (int y = section5End; y < section5Start; y++)
            {
                Vector3Int position = new Vector3Int(x, y, 0);

                tilemap.SetTile(position, GetRandomTile(tilesSection5, section5Prob));
            }
        }

        tiledata.InitializeTiles();
    }

    void DecorationSection()
    {
        for (int y = -1500; y < 0; y++)
        {
            Vector3Int position = new Vector3Int(-1, y, 0);

            tilemap.SetTile(position, decorationTileLeft);

            position = new Vector3Int(6, y, 0);

            tilemap.SetTile(position, decorationTileRight);
        }
    }

    public Tile GetRandomTile(Tile[] tiles, float[] probabilities)
    {
        // 1. Sumar todas las probabilidades
        float totalProbability = 0f;
        foreach (float prob in probabilities)
        {
            totalProbability += prob;
        }

        // 2. Generar un número aleatorio entre 0 y totalProbability
        float randomPoint = Random.Range(0f, totalProbability);

        // 3. Recorrer las probabilidades y elegir el Tile correspondiente
        float cumulative = 0f;
        for (int i = 0; i < probabilities.Length; i++)
        {
            cumulative += probabilities[i];
            if (randomPoint <= cumulative)
            {
                return tiles[i]; // Devuelve el Tile seleccionado
            }
        }

        return tiles[0]; // En caso de error, retorna un Tile vacío
    }
}



