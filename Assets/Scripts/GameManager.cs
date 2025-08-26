using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int PuntosTotales { get{ return puntosTotales; } }
    private int puntosTotales;
    public void SumarPuntos(int punstosASumar)
    {
        puntosTotales += punstosASumar;
        Debug.Log(puntosTotales);
    }
    
}
