using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorial1;
    public float time1 = 2f;
    public GameObject tutorial2;
    public float time2 = 2f;
    public GameObject tutorial3;
    public float time3 = 2f;
    public GameObject tutorial4;
    public float time4 = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameTutorial());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GameTutorial()
    {
        //Slide1
        yield return new WaitForSeconds(time1);
        if(tutorial1 != null)
        {
            tutorial1.SetActive(!tutorial1.activeSelf);
            yield return new WaitForSeconds(0.7f);
            Time.timeScale = 0f;
        }
        else
        {
           yield break;
        }
        //Slide2
        yield return new WaitForSeconds(time2);
        if (tutorial2 != null)
        {
            tutorial2.SetActive(!tutorial2.activeSelf);
            yield return new WaitForSeconds(0.7f);
            Time.timeScale = 0f;
        }
        else
        {
            yield break;
        }
        //Slide3
        yield return new WaitForSeconds(time3);
        if (tutorial3 != null)
        {
            tutorial3.SetActive(!tutorial3.activeSelf);
            yield return new WaitForSeconds(0.7f);
            Time.timeScale = 0f;
        }
        else
        {
            yield break;
        }
        //Slide4
        yield return new WaitForSeconds(time4);
        if (tutorial4 != null)
        {
            tutorial4.SetActive(!tutorial4.activeSelf);
            yield return new WaitForSeconds(0.7f);
            Time.timeScale = 0f;
        }
        else
        {
            yield break;
        }

    }
    public void Toggle1()
    {

        tutorial1.SetActive(!tutorial1.activeSelf);
        if (tutorial1.activeSelf)
        {
            Time.timeScale = 0f;


        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void Toggle2()
    {

        tutorial2.SetActive(!tutorial2.activeSelf);
        if (tutorial2.activeSelf)
        {
            Time.timeScale = 0f;


        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void Toggle3()
    {

        tutorial3.SetActive(!tutorial3.activeSelf);
        if (tutorial3.activeSelf)
        {
            Time.timeScale = 0f;


        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void Toggle4()
    {

        tutorial4.SetActive(!tutorial4.activeSelf);
        if (tutorial4.activeSelf)
        {
            Time.timeScale = 0f;


        }
        else
        {
            Time.timeScale = 1f;
        }
    }

}
