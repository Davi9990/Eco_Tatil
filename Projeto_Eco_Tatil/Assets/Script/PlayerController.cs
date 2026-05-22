using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidadeOriginal = 4f;
    public float raioDetecao = 3f;
    private float velocidadeAtual;
    private Rigidbody2D rb;
    private Vector2 inputsMovimento;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocidadeAtual = velocidadeOriginal;
    }

    // Update is called once per frame
    void Update()
    {
        inputsMovimento.x = Input.GetAxisRaw("Horizontal");
        inputsMovimento.y = Input.GetAxisRaw("Vertical");

        // Executa a Varredura da bengala ao apertar ESPAÇO
        if(Input.GetKeyDown(KeyCode.Space))
        {
            BengalaVarredura();
        }
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + inputsMovimento.normalized * velocidadeAtual * Time.fixedDeltaTime);

    }

    void BengalaVarredura()
    {
        Debug.Log("Varredura Ativa!");

        //float raioDetecao = 3f;
        Collider2D[] objetosDetectados = Physics2D.OverlapCircleAll(transform.position, raioDetecao);

        foreach(Collider2D colisor in objetosDetectados )
        {
            ElementoTatil elemento = colisor.GetComponent<ElementoTatil>();
            if(elemento != null)
            {
                elemento.RevelarElemento();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, raioDetecao);
    }
}
