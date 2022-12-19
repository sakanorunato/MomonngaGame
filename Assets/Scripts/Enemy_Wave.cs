using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Wave : MonoBehaviour
{
    public GameObject[] enemyChips;
    public Transform createPos;
    private float supremeHight = 0;
    private Vector2 playerPos;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        CreateEnemy();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            playerPos = player.transform.position;
            if (supremeHight - playerPos.y <= -1)
            {
                CreateEnemy();
                supremeHight++;
            }
        }
        else if(!player)
        {
            return;
        }
    }
    void CreateEnemy()
    {
        float ry = Random.Range(0f, 0.3f);
        float rx = Random.Range(1f, -1f);
        int nextChips = Random.Range(0, enemyChips.Length);
        Instantiate(enemyChips[nextChips], new Vector2(createPos.position.x + rx, createPos.position.y + ry), Quaternion.identity);
    }
}
