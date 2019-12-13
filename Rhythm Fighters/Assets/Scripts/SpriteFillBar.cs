using UnityEngine;
using System.Collections.Generic;

public class SpriteFillBar : MonoBehaviour
{
    [SerializeField]
    private GameObject spriteObj;
    [SerializeField]
    private GameObject fillObj;

    private SpriteRenderer renderer;
    private BoxCollider2D collider;

    [SerializeField]
    private bool isLeft = false;

    void Start()
    {
        renderer = spriteObj.GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }
    
    public void SetFill(float fill)
    {
        float x = GetColSize(1f) / this.transform.localScale.x * fill;
        Vector3 pos = fillObj.transform.localPosition;
        if(isLeft)
        {
            pos.y = x * -1f;
        }
        else
        {
            pos.y = x;
        }
        
        fillObj.transform.localPosition = pos;
    }

    public float GetColSize(float fill)
    {
        return renderer.bounds.size.x * fill;
    }

    public void SetCollider(float fill)
    {
        float x = GetColSize(fill);
        Vector2 size = collider.size;
        size.x = x;
        collider.size = size;
        Vector2 offset = collider.offset;
        if(isLeft)
        {
            offset.x = x * 0.5f;
        }
        else
        {
            offset.x = x * 0.5f * -1f;
        }
        collider.offset = offset;
    }
}