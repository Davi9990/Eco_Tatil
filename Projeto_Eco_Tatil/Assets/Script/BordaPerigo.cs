using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BordaPerigo : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(spriteRenderer != null)
            {
                spriteRenderer.enabled = true;
                //Altera a cor para amarelo Ouro (Alerta) conform o GDD
                spriteRenderer.color = new Color(1f, 0.8f, 0f);
            }
        }
    }

    //Quandoo o jogador se afasta
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(spriteRenderer != null)
            {
                if(spriteRenderer != null)
                {
                    spriteRenderer.enabled = false;
                }
            }
        }
    }
}
