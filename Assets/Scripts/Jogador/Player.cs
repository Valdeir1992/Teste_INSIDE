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
public class Player : MonoBehaviour
{
    #region VARIAVEIS PRIVADAS

    private bool _arremesso;

    [SerializeField] private float _time;

    [SerializeField] private Bola _bola;
    #endregion

    private event MarcarPotencia marcarPotencia;

    #region MÉTODOS UNITY
    private void Awake()
    {
        marcarPotencia += FindObjectOfType<HudController>().ExibirPotencia;
    }

    void Update()
    {
        if (!_arremesso)
        {   
            _time = Mathf.PingPong(Time.time, 1); 
        } 

        marcarPotencia?.Invoke(_time);
    } 
    #endregion

    #region MÉTODOS PRÓPRIOS
    public void Arremessar()
    {
        _bola.Arremessar(_time * 15, new Vector3(0.3f, 1, 0));

        _arremesso = true;
    }
    #endregion
}
