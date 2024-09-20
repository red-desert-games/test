using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject horsePf;
    [SerializeField] private GameObject initializePoint;
    [SerializeField] private GameObject gameMenuPanel;
    [SerializeField] private Button gameButton;

    public static GameManager instance;

    public bool isGameStart;
    public bool isGameOver;
    private int horseNum=5;
    private GameObject[] playerHorse;
    private Vector3 spawnPoint;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerHorse = new GameObject[horseNum];
        spawnPoint = initializePoint.transform.position;
        InitializedHorses();
        SetGamemenu(true);
    }

    private void InitializedHorses()
    {
        for (int i = 0; i < horseNum; i++)
        {
            playerHorse[i] = Instantiate(horsePf, spawnPoint, horsePf.transform.rotation);
            playerHorse[i].GetComponent<SpriteRenderer>().color = SetHorsesColor();
            spawnPoint.y += 2f;
        }
        
    }

    private Color SetHorsesColor()
    {
        //return Random.ColorHSV();
        return new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f));
    }

    public void SetGamemenu(bool status)
    {
        gameMenuPanel.SetActive(status);
        if (!isGameOver) gameButton.GetComponentInChildren<TextMeshProUGUI>().text = "Start Race";
        else gameButton.GetComponentInChildren<TextMeshProUGUI>().text = "Restart";
    }

    public void GameButtonPress()
    {
        if (!isGameOver)
        {
            StartGame();
        } 
        else RestartGame();
    }

    private void StartGame()
    {
        isGameStart = true;
        SetGamemenu(false);
    }
    private void RestartGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
