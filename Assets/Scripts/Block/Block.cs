using UnityEngine;

public class Block : MonoBehaviour
{
    private Block _block;

    public Block CreateBlock(Vector3 position)
    {
        _block = Instantiate(this, position, Quaternion.identity);
        _block.gameObject.AddComponent<BlockBaseStats>();
        _block.gameObject.AddComponent<BlockTransform>();
        return _block;
    }
}