using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Wave : MonoBehaviour
{
    public GameObject[] enemyChips;
    public List<GameObject> pointChips = new List<GameObject>();
    private GameObject posWave;
    // Start is called before the first frame update
    void Start()
    {
        GenerateWave(2);
    }

    // Update is called once per frame
    void Update()
    {
        if (posWave.transform.position.y < 0)
        {
            GenerateWave(3);
        }
    }
    void GenerateWave(float y)
    {
        int nextChips = Random.Range(0, enemyChips.Length);
        pointChips.Add(Instantiate(enemyChips[nextChips], new Vector3(0f, y, 0f), Quaternion.identity));
        Debug.Log(pointChips.Count);
        for (int i = 0; i < pointChips.Count; i++)
        {
            posWave = pointChips[i];
        }
    }
}
