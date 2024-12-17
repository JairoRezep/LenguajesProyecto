using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class main_camera : MonoBehaviour
{
    GameObject player;
    [SerializeField]
    private float xLowerLimit;
    [SerializeField]
    private float yUpperLimit, yLowerLimit;
    public AudioSource audioSource;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {  
        player = GameObject.Find("Player");
        transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, -10);
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > xLowerLimit){
            xLowerLimit = transform.position.x;
        }
        UpdatePosition(IsWithinConstraints());
    }

    private int IsWithinConstraints(){

        if ((player.transform.position.x > xLowerLimit) && (player.transform.position.y < yUpperLimit && player.transform.position.y > yLowerLimit)){
            return 1;
        }
        else if (player.transform.position.x > xLowerLimit){
            return 2;
        }

        return 0;
    } 

    private void UpdatePosition(int axis){
        switch (axis)
        {
            case 0:
                break;
            case 1:
                transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, -10);
                break;
            case 2:
                transform.position = new Vector3 (player.transform.position.x, transform.position.y, -10);
                break;
            default:
                break;
        }
    }
}
