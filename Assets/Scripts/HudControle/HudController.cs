/*******************************************************************************
Copyright (c) 2021 INSIDE * All rights reserved. 
Programador: Valdeir Antonio do Nascimento
Data: 06/03/2021
Projeto: Teste INSIDE
*****************************************************************************/
 
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudController : MonoBehaviour
{
    #region VARIAVEIS PRIVADAS

    private const int CORECAO_ANGULO_HUD = 30;

    private Image _valorPotencia;

    [SerializeField] private RectTransform _marcadorDePotencia;

    [SerializeField] private RectTransform _marcadorDeAngulo;

    [SerializeField] private TMP_Text _marcadorDeTempo;

    [SerializeField] private TMP_Text _textoAngulo;

    [SerializeField] private TMP_Text _textoPontuacao;
  
    #endregion

    #region MÉTODOS UNITY
    void Awake()
    {
        _valorPotencia = _marcadorDePotencia.GetChild(0).GetComponent<Image>();
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

    public void MarcarAngulo(float angulo)
    {
        _marcadorDeAngulo.rotation = Quaternion.Euler(0, 0, angulo * 1.3f - CORECAO_ANGULO_HUD);

        _textoAngulo.text = $"{angulo}º";
    }

    public void MarcarPontuacao(int pontuacao)
    {
        _textoPontuacao.text = $"{pontuacao:00}";
    }
    #endregion
}
