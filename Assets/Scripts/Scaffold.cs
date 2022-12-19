using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaffold : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //âÊñ äOÇ…èoÇΩÇÁë¶è¡Ç¶ÇÈ
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
