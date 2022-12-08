using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPop : MonoBehaviour
{
    public float popTime;
    public GameObject enemyObj;
    private float gameTime;
    private const int maxEnemy = 6;
    public float min;
    public float max;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemySpown();
    }
    //Žw’èŽžŠÔ‚Å“G‚ð¶¬
    void EnemySpown()
    {
        gameTime += Time.deltaTime;
        if (gameTime > popTime)
        {
            Vector2 enemyPos = new Vector2(Random.Range(min, max), this.transform.position.y);
            Instantiate(enemyObj, enemyPos, Quaternion.identity);
            gameTime = 0f;
            Debug.Log("Pop‚µ‚Ü‚µ‚½");
        }
    }
}
