using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForMusic : MonoBehaviour
{
    private GameObject grid;
    private GameObject gridToggle;
    private GameObject musicToggle;
    public AudioSource music;





    public void Prefs_SetInt(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }

    public int Prefs_Getint(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }

    public void Prefs_SetString(string KeyName, string Value)
    {
        PlayerPrefs.SetString(KeyName, Value);
    }

    public string Prefs_GetString(string KeyName)
    {
        return PlayerPrefs.GetString(KeyName);
    }
    
    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);





        if (Prefs_Getint("Music") == 1)
        {
            music.mute = false;

        }
        else if (Prefs_Getint("Music") == 0)
        {
            music.mute = true;
            musicToggle.GetComponent<Toggle>().isOn=false;
        }
    }
    void OnLevelWasLoaded()
    {
        grid = GameObject.FindGameObjectWithTag("grid");
        gridToggle = GameObject.FindGameObjectWithTag("GridTog");
        musicToggle = GameObject.FindGameObjectWithTag("MusTog");

        if (Prefs_Getint("Music") == 1)
        {
            music.mute = false;

        }
        else if (Prefs_Getint("Music") == 0)
        {
            music.mute = true;
            musicToggle.GetComponent<Toggle>().isOn=false;
        }
        
        if (Prefs_Getint("Grid") == 1)
        {
            grid.SetActive(true);
            gridToggle.GetComponent<Toggle>().isOn=true;
        }
        else if (Prefs_Getint("Grid") == 0)
        {
            grid.SetActive(false);
            gridToggle.GetComponent<Toggle>().isOn=false;
        }
    }

    void Update()
    {
        if (musicToggle != null && musicToggle.GetComponent<Toggle>() != null && gridToggle != null && gridToggle.GetComponent<Toggle>() != null)
        {
            if (musicToggle.GetComponent<Toggle>().isOn == true)
            {
                Prefs_SetInt("Music", 1);
                if (music != null)
                {
                    music.mute = false;
                }
            }
            else
            {
                Prefs_SetInt("Music", 0);
                if (music != null)
                {
                    music.mute = true;
                }
            }
    
            if (gridToggle.GetComponent<Toggle>().isOn == true)
            {
                Prefs_SetInt("Grid", 1);
                if (grid != null)
                {
                    grid.SetActive(true);
                }
            }
            else
            {
                Prefs_SetInt("Grid", 0);
                if (grid != null)
                {
                    grid.SetActive(false);
                }
            }
        }
    }





}
