/*******************************************************************************
Copyright (c) 2021 INSIDE * All rights reserved. 
Programador: Valdeir Antonio do Nascimento
Data: 05/03/2021
Projeto: Teste INSIDE
*****************************************************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void MarcarPotencia(float potencia);
public delegate void MarcarTempo(float tempo);
public class Player : MonoBehaviour
{
    #region VARIAVEIS PRIVADAS

    private bool _arremesso;

    private float _potencia;

    private float _time;

    [SerializeField] private Bola _bola;
    #endregion

    private event MarcarPotencia marcarPotencia;

    private event MarcarTempo marcarTempo;

    #region MÉTODOS UNITY
    private void Awake()
    {
        marcarPotencia += FindObjectOfType<HudController>().ExibirPotencia;

        marcarTempo += FindObjectOfType<HudController>().MarcarTempo;
    }

    void Update()
    {
        _time += Time.deltaTime;

        if (!_arremesso)
        {   
            _potencia = Mathf.PingPong(Time.time, 1); 
        }

        marcarTempo?.Invoke(_time);

        marcarPotencia?.Invoke(_potencia);
    } 
    #endregion

    #region MÉTODOS PRÓPRIOS
    public void Arremessar()
    {
        _bola.Arremessar(_potencia * _potencia * 20, new Vector3(0.3f, 1, 0));

        _arremesso = true;
    }
    #endregion
}
