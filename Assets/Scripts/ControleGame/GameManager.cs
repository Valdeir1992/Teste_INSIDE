/*******************************************************************************
Copyright (c) 2021 INSIDE * All rights reserved. 
Programador: Valdeir Antonio do Nascimento
Data: 07/03/2021
Projeto: Teste INSIDE
*****************************************************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void MarcarTempo(float tempo); 
public class GameManager : MonoBehaviour
{
    #region VARIAVEIS PRIVADAS

    private List<Bola> _bolasEmGame;

    private float _tempo; 

    [SerializeField] private Tabela _tabela;

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
    void Update()
    {
        _tempo += Time.deltaTime;

        marcarTempo?.Invoke(_tempo);  
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

    public void MoverPersonagem(Vector3 center, float raio)
    {
        float angulo = Random.Range(90, 270);

        _jogador.transform.position = new Vector3(center.x + raio * Mathf.Cos(angulo * Mathf.Deg2Rad),
                                         _jogador.transform.position.y,
                                         center.z + raio * Mathf.Sin(angulo * Mathf.Deg2Rad));
        _jogador.OlharParaTabela();
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
