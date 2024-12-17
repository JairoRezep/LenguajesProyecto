using UnityEngine;

public class Coin : MonoBehaviour
{

    // Reference to the game manager and its script
    private GameObject GameManager;
    private GameManager gm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager = GameObject.FindWithTag("GameController");
        gm = GameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Player"){
            gm.PickUpCoin();
            Destroy(gameObject);
        }
    }
}
