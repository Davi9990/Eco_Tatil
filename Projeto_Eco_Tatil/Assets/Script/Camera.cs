using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform alvo;

    public float suavidade = 5f;
    public Vector3 deslocamento = new Vector3(0f, 0f, -10f);


    private void LateUpdate()
    {
        if (alvo != null)
        {
            //Calcula a posição para onde a câmera deve ir
            Vector3 posicaoDesejada = alvo.position + deslocamento;

            //Faz a transição suave entre a posição atual da câmera e a posição do jogador
            Vector3 posicaoSuave = Vector3.Lerp(transform.position, posicaoDesejada, suavidade * Time.deltaTime);

            //Atualiza a posição da câmera
            transform.position = posicaoSuave;
        }
    }
}
