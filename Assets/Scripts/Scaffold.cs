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
    //画面外に出たら即消える
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
