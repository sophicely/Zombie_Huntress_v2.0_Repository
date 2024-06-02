using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boton_menu : MonoBehaviour
{
    public AudioClip Sound;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void BotonStart()
    {
        SceneManager.LoadScene(1);
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }
}
