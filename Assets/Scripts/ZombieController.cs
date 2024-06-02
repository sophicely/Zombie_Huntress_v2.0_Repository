using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    NavMeshAgent myNavMeshAgent;
    public GameObject jugador;
    public EnemyHealth enemyHealth; // Referencia al script EnemyHealth

    // Añadido: referencia al componente Animator
    public Animator animator;
    public AudioSource audioSource;

    // Añadido: clips de sonido
    public AudioClip attackSound;
    public AudioClip walkSound;

    // Añadido: controlar si el sonido de caminar ya está reproduciéndose
    private bool isWalking = false;

    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>(); // Obtener la referencia al Animator en el mismo GameObject
        enemyHealth = GetComponent<EnemyHealth>(); // Obtener la referencia al script EnemyHealth en el mismo GameObject
        // myNavMeshAgent.enabled = true; // No es necesario habilitar ya que se activa por defecto

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

    void FixedUpdate()
    {
        if (myNavMeshAgent.enabled)
        {
            myNavMeshAgent.SetDestination(jugador.transform.position);
            PlayWalkSound();
        }
        else
        {
            StopWalkSound();
        }
    }

    public void SetPlayer(GameObject playerObject)
    {
        jugador = playerObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            myNavMeshAgent.enabled = false; // Deshabilitar NavMeshAgent cuando colisiona con el jugador

            // Añadido: activar la animación de ataque
            animator.SetBool("Attack", true);

            // Añadido: reproducir sonido de ataque
            PlayAttackSound();
        }
        else if (other.gameObject.CompareTag("Ball"))
        {
            // Reducir la vida del zombie utilizando el script EnemyHealth
            enemyHealth.TakeDamage(1);
            animator.SetBool("Death", true);
        }
    }

    private void PlayAttackSound()
    {
        if (audioSource != null && attackSound != null)
        {
            // Configurar el volumen y reproducir el sonido de ataque
            audioSource.volume = 0.5f; // Ajustar el volumen según sea necesario
            audioSource.clip = attackSound;
            audioSource.Play();
        }
    }

    private void PlayWalkSound()
    {
        if (!isWalking && audioSource != null && walkSound != null)
        {
            // Configurar el volumen y reproducir el sonido de caminar
            audioSource.volume = 0.5f; // Ajustar el volumen según sea necesario
            audioSource.clip = walkSound;
            audioSource.Play();
            isWalking = true;
        }
    }

    private void StopWalkSound()
    {
        if (isWalking)
        {
            // Detener el sonido de caminar
            audioSource.Stop();
            isWalking = false;
        }
    }
}
