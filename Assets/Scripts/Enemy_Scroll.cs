using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Scroll : MonoBehaviour
{
    private float viewY;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OffScreen();
    }
    //âÊñ äOÇ…èoÇΩÇÁè¡Ç¶ÇÈ
    void OffScreen()
    {
        viewY = Camera.main.WorldToViewportPoint(transform.position).y;
        if (viewY < -1)
        {
            Destroy(this.gameObject);
        }
    }
}
