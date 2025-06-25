using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class player : MonoBehaviour
{
    public float forcePower = 1500f;
    public GameObject maruPre; // Inspectorから割り当てる

    Rigidbody2D rigid2d;
    Animator animator;

    List<GameObject> maruList = new List<GameObject>();
    int maruCount = 7;
    float maruSpacing = 0.5f;
    bool hasClicked = false;

    void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (animator != null)
        {
            animator.enabled = false; // 開始時はアニメーション停止
        }

        // maru_pre を複製してリストに追加、初期状態は非表示
        for (int i = 0; i < maruCount; i++)
        {
            GameObject maru = Instantiate(maruPre);
            maru.SetActive(false);
            maruList.Add(maru);
        }
    }

    void Update()
    {
        if (!hasClicked)
        {
            Vector3 mouseScreenPos = Input.mousePosition;
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            Vector2 direction = (mouseWorldPos - transform.position);

            for (int i = 0; i < maruCount; i++)
            {
                Vector2 pos = (Vector2)transform.position + direction.normalized * maruSpacing * (i + 1);
                maruList[i].transform.position = pos;
                maruList[i].SetActive(true);
            }

            if (Mouse.current.leftButton.wasReleasedThisFrame)
            {

                this.GetComponent<AudioSource>().Play();
                hasClicked = true;

                rigid2d.AddForce(direction.normalized * forcePower);

                if (animator != null)
                {
                    animator.enabled = true; 
                }

                foreach (var maru in maruList)
                {
                    maru.SetActive(false);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("block"))
        {
            Invoke("GoToGameOver", 2f);
        }
    }

    void GoToGameOver()
    {
        SceneManager.LoadScene("Gameover");
    }
}
