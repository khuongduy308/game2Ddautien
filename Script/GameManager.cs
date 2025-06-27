using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;


public class GameManager : MonoBehaviour
{
    private int currentEnergy = 0;
    [SerializeField] private int enegyNeedToCallBoss = 10;
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private GameObject enemySpawner;
    [SerializeField] private Image energyBar;
    [SerializeField] GameObject GameUI;
    [SerializeField] private AudioManager audioManager;
    private bool isBossCalled = false;
    // Start is called before the first frame update
    [SerializeField] public GameObject mainMenu;
    [SerializeField] public GameObject gameOverMenu;
    [SerializeField] public GameObject pauseMenu;
    [SerializeField] public GameObject WinMenu;
    [SerializeField] public GameObject red;
    [SerializeField] private CinemachineVirtualCamera cam;
    void Start()
    {
        MainMenu();
        currentEnergy = 0;
        ShowEnergyBar();
        bossPrefab.SetActive(false);
        isBossCalled = false;
        audioManager.StopAudio();
        cam.m_Lens.OrthographicSize = 4f;
        red.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddEnergy()
    {
        if (isBossCalled)
        {
            Debug.Log("Da goi boss roi, khong the tang nang luong");
            return;
        }
        currentEnergy++;
        ShowEnergyBar();
        if (currentEnergy >= enegyNeedToCallBoss)
        {
            CallBoss();
        }
    }
    public void CallBoss()
    {
        isBossCalled = true;
        bossPrefab.SetActive(true);
        enemySpawner.SetActive(false);
        GameUI.SetActive(false);
        audioManager.BossAudio();
        cam.m_Lens.OrthographicSize = 6f;
        red.SetActive(true);
    }
    private void ShowEnergyBar()
    {
        float fillAmountEnergy = Mathf.Clamp01((float)currentEnergy / (float)enegyNeedToCallBoss);
        if (energyBar != null)
        {
            energyBar.fillAmount = fillAmountEnergy;
        }
    }
    public void MainMenu()
    {
        mainMenu.SetActive(true);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        WinMenu.SetActive(false);
        Time.timeScale = 0f; // Dừng thời gian khi ở menu chính
    }
    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        WinMenu.SetActive(false);
        Time.timeScale = 0f; // Dừng thời gian khi ở menu game over
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        WinMenu.SetActive(false);
        Time.timeScale = 0f; // Dừng thời gian khi ở menu tạm dừng
    }
    public void StartGame()
    {
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        WinMenu.SetActive(false);
        Time.timeScale = 1f; // Bắt đầu lại thời gian khi bắt đầu trò chơi
        audioManager.DefaultAudio();
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        WinMenu.SetActive(false);
        Time.timeScale = 1f; // Tiếp tục thời gian khi tiếp tục trò chơi
    }
    public void WinGame()
    {
        WinMenu.SetActive(true);
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 0f; // Dừng thời gian khi ở menu chiến thắng
    }
}
