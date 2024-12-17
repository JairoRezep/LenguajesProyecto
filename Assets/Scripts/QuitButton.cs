using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void OnButtonPressed(){
        Debug.Log("Deberia quitear");
        Application.Quit();
    }
}
