using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

public class player : MonoBehaviour
{
    [SerializeField]
    private int playerHealth = 100;
    Animator anim;
    Rigidbody2D rgbd;
    Collider2D collider2D;
    Collider2D attackCollider;

    Boolean isDead;
    GameObject gameManagerObject;
    GameManager gameManagerScript;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the players animator, rigidbody and collider components
        // Starts with the idle animation
        anim = GetComponent<Animator>();
        rgbd = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
        gameManagerObject = GameObject.FindWithTag("GameController");
        gameManagerScript = gameManagerObject.GetComponent<GameManager>();
        anim.Play("player_idle");

        //Get the attack collider
        attackCollider = transform.GetChild(0).gameObject.GetComponent<Collider2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float attackInput = Input.GetAxis("Fire1");
        if (attackInput > 0){
            Attack();
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0){
            MoveHorizontaly(horizontalInput);
        }
        

        float jump = Input.GetAxis("Jump");
        if (jump != 0){
            Jump();
        }

        checkIfFalling();
        
    }

    void MoveHorizontaly(float horizontalInput){
        if (isDead){
            return;
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("player_attack")){
            return;
        }
        
        if ((rgbd.linearVelocity.y < 0 || rgbd.linearVelocity.y > 0)){
            RotateOnInput(horizontalInput);
            rgbd.linearVelocity = new Vector2(6f * horizontalInput, rgbd.linearVelocityY);
            return;
        }

        rgbd.linearVelocity = new Vector2(10f * horizontalInput, rgbd.linearVelocityY);
        RotateOnInput(horizontalInput);
        anim.Play("player_walk");

    }

    void Jump(){
        if (isDead){
            return;
        }
        if (rgbd.linearVelocity.y != 0 || anim.GetCurrentAnimatorStateInfo(0).IsName("player_attack")){
            return;
        }
        rgbd.linearVelocity = new Vector2(rgbd.linearVelocityX, 14);
        anim.Play("player_up");
    }

    void checkIfFalling(){
        if (isDead){
            return;
        }
        if (rgbd.linearVelocity.y < -2 && !anim.GetCurrentAnimatorStateInfo(0).IsName("player_attack")){
            anim.Play("player_falling");
        }
        else{
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("player_falling")){
                anim.Play("player_idle");
            }
        }
    }

    void Attack(){
        if (isDead){
            return;
        }
        anim.Play("player_attack");
    }

    void RotateOnInput(float inputDirection){
        if (isDead){
            return;
        }
        if (inputDirection < 0){
            transform.rotation = new Quaternion(0, -180, 0, transform.rotation.w);
        }
        else{
            transform.rotation = new Quaternion(0, 0, 0, transform.rotation.w);
        }
    }

    public void StartAttack(){
        attackCollider.enabled = true;
    }

    public void EndAttack(){
        attackCollider.enabled = false;
    }

    public void RecieveDamage(int amount){
        playerHealth -= amount;

        if (playerHealth <= 0){
            Die();
        }
    }

    public void setHealth(int h){
        playerHealth = h;
    }

    public void Die(){
        anim.Play("player_death");
        isDead = true;
    }

    public void DeathAnimationEnded(){
        Respawn();
    }

    public void Respawn(){
        gameManagerScript.RespawnPlayer();
        isDead = false;
        playerHealth = 50;
    }
}
