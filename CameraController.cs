using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panDuration = 3f;     // カメラが移動する時間（3秒）
    public float waitDuration = 3f;    // パン完了後の待機時間
    public float followOffsetX = 8f;   // プレイヤーを追う際のXオフセット

    private GameObject player;
    private Vector3 startPos;
    private Vector3 targetPos;
    private float timer = 0f;
    private bool isPanning = true;
    private bool isWaiting = false;

    void Start()
    {
        this.player = GameObject.Find("player");
        this.startPos = this.transform.position;
        this.targetPos = new Vector3(20f, startPos.y, startPos.z); 
    }

    void Update()
    {
        if (isPanning)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / panDuration);
            this.transform.position = Vector3.Lerp(startPos, targetPos, t);

            if (t >= 1f)
            {
                isPanning = false;
                isWaiting = true;
                timer = 0f;
            }
        }
        else if (isWaiting)
        {
            timer += Time.deltaTime;
            if (timer >= waitDuration)
            {
                isWaiting = false;
            }
        }
        else
        {
            // プレイヤー追従に戻る
            float x = this.player.transform.position.x + followOffsetX;
            float y = this.transform.position.y;
            float z = this.transform.position.z;
            this.transform.position = new Vector3(x, y, z);
        }
    }
}
