using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScroll : MonoBehaviour
{
    private GameObject player;
    Player pScript;
    private Vector2 p_Pos;
    public GameObject scrollP;
    private Vector2 screenPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        pScript = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //ƒvƒŒƒCƒ„[‚ÌŽæ“¾
       if (player)
        {
            p_Pos = player.transform.position;
        }
        else if (!player)
        {
            return;
        }
        screenPos = Camera.main.WorldToScreenPoint(p_Pos);
        if (screenPos.y >= Screen.height / 2 && pScript.wallCheck == false)
        {
            transform.Translate(0f, -0.01f, 0f);
            if (transform.position.y < -6)
            {
                transform.position = scrollP.transform.position;
            }
        }
    }

}
