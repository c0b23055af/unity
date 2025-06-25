using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    void Start()
    {
        Invoke("GoToStage1", 2f);
    }

    void GoToStage1()
    {
        SceneManager.LoadScene("stage1");
    }
}

