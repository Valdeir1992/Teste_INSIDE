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
using TMPro;

public class HudController : MonoBehaviour
{
    #region VARIAVEIS PRIVADAS

    private Image _valorPotencia;

    [SerializeField] private RectTransform _marcadorDePotencia;

    [SerializeField] private TMP_Text _marcadorDeTempo;
  
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

    public void MarcarTempo(float tempo)
    {
        _marcadorDeTempo.text = $"{tempo:00.00}";
    }
    #endregion
}
