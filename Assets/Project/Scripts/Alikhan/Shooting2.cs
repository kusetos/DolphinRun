using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shooting2 : MonoBehaviour
{
    public static Shooting2 Instance;

    private Camera mainCam;
    private Vector3 mousePos;

    public GameObject crosshairs;
    public GameObject bulletPrefab;
    public GameObject bulletStart;

    public int bubbleAmount = 100;
    public float bulletSpeed = 30.0f;
    public float fireRate = 0.5f; 

    private bool isShooting = false;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Cursor.visible = false;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
            Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (bubbleAmount <= 0)
        {
            DeathManager.Instance.OnDeath();
        }

        mousePos = mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshairs.transform.position = new Vector2(mousePos.x, mousePos.y);

        
        Vector3 difference = mousePos - gameObject.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (Input.GetMouseButton(0) && !isShooting)
        {
            isShooting = true;
            StartCoroutine(ShootContinuously());
        }

        if (Input.GetMouseButtonUp(0))
        {
            isShooting = false;
        }
    }

    IEnumerator ShootContinuously()
    {
        while (isShooting)
        {
            mousePos = mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
            Vector3 difference = mousePos - gameObject.transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();

            fireBullet(direction, rotationZ);

            yield return new WaitForSeconds(fireRate);
        }
    }

    void fireBullet(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = bulletStart.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        bubbleAmount--;
    }
}
