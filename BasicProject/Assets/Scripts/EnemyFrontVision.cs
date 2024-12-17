using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFrontVision : MonoBehaviour
{
    Enemy enemy;
    Collider2D frontVisionCollider;
    Bounds frontVisionColliderBounds;

    Boolean hasToCheck;
    GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemy = transform.GetComponentInParent<Enemy>();   
        frontVisionCollider = gameObject.GetComponent<Collider2D>();
        frontVisionColliderBounds = frontVisionCollider.bounds;
        hasToCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfInsideCollider();
        frontVisionColliderBounds = frontVisionCollider.bounds;
    }

    void OnTriggerEnter2D(Collider2D collider2D){
        if (collider2D.tag == "Player"){
            hasToCheck = true;
            enemy.EnemyOnFrontArea();
        }
    }

    void CheckIfInsideCollider(){
        frontVisionColliderBounds.Contains(player.GetComponent<Collider2D>().bounds.min);
        if (hasToCheck && (frontVisionColliderBounds.Contains(player.GetComponent<Collider2D>().bounds.min) || frontVisionColliderBounds.Contains(player.GetComponent<Collider2D>().bounds.max)) ){
            enemy.EnemyOnFrontArea();
        }
        else if(!hasToCheck && (frontVisionColliderBounds.Contains(player.GetComponent<Collider2D>().bounds.min) || frontVisionColliderBounds.Contains(player.GetComponent<Collider2D>().bounds.max)) ){
            
        }
    }

    void OnTriggerExit2D(Collider2D collider2D){
        if (collider2D.tag == "Player"){
            hasToCheck = false;
            enemy.EnemyExitedFrontArea();
        }
    }
    
}
