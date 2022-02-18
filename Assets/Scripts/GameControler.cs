using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControler : MonoBehaviour
{
    public bool isEndgame;
    bool isstartfirsttime = true;
    int Gamepoint = 0;
    public Text txtPoint;
    public GameObject Panel;
    public Text txtEndpoint;
    public Button restart;

    public Sprite RestartIdle;
    public Sprite RestartOver;
    public Sprite RestartClick;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        isEndgame = false;
        isstartfirsttime = true;
        Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isEndgame)
        {
            if (Input.GetMouseButtonDown(0) && isstartfirsttime)
            {
                Startgame();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 1;
            }

        }
    }
    
    void Startgame()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        Startgame();
    }

    public void GetPoint()
    {
        Gamepoint++;
        txtPoint.text = "Point: " + Gamepoint.ToString();
    }

    public void Endgame()
    {

        Debug.Log("End Game");
        Time.timeScale = 0;
        isEndgame = true;
        isstartfirsttime = false;
        Panel.SetActive(true);
        txtEndpoint.text = "Your Point " + Gamepoint.ToString();

    }

    public void RestartButtonClick()
    {
        restart.GetComponent<Image>().sprite = RestartClick;

    }
    public void RestartButtonOver()
    {
        restart.GetComponent<Image>().sprite = RestartOver;
    }
    public void RestartButtonIdle()
    {
        restart.GetComponent<Image>().sprite = RestartIdle;
    }
}
