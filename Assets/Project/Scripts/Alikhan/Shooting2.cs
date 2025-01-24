using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting2 : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;

    public GameObject crosshairs;
    public GameObject bulletPrefab;
    public GameObject bulletStart;

    public float bulletSpeed = 30.0f;
    public float fireRate = 0.5f; 

    public int maxAmmo = 10;
    private int currentAmmo; 
    public float ammoRestoreRate = 1.0f; 

    private bool isShooting = false; 
    private bool isRestoringAmmo = false; 

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Cursor.visible = false;

        currentAmmo = maxAmmo; 
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshairs.transform.position = new Vector2(mousePos.x, mousePos.y);

        
        Vector3 difference = mousePos - gameObject.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (Input.GetMouseButton(0) && currentAmmo > 0 && !isShooting)
        {
            isShooting = true;
            StartCoroutine(ShootContinuously());
        }

        if (Input.GetMouseButtonUp(0))
        {
            isShooting = false;
        }

        if (!isShooting && !isRestoringAmmo && currentAmmo < maxAmmo)
        {
            StartCoroutine(RestoreAmmo());
        }
    }

    IEnumerator ShootContinuously()
    {
        while (isShooting && currentAmmo > 0)
        {
            mousePos = mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
            Vector3 difference = mousePos - gameObject.transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();

            fireBullet(direction, rotationZ);

            currentAmmo--;

            yield return new WaitForSeconds(fireRate);
        }

        isShooting = false;
    }

    IEnumerator RestoreAmmo()
    {
        isRestoringAmmo = true;

        while (!isShooting && currentAmmo < maxAmmo)
        {
            yield return new WaitForSeconds(ammoRestoreRate);
            currentAmmo++; 
        }

        isRestoringAmmo = false;
    }

    void fireBullet(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = bulletStart.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
