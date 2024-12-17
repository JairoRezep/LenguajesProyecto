using UnityEngine;
using UnityEngine.Tilemaps;

public class GarbageManagerCollider : MonoBehaviour
{
    int maxX;
    Tilemap tilemap;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tilemap = GameObject.FindWithTag("Terrain_Tilemap").GetComponent<Tilemap>();
        maxX = (int)transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if ((int)transform.position.x > maxX){
            maxX = (int)transform.position.x;
            tilemap.SetTile(new Vector3Int(maxX, -1, 0), null);
            tilemap.SetTile(new Vector3Int(maxX, -4, 0), null);
            tilemap.SetTile(new Vector3Int(maxX, -5, 0), null);
            tilemap.SetTile(new Vector3Int(maxX, -6, 0), null);
        }
    }

    void OnTriggerEnter2D(Collider2D collider2D){
        if (collider2D.tag == "Enemy" || collider2D.tag == "Coin"){
            GameObject.Destroy(collider2D.gameObject);
        }
    }


}
