using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaBarraVida : MonoBehaviour
{
    public float vida = 100;
    public Image imagenBarraVida;

    public AudioSource audioSource;
    public AudioClip vidaBajaSound;

    private bool hasPlayedSound = false;

    void Start()
    {
        // Obtener o agregar el componente AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Configurar el AudioSource para que no destruya el clip al finalizar
        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }

    void Update()
    {
        vida = Mathf.Clamp(vida, 0, 100);
        imagenBarraVida.fillAmount = vida / 100;

        // Reproducir sonido de vida baja si la vida es menor que cierto umbral
        if (vida < 30 && !hasPlayedSound)
        {
            PlayVidaBajaSound();
            hasPlayedSound = true; // Evitar reproducir el sonido repetidamente
        }
    }

    private void PlayVidaBajaSound()
    {
        if (audioSource != null && vidaBajaSound != null)
        {
            // Configurar el volumen y reproducir el sonido de vida baja
            audioSource.volume = 0.5f; // Ajustar el volumen según sea necesario
            audioSource.clip = vidaBajaSound;
            audioSource.Play();
        }
    }
}
