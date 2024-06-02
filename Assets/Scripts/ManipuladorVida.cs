using UnityEngine;

public class ManipuladorVida : MonoBehaviour
{
    public LogicaBarraVida playerVida;
    public float damageTime;
    float currentDamageTime;
    public float cantidad; // Definición de la cantidad de vida que se suma

    void Start()
    {
        //playerVida = GameObject.FindWithTag("Player").GetComponent<LogicaBarraVida>();
        //Debug.Log(playerVida.name);
         
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            currentDamageTime += Time.deltaTime;
            if (currentDamageTime > damageTime)
            {
                playerVida.vida += cantidad;
                currentDamageTime = 0.0f;
            }
        }
    }
}