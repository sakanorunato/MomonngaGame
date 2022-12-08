using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Scroll : MonoBehaviour
{
    private GameObject player;
    protected Player pScript;
    private Vector2 p_Pos;
    private Vector2 screenPos;
    private Vector2 nowpos;
    public float speed;
    private float viewY;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        pScript = player.GetComponent<Player>();
        //GenerateWave();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        OffScreen();
    }
    //プレイヤーが真ん中にいると下に移動
    void Move()
    {
        //プレイヤーの取得
        if (player)
        {
            p_Pos = player.transform.position;
        }
        else if (!player)
        {
            nowpos = transform.position;
            return;
        }
        screenPos = Camera.main.WorldToScreenPoint(p_Pos);
        if (screenPos.y >= Screen.height / 2 && pScript.wallCheck == false)
        {
            nowpos = transform.position;
            nowpos += new Vector2(0f, -1 * speed * Time.deltaTime);
            transform.position = nowpos;
        }
    }
    //画面外に出たら消える
    void OffScreen()
    {
        viewY = Camera.main.WorldToViewportPoint(transform.position).y;
        if (viewY < -1)
        {
            Destroy(this.gameObject);
        }
    }
}
