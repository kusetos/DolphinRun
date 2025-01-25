using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : Obstacle
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("spike");
        if (collision.TryGetComponent<RotateToTargert>(out RotateToTargert player))
        {
            DeathManager.Instance.OnDeath();
        }
    }
}
