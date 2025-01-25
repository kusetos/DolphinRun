using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreenManager : MonoBehaviour
{
    public static BlackScreenManager Instance;

    public Image blackScreen;
    public float FadeTime;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
            Instance = this;
    }

    public void FadeScreenIn()
    {
        blackScreen.DOFade(1, FadeTime);
    }

    public void FadeScreenOut()
    {
        blackScreen.gameObject.SetActive(true);
        blackScreen.DOFade(0, FadeTime);
    }
}
