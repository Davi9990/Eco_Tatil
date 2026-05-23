using UnityEngine;

public class RastreamentoMao : MonoBehaviour
{
    public float velocidadeReduzida = 1.5f;
    private Rigidbody2D rb;
    private bool encostadoNaParede = false;
    private Collision2D paredeAtual; // Agora guarda a colisão física

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (encostadoNaParede && Input.GetKey(KeyCode.LeftShift))
        {
            AtivarRastreamento();
        }
    }

    void AtivarRastreamento()
    {
        Vector2 velocidadeReta = rb.velocity;

        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0)
        {
            velocidadeReta.x = 0;
            velocidadeReta.y = Input.GetAxisRaw("Vertical") * velocidadeReduzida;
        }
        else if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0)
        {
            velocidadeReta.y = 0; 
            velocidadeReta.x = Input.GetAxisRaw("Horizontal") * velocidadeReduzida;
        }

        rb.velocity = velocidadeReta;

        if (paredeAtual != null && paredeAtual.gameObject != null)
        {
            ElementoTatil elemento = paredeAtual.gameObject.GetComponent<ElementoTatil>();
            if (elemento != null)
            {
                elemento.RevelarElemento(); // Acende o bloco de parede
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Parede"))
        {
            encostadoNaParede = true;
            paredeAtual = collision; // Memoriza o bloco de parede tocado
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Parede"))
        {
            encostadoNaParede = false;
            paredeAtual = null; // Limpa a referência
        }
    }
}