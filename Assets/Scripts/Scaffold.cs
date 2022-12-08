using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaffold : MonoBehaviour
{
    private GameObject player;
    Player pScript;
    private Vector2 p_Pos;
    private Vector2 screenPos;
    private Vector2 nowpos;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        pScript = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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
    //画面外に出たら即消える
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
