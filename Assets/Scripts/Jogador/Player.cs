/*******************************************************************************
Copyright (c) 2021 INSIDE * All rights reserved. 
Programador: Valdeir Antonio do Nascimento
Data: 05/03/2021
Projeto: Teste INSIDE
*****************************************************************************/

using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public delegate void MarcarPotencia(float potencia);
public delegate void MarcarTempo(float tempo);
public delegate void MarcarAngulo(float angulo);
public class Player : MonoBehaviour
{
    #region VARIAVEIS PRIVADAS

    private bool _podeArremessar = true;

    private float _potencia;

    public float _angulo = 30;

    private float _time;

    private Transform _tabela;

    private Bola _bola;

    [SerializeField] private Bola _prefabBola;

    [SerializeField] private Transform _mao;
    #endregion

    private event MarcarPotencia marcarPotencia;

    private event MarcarTempo marcarTempo;

    private event MarcarAngulo marcarAngulo;

    #region MÉTODOS UNITY
    private void Awake()
    {
        marcarPotencia += FindObjectOfType<HudController>().ExibirPotencia;

        marcarTempo += FindObjectOfType<HudController>().MarcarTempo;

        marcarAngulo += FindObjectOfType<HudController>().MarcarAngulo;

        _tabela = FindObjectOfType<Tabela>().transform;
    }

    private void Start()
    {
        marcarAngulo?.Invoke(_angulo);

        OlharParaTabela();

        StartCoroutine(_pegarBola());

        _bola = Instantiate(_prefabBola, _mao, false);
    } 
    #endregion

    #region MÉTODOS PRÓPRIOS
    public void Arremessar(InputAction.CallbackContext ctx)
    {
        if (_bola == null || !ctx.performed) return;

        Vector3 vetor = new Vector3(Mathf.Cos(_angulo * Mathf.Deg2Rad), Mathf.Sin(_angulo * Mathf.Deg2Rad), 0); 

        _bola.RigidBody.isKinematic = false;

        _bola.RigidBody.AddForce(new Vector3(transform.forward.x * vetor.x,vetor.y,transform.forward.z * vetor.x) * _potencia * 40, ForceMode.Impulse);

        _bola = null;

        _podeArremessar = false;

        _mao.GetChild(0).SetParent(null);
    }
    public void AumentarAngulo(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;

        if (_angulo >= 90) return;

        _angulo++;

        marcarAngulo?.Invoke(_angulo);
    }
    public void DiminuirAngulo(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;

        if (_angulo <= 30) return; 

        _angulo--; 

        marcarAngulo?.Invoke(_angulo);
    }

    private void OlharParaTabela()
    {

        Vector3 direction = (_tabela.position - transform.position);

        Quaternion lookToward = Quaternion.LookRotation(direction,transform.up);

        transform.rotation = Quaternion.Euler(0, lookToward.eulerAngles.y,0);
    }
    #endregion

    private IEnumerator _pegarBola()
    {
        float timeElapsed = 0;

        while (true)
        {
            while (!_podeArremessar)
            {
                timeElapsed += Time.deltaTime;
                if (timeElapsed > 1)
                {
                    _podeArremessar = true;

                    _bola = Instantiate(_prefabBola, _mao, false); 

                    timeElapsed = 0;
                }
                yield return null; 
            }
            _potencia = Mathf.PingPong(Time.time, 1);

            _time += Time.deltaTime;

            marcarTempo?.Invoke(_time);

            marcarPotencia?.Invoke(_potencia);

            yield return null;
        }
    }
}
