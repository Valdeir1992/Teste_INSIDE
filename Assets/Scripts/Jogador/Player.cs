/*******************************************************************************
Copyright (c) 2021 INSIDE * All rights reserved. 
Programador: Valdeir Antonio do Nascimento
Data: 05/03/2021
Projeto: Teste INSIDE
*****************************************************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region VARIAVEIS PRIVADAS

    [SerializeField] private float _time;

    [SerializeField] private Bola _bola;
    #endregion

    #region MÉTODOS UNITY
     
    void Update()
    {
        _time = Mathf.PingPong(Time.time, 3)/3;
    } 
    #endregion

    #region MÉTODOS PRÓPRIOS
    public void Arremessar()
    {
        _bola.Arremessar(_time * 20, new Vector3(0.3f, 1, 0));
    }
    #endregion
}
