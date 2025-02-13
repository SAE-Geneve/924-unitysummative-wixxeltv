using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public void Reset()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameManager.boxCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}