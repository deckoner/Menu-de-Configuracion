using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlJugador : MonoBehaviour
{
    private Controls controles;
    private Vector2 movimiento;
    private Rigidbody rb;
    public float velocidadMovimiento = 5f;
    public float fuerzaSalto = 7f;
    private bool enElSuelo = true;

    private void Awake()
    {
        // Inicializamos la clase de controles
        controles = new Controls();
        
        // Suscripcion al evento de moverse
        controles.Player.Mover.performed += ctx => movimiento = ctx.ReadValue<Vector2>();
        controles.Player.Mover.canceled += ctx => movimiento = Vector2.zero;

        // Suscripcion al evento de saltar
        controles.Player.Salto.performed += ctx => Saltar();

        // Suscripcion al evento de pausa
        controles.Player.Salto.performed += ctx => Saltar();
        
        // Referencia al Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        // Habilitamos los controles
        controles.Player.Enable();
    }

    private void OnDisable()
    {
        // Deshabilitamos los controles
        controles.Player.Disable();
    }

    private void FixedUpdate()
    {
        // Movemos al jugador en el eje X y Z
        Vector3 direccion = new Vector3(movimiento.x, 0, movimiento.y) * velocidadMovimiento * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + direccion);
    }

    private void Saltar()
    {
        if (enElSuelo)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            enElSuelo = false; // No podemos saltar de nuevo hasta que toquemos el suelo
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // Si tocamos el suelo, permitimos saltar de nuevo
        if (other.gameObject.CompareTag("Suelo"))
        {
            enElSuelo = true;
        }
    }
}