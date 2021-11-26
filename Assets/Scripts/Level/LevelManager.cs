using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap tileMap;

    private Vector3 bottomLeftEdge;

    private Vector3 topRightEdge;

    // Start is called before the first frame update
    void Start()
    {
        InitTileMap();

        PlayerController.instance.SetLimit(bottomLeftEdge, topRightEdge);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitTileMap()
    {
        bottomLeftEdge = tileMap.localBounds.min + new Vector3(0.8f, 0.5f, 0f);

        topRightEdge = tileMap.localBounds.max + new Vector3(-0.8f, 0f, 0f);
    }
}
