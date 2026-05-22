using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RastreamentoMao : MonoBehaviour
{
    public float velocidadeReduzida = 1.5f;
    private Rigidbody2D rb;
    public bool encostadoNaParede = false;
    private Collider2D paredeAtual;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Se o jogador estiver encostado na parede E segurando o Shift Esquerdo
        if (encostadoNaParede && Input.GetKey(KeyCode.LeftShift))
        {
            AtivarRastreamento();
        }
    }

    void AtivarRastreamento()
    {
        Vector2 velocidadeReta = rb.velocity;

        if(Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0)
        {
            velocidadeReta.x = 0;
            velocidadeReta.y = Input.GetAxisRaw("Vertical") * velocidadeReduzida;
        }

        rb.velocity = velocidadeReta;

        Collider2D[] itensProximos = Physics2D.OverlapCircleAll(transform.position, 1.2f);
        foreach (Collider2D item in itensProximos)
        {
            if (item.CompareTag("PontosInteresse"))
            {
                ElementoTatil elemento = item.GetComponent<ElementoTatil>();
                if(elemento != null)
                {
                    elemento.RevelarElemento();
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Parede"))
        {
            encostadoNaParede = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Parede"))
        {
            encostadoNaParede = false;
        }
    }
}
