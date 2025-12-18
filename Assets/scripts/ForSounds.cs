using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForSounds : MonoBehaviour
{
    
    private GameObject walkSound;
    private GameObject bonkSound;
    public GameObject knopkaSound;
    private GameObject soundToggle;

    //[SerializeField] protected AudioClip damageAudio;
    //private AudioManager audioManager;
    
    


    // proverka = true;
    //                 walkSound.GetComponent<AudioSource>().Play(0);
    //            }
    //            else
    //            {
    //                 proverka = false;
    //                 bonkSound.GetComponent<AudioSource>().Play(0);
        
// void OnLevelWasLoaded()
//      {

//           bonkSound = GameObject.FindGameObjectWithTag("bonkSound");
//           walkSound = GameObject.FindGameObjectWithTag("walkSound");

//      }

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







    /*public void Awake()
    {
        Health = maxHealth;
        audioManager = FindObjectOfType<AudioManager>();//
    }*/
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] bonksoundobjs = GameObject.FindGameObjectsWithTag("bonkSound");
        if (bonksoundobjs.Length > 1)
        {
            Destroy(GameObject.FindGameObjectWithTag("bonkSound"));
        }
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("bonkSound"));



        GameObject[] movesoundobjs = GameObject.FindGameObjectsWithTag("moveSound");
        if (movesoundobjs.Length > 1)
        {
            Destroy(GameObject.FindGameObjectWithTag("moveSound"));
        }
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("moveSound"));



        GameObject[] soundobjs = GameObject.FindGameObjectsWithTag("sounds");
        if (soundobjs.Length > 1)
        {
            Destroy(GameObject.FindGameObjectWithTag("sounds"));
        }
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("sounds"));



        GameObject[] codeobjs = GameObject.FindGameObjectsWithTag("soundCdoe");
        if (codeobjs.Length > 1)
        {
            Destroy(GameObject.FindGameObjectWithTag("soundCdoe"));
        }
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("soundCdoe"));


       // audioManager.PlayAudio(damageAudio);
    }

    void OnLevelWasLoaded()
    {
        
        bonkSound = GameObject.FindGameObjectWithTag("bonkSound");
        walkSound = GameObject.FindGameObjectWithTag("moveSound");
        soundToggle = GameObject.FindGameObjectWithTag("soundTog");
        
        if (Prefs_Getint("Sound") == 1)
        {
            walkSound.SetActive(true);
            bonkSound.SetActive(true);
            knopkaSound.SetActive(true);
        }
        else if (Prefs_Getint("Sound") == 0)
        {
            walkSound.SetActive(false);
            bonkSound.SetActive(false);
            knopkaSound.SetActive(false);
            soundToggle.GetComponent<Toggle>().isOn=false;
        
        }


        
    }

    void Update()
        {
            Debug.Log(Prefs_Getint("Sound"));
            if (soundToggle.GetComponent<Toggle>().isOn == true)
            {
                Prefs_SetInt("Sound", 1);
                walkSound.SetActive(true);
                bonkSound.SetActive(true);
                knopkaSound.SetActive(true);
            }
            else
            {
                Prefs_SetInt("Sound", 0);
                walkSound.SetActive(false);
                bonkSound.SetActive(false);
                knopkaSound.SetActive(false);
            }
        
        }


    
}
