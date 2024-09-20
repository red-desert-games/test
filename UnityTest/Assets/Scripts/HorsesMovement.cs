using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorsesMovement : MonoBehaviour
{
    private float speed;
    private GameManager gamemanager;
    private Vector3 size;

    private float gameTimer = Mathf.Infinity;
    private float intervalTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        size = transform.localScale;
        gamemanager = GameManager.instance;
        speed = SetSpeed();
        SetIntervalTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gamemanager.isGameStart) return;
        gameTimer += Time.deltaTime;

        if (gameTimer >= intervalTime)
        {
            speed = SetSpeed() * Time.deltaTime;
            gameTimer = 0;
            SetIntervalTime();
        }
        this.transform.Translate(new Vector3(1, 0, 0) * speed);


    }

    private void SetIntervalTime()
    {
        intervalTime = Random.Range(0.6f, 1.5f);
    }

    private float SetSpeed()
    {
        return Random.Range(0.4f,1.4f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            gamemanager.isGameOver = true;
            this.gameObject.transform.localScale = size * 1.5f;
            
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gamemanager.SetGamemenu(true);
            gamemanager.isGameStart = false;
            
        }
        
    }
}
