using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class buildingSystem : MonoBehaviour
{
    // made with https://www.youtube.com/watch?v=rKp9fWvmIww&t=622s

    public static buildingSystem current;
    public GridLayout GridLayout;
    private Grid grid;
    [SerializeField] private Tilemap mainTilemap;
    [SerializeField] private TileBase whitetile;


    public GameObject cube;
    private placeableObject objectToPlace;

    private void Awake()
    {
        current = this;
        grid = GridLayout.gameObject.GetComponent<Grid>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            initializeWithObject(cube);
        }

        if (!objectToPlace)
            { 
            return; 
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (canBePlaced(objectToPlace))
            {
                objectToPlace.Place();
                Vector3Int start = GridLayout.WorldToCell(objectToPlace.getStartPosition());
                takeArea(start, objectToPlace.size);
            }
            else
            {
                Destroy(objectToPlace.gameObject);
            }

        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(objectToPlace.gameObject);
        }


    }

    public static Vector3 getMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit) )
        {
            return raycastHit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }

    public Vector3 snapCooordinateToGrid(Vector3 position)
    {
        Vector3Int cellPos = GridLayout.WorldToCell(position);
        position = grid.GetCellCenterWorld(cellPos);
        return position;
    }

    private static TileBase[] getTilesBlock (BoundsInt area, Tilemap tilemap)
    {
        TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
        int counter = 0;

        foreach (var v in area.allPositionsWithin)
        {
            Vector3Int pos = new Vector3Int(v.x, v.y, 0);
            array[counter] = tilemap.GetTile(pos);
            counter++;
        }
        return array;
    }


    //building placment

    public void initializeWithObject (GameObject prefab)
    {
        Vector3 position = snapCooordinateToGrid(Vector3.zero);

        GameObject obj = Instantiate(prefab, position, Quaternion.identity);
        objectToPlace = obj.GetComponent<placeableObject>();
        obj.AddComponent<objectDrag>();
    }

    private bool canBePlaced (placeableObject pObject)
    {
        BoundsInt area = new BoundsInt();
        area.position = GridLayout.WorldToCell(objectToPlace.getStartPosition());
        area.size = pObject.size;
        TileBase[] baseArray = getTilesBlock(area, mainTilemap);

        foreach (var v in baseArray)
        {
            if (v == whitetile)
            {
                return false;
            }
        }
        return true;
    }

    public void takeArea(Vector3Int start, Vector3Int size)
    {
        mainTilemap.BoxFill(start, whitetile, start.x, start.y, start.x + start.x, start.y + start.y);

    }


}
