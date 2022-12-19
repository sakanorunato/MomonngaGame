using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScroll : MonoBehaviour
{
    public float movePos;
    private Vector2 viewPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewPos.y < -1)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + movePos);
        }
        Debug.Log(viewPos.y);
    }
}
