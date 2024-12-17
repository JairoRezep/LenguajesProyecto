using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private int playerDamage = 25;
    public void Update(){

    }
    void OnTriggerEnter2D(Collider2D collider){
        if (collider.tag == "Enemy"){
            //Damage Enemy
            collider.gameObject.GetComponent<Enemy>().RecieveDamage(playerDamage);
        }
    }
}
