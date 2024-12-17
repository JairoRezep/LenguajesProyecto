using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour
{
    public void OnButtonPressed(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
