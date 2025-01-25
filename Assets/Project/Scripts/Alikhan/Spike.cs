using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : Obstacle
{
    public GameObject visual;
    private void Start()
    {
        visual.gameObject.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<RotateToTargert>(out RotateToTargert player))
        {
            DeathManager.Instance.OnDeath();
        }
    }
}
