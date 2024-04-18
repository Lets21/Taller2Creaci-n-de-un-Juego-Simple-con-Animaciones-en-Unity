using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHOTROCKET : MonoBehaviour
{
    public GameObject rocket;
    public Transform spawnPoint;
    public float shotForce = 1500f;
    public float shotRate = 0.5f;
    private float shotRateTime = 0f;

    // Referencia al script de recolección de gasolina.
    public ColeccionGasolina sistemaRecoleccion;

    void Update()
    {
        // Verifica si el jugador ha presionado el botón de disparo y si ha recolectado al menos 5 gasolinas.
        if (Input.GetButtonDown("Fire1") && sistemaRecoleccion.CantidadGasolina >= 10)
        {
            if (Time.time > shotRateTime)
            {
                GameObject newRocket = Instantiate(rocket, spawnPoint.position, spawnPoint.rotation);
                newRocket.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);
                shotRateTime = Time.time + shotRate;
                Destroy(newRocket, 2);
            }
        }
    }
}

