using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnquadramentoDirecao : MonoBehaviour
{
    private LineRenderer linhaGuia;
    private bool naFaixaPedestre = false;
    public float comprimentoLinha = 5f;


    void Start()
    {
        linhaGuia = GetComponent<LineRenderer>();
        linhaGuia.positionCount = 2;
        linhaGuia.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(naFaixaPedestre && Input.GetKeyDown(KeyCode.E))
        {
            ProjetarLinhaGuia();
        }
    }

    void ProjetarLinhaGuia()
    {
        linhaGuia.enabled = true;

        //Define a posição inicial (no jogador) e a final (reta para cima/frente)
        linhaGuia.SetPosition(0, transform.position);
        linhaGuia.SetPosition(1, transform.position + Vector3.up * comprimentoLinha);

        Invoke("DesativarLinha", 3f);
    }

    void DesativarLinha()
    {
        linhaGuia.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FaixaPedestres"))
        {
            naFaixaPedestre = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("FaixaPedestres"))
        {
            naFaixaPedestre = false;
            DesativarLinha();
        }
    }
}
