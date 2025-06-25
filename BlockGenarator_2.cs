using UnityEngine;

public class BlockGenarator_2 : MonoBehaviour
{
    public GameObject block_pre; // プレハブ参照

    void Start()
    {
        GenerateBlocks();
    }

    void GenerateBlocks()
    {
        Instantiate(block_pre, new Vector3(0.51f, -7.02f, 0f), Quaternion.identity);
        Instantiate(block_pre, new Vector3(0.51f,  6.71f, 0f), Quaternion.identity);
        Instantiate(block_pre, new Vector3(2.68f, -6.06f, 0f), Quaternion.identity);
        Instantiate(block_pre, new Vector3(2.68f,  7.86f, 0f), Quaternion.identity);
        Instantiate(block_pre, new Vector3(4.64f,  8.55f, 0f), Quaternion.identity);
        Instantiate(block_pre, new Vector3(4.64f, -5.63f, 0f), Quaternion.identity);
        Instantiate(block_pre, new Vector3(6.81f,  9.18f, 0f), Quaternion.identity);
        Instantiate(block_pre, new Vector3(6.81f, -4.89f, 0f), Quaternion.identity);
        Instantiate(block_pre, new Vector3(8.82f,  9.5f,  0f), Quaternion.identity);
        Instantiate(block_pre, new Vector3(8.82f, -4.23f, 0f), Quaternion.identity);
    }

}