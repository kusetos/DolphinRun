using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathManager : MonoBehaviour
{
    public static DeathManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else 
            Instance = this;
    }

    public void OnDeath()
    {
        StartCoroutine(DeathCoroutine());
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator DeathCoroutine()
    {
        BlackScreenManager.Instance.FadeScreenIn();
        yield return new WaitForSeconds(BlackScreenManager.Instance.FadeTime);

        RestartGame();

        yield return null;
    }
}
