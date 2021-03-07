/*******************************************************************************
Copyright (c) 2021 INSIDE * All rights reserved. 
Programador: Valdeir Antonio do Nascimento
Data: 06/03/2021
Projeto: Teste INSIDE
*****************************************************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void MarcarPontuacao(int pontuacao);
public class Tabela : MonoBehaviour
{
    #region VARIAVEIS PRIVADAS

    private int _pontuacao;

    private AudioSource _audio;
    #endregion

    public int Pontuacao { get => _pontuacao; }

    private event MarcarPontuacao marcarPontuacao;
    #region MÉTODOS UNITY
    void Awake()
    {
        _audio = GetComponent<AudioSource>();

        marcarPontuacao += FindObjectOfType<HudController>().MarcarPontuacao;
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

    public void Pontuar()
    {
        _pontuacao++;
        marcarPontuacao?.Invoke(_pontuacao);
    }
}
