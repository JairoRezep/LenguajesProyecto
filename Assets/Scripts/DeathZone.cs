using Unity.VisualScripting;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.tag == "Enemy"){
            collider.gameObject.GetComponent<Enemy>().RecieveDamage(10000);
        }
        else if(collider.tag == "Player"){
            collider.gameObject.GetComponent<player>().RecieveDamage(10000);
        }
    }
}
