using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    public GameObject block_pre; 

    void Start()
    {
        GenerateBlocks();
    }

    void GenerateBlocks()
    {
        float x = 3.5f;
        float y = Random.Range(-5f, 15f);

        // 上ブロックの位置
        Vector3 upperPos = new Vector3(x, y + 5f / 2 + 10f / 2, 0f); 
        // 下ブロックの位置
        Vector3 lowerPos = new Vector3(x, y - 5f / 2 - 10f / 2, 0f); 

        // 上ブロック生成
        GameObject upper = Instantiate(block_pre, upperPos, Quaternion.identity);
        upper.transform.localScale = new Vector3(1f, 10f, 1f);

        // 下ブロック生成
        GameObject lower = Instantiate(block_pre, lowerPos, Quaternion.identity);
        lower.transform.localScale = new Vector3(1f, 10f, 1f);
    }
}
