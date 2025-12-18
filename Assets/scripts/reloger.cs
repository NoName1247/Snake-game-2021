using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class reloger : MonoBehaviour
{   
    public GameObject cloud;
    private Animator cloudd;

    public void OpenMenu()
    {
        
        cloudd = cloud.GetComponent<Animator>();
        cloudd.SetBool("close", true);

        StartCoroutine(LoadLevelAfterAnimation("Menu"));
    }

    public void Openset()
    {
        cloudd = cloud.GetComponent<Animator>();
        cloudd.SetBool("close", true);

        StartCoroutine(LoadLevelAfterAnimation("Setings"));
    }
    
    public void Openlevelmenu()
    {
        cloudd = cloud.GetComponent<Animator>();
        cloudd.SetBool("close", true);

        StartCoroutine(LoadLevelAfterAnimation("level menu"));
    }



    public void Opentutorial()
    {
        cloudd = cloud.GetComponent<Animator>();
        cloudd.SetBool("close", true);

        StartCoroutine(LoadLevelAfterAnimation("tutorial"));
    }

    public void Openlevel1()
    {
        cloudd = cloud.GetComponent<Animator>();
        cloudd.SetBool("close", true);

        StartCoroutine(LoadLevelAfterAnimation("level1"));
    }

    public void Openlevel2()
    {
        cloudd = cloud.GetComponent<Animator>();
        cloudd.SetBool("close", true);

        StartCoroutine(LoadLevelAfterAnimation("level2"));
    }

    public void Openlevel3()
    {
        cloudd = cloud.GetComponent<Animator>();
        cloudd.SetBool("close", true);

        StartCoroutine(LoadLevelAfterAnimation("level3"));
    }

    public void Openlevel4()
    {
        cloudd = cloud.GetComponent<Animator>();
        cloudd.SetBool("close", true);

        StartCoroutine(LoadLevelAfterAnimation("level4"));
    }

    public void Openlevel5()
    {
        cloudd = cloud.GetComponent<Animator>();
        cloudd.SetBool("close", true);

        StartCoroutine(LoadLevelAfterAnimation("level5"));
    }

    public void Openlevel6()
    {
        cloudd = cloud.GetComponent<Animator>();
        cloudd.SetBool("close", true);

        StartCoroutine(LoadLevelAfterAnimation("level6"));
    }

    public void Openlevel7()
    {
        cloudd = cloud.GetComponent<Animator>();
        cloudd.SetBool("close", true);

        StartCoroutine(LoadLevelAfterAnimation("level7"));
    }

    public void Openlevel8()
    {
        cloudd = cloud.GetComponent<Animator>();
        cloudd.SetBool("close", true);

        StartCoroutine(LoadLevelAfterAnimation("level8"));
    }

    public void Openlevel9()
    {
        cloudd = cloud.GetComponent<Animator>();
        cloudd.SetBool("close", true);

        StartCoroutine(LoadLevelAfterAnimation("level9"));
    }

    public void Openlevel10()
    {
        cloudd = cloud.GetComponent<Animator>();
        cloudd.SetBool("close", true);

        StartCoroutine(LoadLevelAfterAnimation("level10"));
    }


    public void ReastartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    private IEnumerator LoadLevelAfterAnimation(string sceneName)
    {
        RectTransform cloudRectTransform = cloud.GetComponent<RectTransform>();

        while (Mathf.Abs(cloudRectTransform.anchoredPosition.x) > 0.01f)
        {
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator restart()
    {
        RectTransform cloudRectTransform = cloud.GetComponent<RectTransform>();

        while (Mathf.Abs(cloudRectTransform.anchoredPosition.x) > 0.01f)
        {
            yield return null;
        }

        
    }

}