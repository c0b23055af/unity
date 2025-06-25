using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor.Experimental.GraphView;
using UnityEngine.InputSystem;

public class GameDirector : MonoBehaviour
{
    GameObject horse;
    GameObject goal;
    GameObject distance;

    bool goalReached = false;

    void Start()
    {
        this.horse = GameObject.Find("player");
        this.goal = GameObject.Find("goal");
        this.distance = GameObject.Find("distance");
    }

    void Update()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene != "Gameover" && currentScene != "Clear")
        {
            if (goalReached) return;

            float horseX = this.horse.transform.position.x;
            float goalX = this.goal.transform.position.x;
            float length = goalX - horseX - 1f;
            if (length >= 0f)
            {
                this.distance.GetComponent<TextMeshProUGUI>().text = length.ToString("F2") + "m";
            }
            else
            {
                this.distance.GetComponent<TextMeshProUGUI>().text = "0.00m";
            }

            if (length <= 0f)
            {
                goalReached = true;
                this.GetComponent<AudioSource>().Play();
                Time.timeScale = 0f; // ← 一時停止
                StartCoroutine(WaitAndLoadNextScene());
            }
        }
        if (currentScene == "Gameover" || currentScene == "Clear")
        {
            if (Keyboard.current != null)
            {
                if (Keyboard.current.rKey.isPressed)
                {
                    SceneManager.LoadScene("stage1");
                }
            }
        }
    }

    System.Collections.IEnumerator WaitAndLoadNextScene()
    {
        yield return new WaitForSecondsRealtime(1f);

        Time.timeScale = 1f;

        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "stage1")
        {
            SceneManager.LoadScene("stage2");
        }
        else if (currentScene == "stage2")
        {
            SceneManager.LoadScene("stage3");
        }
        else if (currentScene == "stage3")
        {
            SceneManager.LoadScene("Clear");
        }
    }
}