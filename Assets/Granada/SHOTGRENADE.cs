using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject grenade;
    public Transform spawnPoint;
    public float shotForce = 1500f;
    public float shotRate = 0.5f;
    private float shotRateTime = 0f;

    // Referencia al script de recolección de gasolina.
    public ColeccionGasolina sistemaRecoleccion;

    // Variable para controlar si ya se lanzó una granada.
    private bool hasLaunchedGrenade = false;

    void Update()
    {
        // Verifica si el jugador ha presionado el botón de disparo, si ha recolectado exactamente 5 gasolinas y si no ha lanzado una granada todavía.
        if (Input.GetButtonDown("Fire1") && sistemaRecoleccion.CantidadGasolina == 5 && !hasLaunchedGrenade)
        {
            if (Time.time > shotRateTime)
            {
                // Lanza la granada.
                GameObject newGrenade = Instantiate(grenade, spawnPoint.position, spawnPoint.rotation);
                newGrenade.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);
                shotRateTime = Time.time + shotRate;
                Destroy(newGrenade, 2);

                // Actualiza la variable para que no se pueda lanzar más granadas.
                hasLaunchedGrenade = true;
            }
        }
    }
}

