/*******************************************************************************
Copyright (c) 2021 INSIDE * All rights reserved. 
Programador: Valdeir Antonio do Nascimento
Data: 06/03/2021
Projeto: Teste INSIDE
*****************************************************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tabela : MonoBehaviour
{
    #region VARIAVEIS PRIVADAS

    private AudioSource _audio;
    #endregion

    #region MÉTODOS UNITY
    void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        _audio.Play();
    }
    #endregion 
}
