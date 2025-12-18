using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class tp : MonoBehaviour
{
    private GameObject snakeHead;
    void Start()
    {
        snakeHead = GameObject.FindGameObjectWithTag("Head");
    }
    void OnTriggerEnter2D(Collider2D col)
    {
     
        if(col.gameObject.tag == "cpy" )
        {
            mover mover = snakeHead.GetComponent<mover>();
            mover.ShrinkAndRestartScene();
        }
    }  
}