using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorFamiliarizacao : MonoBehaviour
{
    public int totalPontosPerimetro = 4;
    private int pontosEncontrados = 0;

    public GameObject objetivoFinal; //O ponto B está estará desativado por padrão
    public Text textoProgresso; //Um texto simples de UI para dar feedback

    void Start()
    {
        if(objetivoFinal != null)
        {
            objetivoFinal.SetActive(false);
        }

        AtualizarInterface();
    }

    public void RegistrarPontoMental()
    {
        pontosEncontrados++;
        AtualizarInterface();

        //Se mapeou o perímetr, libera a Fase 2
        if(pontosEncontrados >= totalPontosPerimetro)
        {
            AtivarFaseDeslocamento();
        }
    }


    void AtivarFaseDeslocamento()
    {
        if(objetivoFinal != null)
        {
            objetivoFinal.SetActive(true);
        }
        if(textoProgresso != null)
        {
            textoProgresso.text = "Perímetro Mapeado! Vá para o objetivo final.";
        }
    }

    void UpgradeMecanica()
    {
        //Apenas para atualizar o texto na tela
    }

    void AtualizarInterface()
    {
        if (textoProgresso != null)
        {
            textoProgresso.text = $"Pistas Mentais: {pontosEncontrados} / {totalPontosPerimetro}";
        }
    }

}
