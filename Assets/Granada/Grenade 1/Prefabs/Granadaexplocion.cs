using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granadaexplocion : MonoBehaviour

{
    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto con el que colisionó tiene el tag "Ground".
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Destruye la granada.
            Destroy(gameObject);
        }
    }
}

