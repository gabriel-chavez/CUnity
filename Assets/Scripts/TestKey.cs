using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestKey : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //1.- MOUSE
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("boton presionado");
        }
        if (Input.GetMouseButton(0))
        {
            Debug.Log("boton esta presionado");
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("boton soltado");
        }

        // 1 Click derecho
        // 2 Click central

        //2.- EVENTOS
        //Boton de teclado
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Salto");
        }
        // boton de eventos unity
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Salto desde eventos unity");
        }

        //3.- AXIS FOR MOVEMENT
        float horizontal = Input.GetAxis("Horizontal"); //-1 a 1
        float vertical = Input.GetAxis("Vertical"); //-1 a 1

        if(horizontal <0f || horizontal > 0f)
        {
            Debug.Log("Horizontal axis:" + horizontal);
        }
        if (vertical < 0f || vertical > 0f)
        {
            Debug.Log("Vertical axis:" + vertical);
        }
    }
}
