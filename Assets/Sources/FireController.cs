using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    //Agregan punto de inicio de donde la bala saldra.
    public GameObject BalaPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            //1-Instanciar la BalaPrefab en las posiciones de BalaInicio
            GameObject BalaTemporal = Instantiate(BalaPrefab, GetComponent<Transform>().position, GetComponent<Transform>().rotation) as GameObject;

            //Obtener Rigidbody para agregar Fuerza. 
            Rigidbody rb = BalaTemporal.GetComponent<Rigidbody>();

            //Agregar la fuerza a la Bala
            rb.AddForce(transform.forward * 10000f, ForceMode.Force);

            //Debemos Destruir la bala
            Destroy(BalaTemporal, 5.0f);
        }
    }
}
