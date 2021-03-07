/*******************************************************************************
Copyright (c) 2021 INSIDE * All rights reserved. 
Programador: Valdeir Antonio do Nascimento
Data: 07/03/2021
Projeto: Teste INSIDE
*****************************************************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region VARIAVEIS PRIVADAS
    private List<Bola> _bolasEmGame;
    private float _tempo;
    [SerializeField] private Player _jogador;
    [SerializeField] private GameObject _prefabBola;
    #endregion

    private MarcarTempo marcarTempo;

    #region MÉTODOS UNITY
    void Awake()
    {
        marcarTempo += FindObjectOfType<HudController>().MarcarTempo;
    }	
    void Start()
    {
        GerarBolas();

        StartCoroutine(DarBola());

        _jogador.PegarBola(GetBola());
    }
    private void OnEnable()
    {
       
    } 
    void Update()
    {
        _tempo += Time.deltaTime;

        marcarTempo?.Invoke(_tempo);
    }
    private void OnDisable()
    {
        
    }
    #endregion

    #region MÉTODOS PRÓPRIOS

    private void GerarBolas()
    {
        _bolasEmGame = new List<Bola>(); 

        while(_bolasEmGame.Count < 5)
        {
            Bola bola = Instantiate(_prefabBola).GetComponent<Bola>();

            bola.gameObject.SetActive(false);

            _bolasEmGame.Add(bola);
        }
    }
    private Bola GetBola()
    {
        Bola bolaSelecionada = null;

        foreach (Bola bola in _bolasEmGame)
        {
            if (!bola.gameObject.activeSelf)
            {
                bolaSelecionada = bola;
                break;
            }
        }
        if(bolaSelecionada == null)
        {
            bolaSelecionada = Instantiate(_prefabBola).GetComponent<Bola>();

            _bolasEmGame.Add(bolaSelecionada);
        }
        bolaSelecionada.gameObject.SetActive(true);

        return bolaSelecionada;
    }
 
    #endregion

    private IEnumerator DarBola()
    {
        float timeElapsed = 0;
        while (true)
        {
            while (_jogador.SemBola)
            {
                timeElapsed += Time.deltaTime;
                if(timeElapsed > 1)
                {
                    _jogador.PegarBola(GetBola());
                    timeElapsed = 0;
                }
                yield return null;
            }
            yield return null;
        }
    }
}
