/*******************************************************************************
Copyright (c) 2021 INSIDE * All rights reserved. 
Programador: Valdeir Antonio do Nascimento
Data: 06/03/2021
Projeto: Teste INSIDE
*****************************************************************************/
 

using UnityEngine;


public delegate void MarcarPontuacao(int pontuacao);

public delegate void MoverPersonagem(Vector3 posicao, float raio);

/// <summary>
/// Script responsável por gerenciar tabela de basketball
/// </summary>
public class Tabela : MonoBehaviour
{
    #region VARIAVEIS PRIVADAS

    private int _pontuacao;

    private AudioSource _audio;
    #endregion

    #region PROPERTIE 

    public int Pontuacao { get => _pontuacao; }
    #endregion

    #region EVENTS

    private event MarcarPontuacao marcarPontuacao;

    private event MoverPersonagem movePersonagem;
    #endregion

    #region MÉTODOS UNITY
    void Awake()
    {
        _audio = GetComponent<AudioSource>();

        marcarPontuacao += FindObjectOfType<HudController>().MarcarPontuacao;

        movePersonagem += FindObjectOfType<GameManager>().MoverPersonagem;
    }
    private void Start()
    {
        movePersonagem?.Invoke(transform.position, 6.25f);
    }
    private void OnCollisionEnter()
    {
        _audio.Play();
    }

    private void OnTriggerEnter()
    {
        Pontuar();
    }
    #endregion

    #region MÉTODOS PRÓPRIOS

    /// <summary>
    /// Método responsavel por marcar ponto na partida.
    /// </summary>
    public void Pontuar()
    {
        _pontuacao++;

        marcarPontuacao?.Invoke(_pontuacao); 

        movePersonagem?.Invoke(transform.position, (int)Random.Range(4, 6.25f));
    }
    #endregion
}
