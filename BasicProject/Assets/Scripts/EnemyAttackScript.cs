using System;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    Enemy enemy;
    float attackCooldown;
    Boolean isAttacking;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemy = transform.GetComponentInParent<Enemy>();
        attackCooldown = 1.5f;
    }

    void Update(){
        attackCooldown -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collider2D){
        if(isAttacking && attackCooldown <= 0){
            enemy.Attack();
            attackCooldown = 1.5f;
            return;
        }
        else if (collider2D.tag == "Player" && attackCooldown <= 0){
            enemy.Attack();
            attackCooldown = 1.5f;
            isAttacking = true;
        }
    }


    void OnTriggerExit2D(Collider2D collider2D){
        if (collider2D.tag == "Player"){
            isAttacking = false;
        }
    }

}
