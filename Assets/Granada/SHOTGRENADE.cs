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

    // Referencia al script de recolecci�n de gasolina.
    public ColeccionGasolina sistemaRecoleccion;

    // Variable para controlar si ya se lanz� una granada.
    private bool hasLaunchedGrenade = false;

    void Update()
    {
        // Verifica si el jugador ha presionado el bot�n de disparo, si ha recolectado exactamente 5 gasolinas y si no ha lanzado una granada todav�a.
        if (Input.GetButtonDown("Fire1") && sistemaRecoleccion.CantidadGasolina == 5 && !hasLaunchedGrenade)
        {
            if (Time.time > shotRateTime)
            {
                // Lanza la granada.
                GameObject newGrenade = Instantiate(grenade, spawnPoint.position, spawnPoint.rotation);
                newGrenade.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);
                shotRateTime = Time.time + shotRate;
                Destroy(newGrenade, 2);

                // Actualiza la variable para que no se pueda lanzar m�s granadas.
                hasLaunchedGrenade = true;
            }
        }
    }
}

