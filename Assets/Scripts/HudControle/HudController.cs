/*******************************************************************************
Copyright (c) 2021 INSIDE * All rights reserved. 
Programador: Valdeir Antonio do Nascimento
Data: 06/03/2021
Projeto: Teste INSIDE
*****************************************************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    #region VARIAVEIS PRIVADAS

    private Image _valorPotencia;

    [SerializeField] private RectTransform _marcadorDePotencia;
  
    #endregion

    #region MÉTODOS UNITY
    void Awake()
    {
        _valorPotencia = _marcadorDePotencia.GetChild(0).GetComponent<Image>();
    }	
    void Start()
    {
        
    }
    private void OnEnable()
    {
       
    } 
    void Update()
    {

    }
    private void OnDisable()
    {
        
    }
    #endregion

    #region MÉTODOS PRÓPRIOS
    public void ExibirPotencia(float potencia)
    {
        _valorPotencia.fillAmount = potencia;
    }
    #endregion
}
