using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //�J�����̒Ǐ]
        if (player)
        {
            if (player.transform.position.y > transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
            }
        }
        if (!player)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
