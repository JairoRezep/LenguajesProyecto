using System;
using UnityEngine;
// Enemy Attack Collider Script
public class AttackCollider : MonoBehaviour
{
    GameObject player;
    Enemy enemy;
    Collider2D attackCollider;
    Bounds frontVisionColliderBounds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemy = transform.GetComponentInParent<Enemy>();
        attackCollider = gameObject.GetComponent<Collider2D>();
        frontVisionColliderBounds = attackCollider.bounds;

    }

    void Update()
    {
        frontVisionColliderBounds = attackCollider.bounds;
        CheckIfInsideCollider();
    }

    void OnTriggerEnter2D(Collider2D collider2D){
        if (collider2D.tag == "Player"){
            enemy.DamagePlayer();
        }
    }

    void CheckIfInsideCollider(){
        frontVisionColliderBounds.Contains(player.GetComponent<Collider2D>().bounds.min);
        if ((frontVisionColliderBounds.Contains(player.GetComponent<Collider2D>().bounds.min) || frontVisionColliderBounds.Contains(player.GetComponent<Collider2D>().bounds.max)) ){

            enemy.DamagePlayer();
        }
    }


    
}
