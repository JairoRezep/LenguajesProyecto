using UnityEngine;

public class BackVisionScript : MonoBehaviour
{
    Enemy enemy;
    void Start()
    {
        enemy = transform.GetComponentInParent<Enemy>();
    }

    void OnTriggerEnter2D(Collider2D collider2D){
        if (collider2D.tag == "Player"){
            enemy.TurnAround();
        }
    }
}
