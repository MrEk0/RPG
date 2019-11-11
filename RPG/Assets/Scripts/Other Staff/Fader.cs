using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    CanvasGroup canvasGroup;
    Coroutine activeCoroutine;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        activeCoroutine = null;
    }

    public void FadeOutImmediate()
    {
        canvasGroup.alpha = 1;
    }

    public Coroutine FadeOut(float time)// coroutine instead of IEnumerator to be able to move 
                                        //the player while fadeIn implementation
    {
        return Fade(1, time);       
    } 

    public Coroutine FadeIn(float time)
    {
        return Fade(0, time);
    }

    private Coroutine Fade(float target, float time)
    {
        if (activeCoroutine != null)
        {
            StopCoroutine(activeCoroutine);
        }

        activeCoroutine = StartCoroutine(FadeImplementation(target, time));
        return activeCoroutine;
    }

    private IEnumerator FadeImplementation(float target, float time)
    {
        while (!Mathf.Approximately(canvasGroup.alpha, target))
        {
            canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, target, Time.deltaTime / time);
            yield return null;
        }
    }
}
