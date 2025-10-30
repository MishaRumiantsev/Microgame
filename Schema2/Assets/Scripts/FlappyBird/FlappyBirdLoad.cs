using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyBirdLoad : MonoBehaviour
{
    public void LoadFlappy()
    {
        SceneManager.LoadScene("FlappyBird");
    }
    public void UnloadFlappy()
    {
        SceneManager.LoadScene(0);
        
    }
}
