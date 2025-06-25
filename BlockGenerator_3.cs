using UnityEngine;

public class BlockGenarator_3 : MonoBehaviour
{
    public GameObject block_pre;        // ブロックのプレハブ
    public float rotationSpeed = 90f;   // 回転速度（度/秒）

    private GameObject clockwiseBlock;
    private GameObject counterClockwiseBlock;
    private GameObject fallingBlock;
    private float fallTimer = 0f;
    private float spawnInterval = 3f;

    void Start()
    {
        clockwiseBlock = Instantiate(block_pre, new Vector3(0.81f, 5f, 0f), Quaternion.identity);
        counterClockwiseBlock = Instantiate(block_pre, new Vector3(0.81f, -5f, 0f), Quaternion.identity);

        Instantiate(block_pre, new Vector3(13f, 9f, 0f), Quaternion.identity);
        Instantiate(block_pre, new Vector3(13f, -5f, 0f), Quaternion.identity);

        CreateFallingBlock();
    }

    void Update()
    {
        // 時計回り
        if (clockwiseBlock != null)
        {
            clockwiseBlock.transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
        }

        // 半時計回り
        if (counterClockwiseBlock != null)
        {
            counterClockwiseBlock.transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        }

        fallTimer += Time.deltaTime;
        if (fallTimer >= spawnInterval)
        {
            fallTimer = 0f;
            CreateFallingBlock();
        }
    }

    void CreateFallingBlock()
    {
        // 古いブロック削除
        if (fallingBlock != null)
        {
            Destroy(fallingBlock);
        }

        // 新規ブロック生成
        fallingBlock = Instantiate(block_pre, new Vector3(-5.41f, 10f, 0f), Quaternion.identity);

        // Rigidbody2D をダイナミックに変更
        Rigidbody2D rb = fallingBlock.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = fallingBlock.AddComponent<Rigidbody2D>();
        }
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
