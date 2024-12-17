using System;
using System.Data;
using System.Diagnostics;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class GenerateTerrain : MonoBehaviour
{
    // Future reference to the tilemap used on the game
    private Tilemap terrainTilemap;

    // Reference to the game manager and its script
    private GameObject GameManager;
    private GameManager gm;

    //Tiles used in the tail manager to spawn terrain

    [SerializeField]
    private TileBase orange_terrain_01, orange_terrain_02, orange_terrain_03, orange_terrain_04, orange_terrain_05, orange_terrain_06;

    [SerializeField]
    private TileBase underground_terrain_01, underground_terrain_02, underground_terrain_03;

    [SerializeField]
    private TileBase wood_platform_01, wood_platform_02, wood_platform_03, wood_platform_04, wood_platform_05;

    //Information provided by the game manager to generate terrain
    private int skipChunkNo;
    private int numberOfPlatforms;
    private int lengthOfPlatform;

    
    private void Start(){
        // Get the gameobject that contains the tilemap, and the its tilemap controller
        GameObject terrainTilemapObject = GameObject.FindWithTag("Terrain_Tilemap");
        terrainTilemap = terrainTilemapObject.GetComponent<Tilemap>();
        GameManager = GameObject.FindWithTag("GameController");
        gm = GameManager.GetComponent<GameManager>();
        this.GenerateTerrainOnTouch();

    }

    //When the player collides with this objects triggered collider, executes the spawn of terrain
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Player"){
            Destroy(this.gameObject);
        }
        
    }

    // This is the method that takes information given by the game manager and creates a terrain based on it.
    private void GenerateTerrainOnTouch(){
        int floorLevel = -3;
        UnityEngine.Vector2 ColliderPosition = transform.position;
        float xCell = transform.position.x - 1.5f;
        float startingX = xCell + 13;

        int lengthOfChunk = 6;

        for (int chunkNo = 0; chunkNo < lengthOfChunk; chunkNo++){
            if (chunkNo != skipChunkNo){
                GenerateBasicTerrain(floorLevel, startingX + (3 * chunkNo));
            }
        }

        for (int platformNo = 0; platformNo < numberOfPlatforms + 1; platformNo++){
            if (platformNo == 1){
                GeneratePlatform(floorLevel, startingX + 2, lengthOfPlatform);
            }
            else if(platformNo == 2){
                GeneratePlatform(floorLevel + 3, startingX + lengthOfPlatform + 1, lengthOfPlatform - 3);
            }
        }

        

    }

    //Generates terrain or platforms depending on the method. It uses the tiles we assigned through a serialized
    // field

    private void GenerateBasicTerrain(int floorLevel, float startingX){
        int xPosition = (int)startingX;
        for (int column = 0; column < 3; column++){
            switch (column)
            {
                case 0:
                    terrainTilemap.SetTile(new Vector3Int(xPosition, floorLevel - 1, 0), orange_terrain_01);
                    terrainTilemap.SetTile(new Vector3Int(xPosition, floorLevel - 2, 0), underground_terrain_01);
                    terrainTilemap.SetTile(new Vector3Int(xPosition, floorLevel - 3, 0), underground_terrain_01);
                    break;
                
                case 1:
                    terrainTilemap.SetTile(new Vector3Int(xPosition + column, floorLevel - 1, 0), orange_terrain_03);
                    terrainTilemap.SetTile(new Vector3Int(xPosition + column, floorLevel - 2, 0), underground_terrain_02);
                    terrainTilemap.SetTile(new Vector3Int(xPosition + column, floorLevel - 3, 0), underground_terrain_02);
                    break;
                
                case 2:
                    terrainTilemap.SetTile(new Vector3Int(xPosition + column, floorLevel - 1, 0), orange_terrain_05);
                    terrainTilemap.SetTile(new Vector3Int(xPosition + column, floorLevel - 2, 0), underground_terrain_03);
                    terrainTilemap.SetTile(new Vector3Int(xPosition + column, floorLevel - 3, 0), underground_terrain_03);
                    break;

                default:
                    UnityEngine.Debug.LogError("Tried to generate a column of basic terrain, but failed");
                    break;
            }
        }
    }

    private void GeneratePlatform(int floorLevel, float startingX, int length){

        if (length < 5){
            UnityEngine.Debug.LogError("Tried to generate a platfomr, but given length was out of range");
            return;
        }
        int xPosition = (int)startingX;
        int height = floorLevel + 2;

        for (int column = 0; column < length; column++){

            if (column == 0){
                terrainTilemap.SetTile(new Vector3Int(xPosition, height, 0), wood_platform_01);
            }

            else if(column == (length - 1)){
                terrainTilemap.SetTile(new Vector3Int(xPosition + column, height, 0), wood_platform_05);
            }

            else if(column == (length - 2)){
                terrainTilemap.SetTile(new Vector3Int(xPosition + column, height, 0), wood_platform_04);
            }

            else if (column % 2 == 0){
                terrainTilemap.SetTile(new Vector3Int(xPosition + column, height, 0), wood_platform_03);
            }

            else if (column % 2 != 0){
                terrainTilemap.SetTile(new Vector3Int(xPosition + column, height, 0), wood_platform_02);
            }

            else{
                UnityEngine.Debug.LogError("Tried to generate a column of wood platform, but failed");
            }

        }
    }

    // Public method for the Game Manager to set up right after creating an instance of this class/object.
    public void SetGenerationVariables(int skipNum, int numPlatforms, int lenghtPlatform){
        skipChunkNo = skipNum;
        numberOfPlatforms = numPlatforms;
        lengthOfPlatform = lenghtPlatform;
    }

    public void OnDestroy(){
        gm.GenerateTerrainWasDestroyed();
    }
}
