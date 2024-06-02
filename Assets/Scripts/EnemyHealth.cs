using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int vidaMaxima = 3;
    private int vidaActual;

    void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void TakeDamage(int cantidad)
    {
        vidaActual -= cantidad;

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    private void Morir()
    {
        Destroy(gameObject, 1f); // Destruir el objeto después de 2 segundos
    }

}
