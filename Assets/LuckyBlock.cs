using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyBlock : MonoBehaviour
{
    public int valor = 1;
    public GameManager gameManager;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mario"))
        {
            gameManager.SumarPuntos(valor);
            Debug.Log("Colision");
            Destroy(this.gameObject);
        }
        
    }
}
