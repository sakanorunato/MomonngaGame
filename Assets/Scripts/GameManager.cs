using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Player player;
    [SerializeField]
    private GameObject gameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.dead)
        {
            gameOverUI.SetActive(true);
        }
    }
    public void Retry()
    {
        SceneManager.LoadScene("MainGame");
    }
}
