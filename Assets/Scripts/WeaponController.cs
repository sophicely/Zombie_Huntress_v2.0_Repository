using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Transform shootSpawn;
    public GameObject bulletPrefab;

    void Update()
    {
        Debug.DrawLine(shootSpawn.position, shootSpawn.position + shootSpawn.forward * 10f, Color.red);

        RaycastHit cameraHit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out cameraHit))
        {
            Vector3 shootDirection = cameraHit.point - shootSpawn.position;
            shootSpawn.rotation = Quaternion.LookRotation(shootDirection);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot();
            }
        }
    }

    public void Shoot()
    {
        if (bulletPrefab != null)
        {
            Instantiate(bulletPrefab, shootSpawn.position, shootSpawn.rotation);
        }
        else
        {
            Debug.LogError("Bullet prefab is not assigned in WeaponController.");
        }
    }
}