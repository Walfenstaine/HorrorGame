using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    public Data data;
    public GameObject gamover,andLevel, game, menue;
    public static Interface rid { get; set; }

    void Awake()
    {
        if (rid == null)
        {
            rid = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void OnDestroy()
    {
        rid = null;
    }
    private void Start()
    {
        Menue();
    }

    public void CursorOn()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void CursorOff()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    public void Gamover()
    {
        CursorOff();
        gamover.SetActive(true);
        game.SetActive(false);
        andLevel.SetActive(false);
    }
    public void Game()
    {
        CursorOn();
        menue.SetActive(false);
        gamover.SetActive(false);
        game.SetActive(true);
        andLevel.SetActive(false);
    }
    public void Menue()
    {
        CursorOff();
        menue.SetActive(true);
        gamover.SetActive(false);
        game.SetActive(false);
        andLevel.SetActive(false);
    }
    public void AndLevel()
    {
        CursorOff();
        gamover.SetActive(false);
        game.SetActive(false);
        andLevel.SetActive(true);
    }
}
