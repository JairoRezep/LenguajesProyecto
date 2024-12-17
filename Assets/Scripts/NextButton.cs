using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour
{
    public void OnButtonPressed(){
        if(SceneManager.GetActiveScene().buildIndex > 1){
            Application.Quit();
        }
        else{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
}
