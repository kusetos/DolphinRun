using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishManager : MonoBehaviour
{
    public SpriteRenderer visual;
    private void Start()
    {
        //visual.enabled = false;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("spike");
        SoundManager.Instance.PlaySound2D("2");
        if (collision.TryGetComponent<RotateToTargert>(out RotateToTargert player))
        {
            GameController.Instance.StartNextLevel();
        }
    }
}
