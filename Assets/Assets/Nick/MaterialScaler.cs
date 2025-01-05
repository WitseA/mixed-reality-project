using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class AdjustTextureTiling : MonoBehaviour
{
    public Vector2 tileSize = Vector2.one; // Size of each tile in world units

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null && renderer.material != null)
        {
            Vector3 scale = transform.localScale; // Scale of the object
            Vector2 tiling = new Vector2(scale.x / tileSize.x, scale.y / tileSize.y);
            renderer.material.mainTextureScale = tiling;
        }
    }
}