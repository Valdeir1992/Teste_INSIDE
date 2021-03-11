/*******************************************************************************
Copyright (c) 2021 INSIDE * All rights reserved. 
Programador: Valdeir Antonio do Nascimento
Data: 06/03/2021
Projeto: Teste INSIDE
*****************************************************************************/
 
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Script responsável por controlar HUDs do game.
/// </summary>
public class HudController : MonoBehaviour
{
    #region VARIAVEIS PRIVADAS

    private const int CORECAO_ANGULO_HUD = 30;

    private float _lastPotencia;

    private Image _valorPotencia;

    private Image _valorLastPotencia;

    [SerializeField] private RectTransform _marcadorDePotencia;

    [SerializeField] private RectTransform _marcadorDeAngulo;

    [SerializeField] private TMP_Text _marcadorDeTempo;

    [SerializeField] private TMP_Text _textoAngulo;

    [SerializeField] private TMP_Text _textoPontuacao;
  
    #endregion

    #region MÉTODOS UNITY
    void Awake()
    {
        _valorPotencia = _marcadorDePotencia.GetChild(1).GetComponent<Image>();

        _valorLastPotencia = _marcadorDePotencia.GetChild(0).GetComponent<Image>();
    }	 
    #endregion

    #region MÉTODOS PRÓPRIOS
    /// <summary>
    /// Método responsável por exibir potencia para o jogador.
    /// </summary>
    /// <param name="potencia">Recebe uma float que representa a potencia da jogada</param>
    public void ExibirPotencia(float potencia)
    {
        _valorPotencia.fillAmount = potencia;

        _lastPotencia = potencia;
    }
    /// <summary>
    /// Método responsável por marcar a potencia da jogada anterior.
    /// </summary>
    public void MarcarUltimaPotencia()
    {
        _valorLastPotencia.fillAmount = _lastPotencia;
    }
    /// <summary>
    /// Método responsável por marcar o tempo da partida.
    /// </summary>
    /// <param name="tempo">Recebe o tempo decorrido do game.</param>
    public void MarcarTempo(float tempo)
    {
        _marcadorDeTempo.text = $"{tempo:00.00}";
    }

    /// <summary>
    /// Método responsável por exibir o angulo selecionado pelo jogador.
    /// </summary>
    /// <param name="angulo">Recebe o angulo escolhido pelo jogador.</param>
    public void MarcarAngulo(float angulo)
    {
        _marcadorDeAngulo.rotation = Quaternion.Euler(0, 0, angulo * 1.3f - CORECAO_ANGULO_HUD);

        _textoAngulo.text = $"{angulo}º";
    }

    /// <summary>
    /// Método responsavel por exibir pontuacao do jogador.
    /// </summary>
    /// <param name="pontuacao"></param>
    public void MarcarPontuacao(int pontuacao)
    {
        _textoPontuacao.text = $"{pontuacao:00}";
    }
    #endregion
}
