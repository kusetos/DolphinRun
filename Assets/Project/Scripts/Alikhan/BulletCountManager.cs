using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletCountManager : MonoBehaviour
{
    public Slider slider;

    private int maxBullets;

    private void Start()
    {
        maxBullets = Shooting2.Instance.bubbleAmount;
    }

    private void Update()
    {
        int bubbles = Shooting2.Instance.bubbleAmount;

        slider.value = (float)bubbles/maxBullets;
    }
}
