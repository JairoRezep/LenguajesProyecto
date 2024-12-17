using UnityEngine;
using UnityEngine.SceneManagement;


public class RetryButton : MonoBehaviour
{
    public void OnButtonPressed(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
