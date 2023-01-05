
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float scrollSpeed = -0.5f;
    private float offset;
    private Material mat;
    bool iswalk;
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }


    void Update()
    {
        if (GameManager.current.enemies.Count <= 0 && GameManager.current.newCardRoom==false)
        {
            offset += (Time.deltaTime * scrollSpeed) / 10f;

            mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }    
        
    }
}
