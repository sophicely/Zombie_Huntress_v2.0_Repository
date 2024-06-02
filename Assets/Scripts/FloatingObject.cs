using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float floatingSpeed = 1f; // Velocidad de flotación
    public float floatingHeight = 1f; // Altura máxima de flotación
    private Vector3 startPosition; // Posición inicial del objeto

    void Start()
    {
        // Guardar la posición inicial del objeto
        startPosition = transform.position;
    }

    void Update()
    {
        // Calcular la posición vertical usando la función seno para crear una oscilación suave
        float newY = startPosition.y + Mathf.Sin(Time.time * floatingSpeed) * floatingHeight;

        // Actualizar la posición del objeto
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
