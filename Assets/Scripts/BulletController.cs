using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody bulletRb;

    public float bulletPower = 0f;
    public float lifeTime = 4f;
    public AudioClip bulletSound; // Sonido de la bala
    private AudioSource audioSource; // Referencia al componente AudioSource

    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        bulletRb.velocity = transform.forward * bulletPower;

        // Obtener el componente AudioSource del objeto o crear uno nuevo
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Reproducir el sonido de la bala
        PlayBulletSound();

        // Destruye el objeto después de lifeTime segundos
        Invoke("DestroyBullet", lifeTime);
    }

    void PlayBulletSound()
    {
        if (bulletSound != null && audioSource != null)
        {
            audioSource.clip = bulletSound;
            audioSource.Play();
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
