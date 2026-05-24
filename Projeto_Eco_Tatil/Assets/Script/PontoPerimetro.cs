using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontoPerimetro : MonoBehaviour
{
    private bool jaFoiDescoberto = false;

    public void DescobriuPonto()
    {
        if (!jaFoiDescoberto)
        {
            jaFoiDescoberto = true;

            // Procura o Gerenciador na cena e avisa que uma pista foi computada
            GerenciadorFamiliarizacao gerenciador = FindFirstObjectByType<GerenciadorFamiliarizacao>();
            if (gerenciador != null)
            {
                gerenciador.RegistrarPontoMental();
            }
        }
    }
}
