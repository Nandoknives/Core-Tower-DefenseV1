using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve curve;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }
    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }
    IEnumerator FadeIn()
    {
        float t = 1.5f;
        while ( t> 0f )
        {
            t -= Time.deltaTime*1f;
            float a = curve.Evaluate(t);
            img.color = new Color (0f, 0f, 0f, a);
            yield return 0; //Skip to the next frame(wait a single frame)
        }


    }
    IEnumerator FadeOut(string scene)
    {
        float t = 0f;
        while (t > 1.5f)
        {
            t += Time.deltaTime * 1f;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0; //Skip to the next frame(wait a single frame)
        }
        SceneManager.LoadScene(scene);

    }


}
