using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPausa : MonoBehaviour
{
    public GameObject menuPausaUI;
    public Slider sliderVelocidad;
    public ControlJugador controlJugador;

    public void Salir()
    {
        // Salir del juego (en Unity se detiene el juego, en build cerrará la aplicación)
        Application.Quit();
        Debug.Log("El juego se ha cerrado");
    }

    public void CambiarVelocidadJugador()
    {
        // Cambia la velocidad de movimiento del jugador según el valor del slider
        controlJugador.velocidadMovimiento = sliderVelocidad.value+5f;
    }

    public void Reanudar()
    {
        // Usamos la funcion reanudar de player
        controlJugador.Reanudar();
    }
}