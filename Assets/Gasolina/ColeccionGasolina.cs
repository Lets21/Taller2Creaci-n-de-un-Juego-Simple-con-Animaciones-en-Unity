using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColeccionGasolina : MonoBehaviour
{
    private int cantidadGasolina;
    public TextMeshProUGUI numero;
    public AudioSource soundSource;
    private bool isTilting = false; // Para controlar el inicio de la coroutine

    public int CantidadGasolina
    {
        get { return cantidadGasolina; }
    }

    private void Update()
    {
        numero.text = cantidadGasolina.ToString();

        // Inicia el tilteo si se han recolectado 5 unidades de gasolina y no está ya tilteando
        if (cantidadGasolina == 5 && !isTilting)
        {
            StartCoroutine(TiltearNumero());
            isTilting = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gasoline"))
        {
            Destroy(other.gameObject);
            cantidadGasolina++;

            if (soundSource != null)
            {
                soundSource.Play();
            }
        }
    }

    IEnumerator TiltearNumero()
    {
        // Especifica cuántas veces quieres que el texto tiltee
        int cantidadTilteos = 5;

        for (int i = 0; i < cantidadTilteos; i++)
        {
            // Cambia el color del texto a rojo
            numero.color = Color.red;
            // Espera medio segundo
            yield return new WaitForSeconds(0.5f);
            // Cambia el color del texto a blanco
            numero.color = Color.white;
            // Espera medio segundo
            yield return new WaitForSeconds(0.5f);
        }

        // Asegúrate de restablecer el color final deseado si es necesario
        numero.color = Color.red;
    }
}