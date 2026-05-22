using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementoTatil : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public float tempoVisivel = 1.5f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if(spriteRenderer == null )
        {
            spriteRenderer.enabled = false;
        }
    }

    public void RevelarElemento()
    {
        StopAllCoroutines();
        StartCoroutine(FluxoRevelacao());
    }


    IEnumerator FluxoRevelacao()
    {
        if(spriteRenderer != null)
        {
            spriteRenderer.enabled = true; // Acende o elemento (Alto Contraste)
        }

        // Colocar um audio curto aqui por favor

        yield return new WaitForSeconds(tempoVisivel);

        if(spriteRenderer != null)
        {
            spriteRenderer.enabled = false; // Apaga de novo (Volta para a escuridão)
        }
    }
}
