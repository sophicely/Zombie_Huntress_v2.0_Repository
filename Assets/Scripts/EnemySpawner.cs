using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject zombiePrefab; // Prefab del zombie a generar
    public Transform spawnPoint; // Punto de aparici�n del zombie
    public float spawnInterval = 3f; // Intervalo de tiempo entre cada generaci�n de zombies
    public GameObject player; // Referencia al jugador

    void Start()
    {
        // Iniciar la generaci�n de zombies cada 3 segundos
        StartCoroutine(SpawnZombies());
    }

    IEnumerator SpawnZombies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            // Generar dos nuevos zombies en el punto de aparici�n
            GameObject newZombie1 = Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);
            GameObject newZombie2 = Instantiate(zombiePrefab, spawnPoint.position + new Vector3(1f, 0f, 0f), spawnPoint.rotation);

            // Asignar la referencia al jugador a los nuevos zombies
            ZombieController zombieController1 = newZombie1.GetComponent<ZombieController>();
            if (zombieController1 != null)
            {
                zombieController1.SetPlayer(player);
            }

            ZombieController zombieController2 = newZombie2.GetComponent<ZombieController>();
            if (zombieController2 != null)
            {
                zombieController2.SetPlayer(player);
            }
        }
    }
}
