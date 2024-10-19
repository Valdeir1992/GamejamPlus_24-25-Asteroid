using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public Image BackGround;
    private void Start()
    {
        FadeIn(2, null, 2);
    }


    public void FadeIn(float time, Action CallBack, float delay)
    {
        StartCoroutine(Coroutine_FadeIn(time, CallBack));
    }

    private IEnumerator Coroutine_FadeIn(float time, Action callBack, float Delay = 1)
    {
        yield return new WaitForSeconds(Delay);
        float ElipsedTime = 0;
        while (ElipsedTime <= 1)
        {
            ElipsedTime += Time.deltaTime;
            BackGround.color = Color.Lerp(new Color(0, 0, 0, 1), new Color(0, 0, 0, 0), ElipsedTime);
            yield return null;
        }

        BackGround.raycastTarget = false;

        if (callBack != null)
        {
            callBack();
        }

        yield break;
    }


    public void FadeOut(float time, Action CallBack, float delay)
    {
        StartCoroutine(Coroutine_FadeOut(time, CallBack));
    }

    private IEnumerator Coroutine_FadeOut(float time, Action callBack, float Delay = 1)
    {
        BackGround.raycastTarget = true;
        yield return new WaitForSeconds(Delay);
        float ElipsedTime = 0;
      
        while (ElipsedTime <= 1)
        {
            ElipsedTime += Time.deltaTime;
            BackGround.color = Color.Lerp(new Color(0, 0, 0, 0), new Color(0, 0, 0, 1), ElipsedTime);
            yield return null;
        }

        if (callBack != null)
        {
            callBack();
        }

        yield break;
    }

}
