using System;
using JetBrains.Annotations;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;
    [SerializeField]
    private int enemyHealth = 50;
    [SerializeField]
    private int enemyDamage = 25;
    private Animator anim;

    private Collider2D attackCollider;

    private SpriteRenderer enemySprite;
    private Collider2D collider2D;

    Rigidbody2D rgb2d;

    Boolean isAttacking;
    Boolean isDead;
    int direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        enemySprite = gameObject.GetComponent<SpriteRenderer>();
        collider2D = gameObject.GetComponent<Collider2D>();
        anim = gameObject.GetComponent<Animator>();
        rgb2d = gameObject.GetComponent<Rigidbody2D>();
        anim.Play("golem_blue_idle");
        isAttacking = false;
        isDead = false;
        player = GameObject.FindWithTag("Player");
        direction = 1;

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RecieveDamage(int amount){
        enemyHealth -= amount;
        if(enemyHealth <= 0 && !isDead){
            anim.Play("golem_blue_death");
            isDead = true;
            return;
        }
        else if (isAttacking && !isDead){
            return;
        }
        else if (!isDead){
            anim.Play("golem_blue_hurt");
        }
        
        
    }

    public void DisableColliderOnDeathAnimation(){
        collider2D.enabled = false;
    }
    public void EndedDeathAnimation(){
        enemySprite.enabled = false;
        Destroy(gameObject);
    }

    public void EnemyOnFrontArea(){
        if (isAttacking || isDead){
            rgb2d.linearVelocityX = 0;
            return;
        }

        anim.Play("golem_blue_walk");
        rgb2d.linearVelocityX = 2 * (direction);
        

    }
    public void EnemyExitedFrontArea(){
        if (isAttacking || isDead){
            rgb2d.linearVelocityX = 0;
            return;
        }
        rgb2d.linearVelocityX = 0;
        anim.Play("golem_blue_idle");
    }

    public void Attack(){
        if (isDead){
            return;
        }
        if(!(anim.GetCurrentAnimatorStateInfo(0).IsName("golem_blue_attack"))){
            rgb2d.linearVelocityX = 0;
            isAttacking = true;
            anim.Play("golem_blue_attack");
        }
        
        
    }


    public void TurnAround(){
        if (isAttacking || isDead){
            return;
        }
        
        if (direction == 1){
            transform.rotation =new Quaternion(0, 180, 0, transform.rotation.w);
            direction = -1;
        }
        else if (direction == -1){
            transform.rotation =new Quaternion(0, 0, 0, transform.rotation.w);
            direction = 1;
        }
    }

    public void SetHasToCheckAttackColliderToTrue(){
        transform.GetChild(0).GetComponent<Collider2D>().enabled = true;
    }

    public void SetHasToCheckAttackColliderToFalse(){
        transform.GetChild(0).GetComponent<Collider2D>().enabled = false;
        isAttacking = false;
    }

    public void DamagePlayer(){
        player.GetComponent<player>().RecieveDamage(enemyDamage);
    }
}
