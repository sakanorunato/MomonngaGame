using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpPower;
    public float movePower;
    private Rigidbody2D rb;
    private Vector2 screenPos;
    private Vector2 worldPos;
    public bool wallCheck;
    private bool jumpCheck;
    private Vector2 nowpos;
    public bool dead;
    public int hp;
    private Vector3 scale;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           jumpCheck = true;
        }
        WallStick();
        Dead();
        HightRange();
    }
    private void FixedUpdate()
    {
        Jump();
    }
    //クリックしたらジャンプ
    void Jump()
    {
        if (jumpCheck)
        {
            wallCheck = false;
            if (Input.mousePosition.x > Screen.width / 2)
            {
                scale.x = 0.1f;
                rb.velocity = new Vector3(movePower, jumpPower, 0f);
            }
            else if (Input.mousePosition.x < Screen.width / 2)
            {
                scale.x = -0.1f;
                rb.velocity = new Vector3(-movePower, jumpPower, 0f);
            }
            transform.localScale = scale;
            jumpCheck = false;
        }
    }
    void HightRange()
    {
        screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.y > Screen.height / 2)
        {
            screenPos.y = Screen.height / 2;
            worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            transform.position = worldPos;
        }
    }
    //hpが0になったら死ぬ
    void Dead()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
            dead = true;
        }
    }
    //壁に張り付く処理、敵に当たった処理
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            wallCheck = true;
            nowpos = transform.position;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            hp--;
        }
    }
    //接触したらプレイヤーを倒す
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DeadZone")
        {
            hp = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            wallCheck = false;
            anim.SetBool("treeMomonga", false);
        }
    }
    void WallStick()
    {
        if (wallCheck)
        {
            anim.SetBool("treeMomonga", true);
            transform.position = nowpos;
            if (screenPos.x > Screen.width / 2)
            {
                transform.eulerAngles = new Vector3(0f, 0f, 90f);
            }
            else if (screenPos.x < Screen.width / 2)
            {
                transform.eulerAngles = new Vector3(0f, 0f, -90f);
            }
        }
        else if (!wallCheck)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }
}
