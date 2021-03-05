/*******************************************************************************
Copyright (c) 2021 INSIDE * All rights reserved. 
Programador: Valdeir Antonio do Nascimento
Data: 05/03/2021
Projeto: Teste INSIDE
*****************************************************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Prototipo/Data/Bola")]
public class BolaData : ScriptableObject
{
    #region VARIAVEIS PRIVADAS

    [SerializeField] private float _peso;

    [SerializeField] private float _aeroDinamica;

    [SerializeField] private PhysicMaterial _materialBola;
    #endregion

    #region PROPRIEDADES

    public float Peso { get => _peso; }
    public float AeroDinamica { get => _aeroDinamica; } 
    public PhysicMaterial MaterialBola { get => _materialBola; }
    #endregion 
}
