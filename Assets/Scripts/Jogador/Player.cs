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
public delegate void MarcarAngulo(float angulo);
public delegate void ArremesoAnterior();
public class Player : MonoBehaviour
{
    #region VARIAVEIS PRIVADAS 

    private float _potencia;

    private float _time;

    public float _angulo = 60; 

    private Transform _tabela;

    private Bola _bola;

    private bool _semBola;

    [SerializeField] private Transform _mao;
    #endregion

    public bool SemBola { get => _semBola; }

    private event MarcarPotencia marcarPotencia;

    private event MarcarTempo marcarTempo;

    private event MarcarAngulo marcarAngulo;

    private event ArremesoAnterior anterior;

    #region MÉTODOS UNITY
    private void Awake()
    {
        marcarPotencia += FindObjectOfType<HudController>().ExibirPotencia;

        marcarTempo += FindObjectOfType<HudController>().MarcarTempo;

        marcarAngulo += FindObjectOfType<HudController>().MarcarAngulo;

        _tabela = FindObjectOfType<Tabela>().transform;

        anterior += FindObjectOfType<HudController>().MarcarUltimaPotencia;
    }

    private void Start()
    {
        marcarAngulo?.Invoke(_angulo);

        OlharParaTabela();

        StartCoroutine(gerarPontencia()); 
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

        _semBola = true;

        _mao.GetChild(0).SetParent(null);

        anterior?.Invoke();
    }
    public void AumentarAngulo(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;

        if (_angulo >= 90) return;

        _angulo++;

        marcarAngulo?.Invoke(_angulo);
    }
    public void AumentarAnguloMaior(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;

        if (_angulo >= 80) return;

        _angulo+=10;

        marcarAngulo?.Invoke(_angulo);
    }
    public void DiminuirAngulo(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;

        if (_angulo <= 30) return; 

        _angulo--; 

        marcarAngulo?.Invoke(_angulo);
    }
    public void DiminuirAnguloMaior(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;

        if (_angulo <= 40) return;

        _angulo -= 10;

        marcarAngulo?.Invoke(_angulo);
    } 
    public void OlharParaTabela()
    {

        Vector3 direction = (_tabela.position - transform.position);

        Quaternion lookToward = Quaternion.LookRotation(direction,transform.up);

        transform.rotation = Quaternion.Euler(0, lookToward.eulerAngles.y,0);
    } 
    public void PegarBola(Bola bola)
    {
        _bola = bola;

        _bola.transform.SetParent(_mao,false);

        _bola.transform.localPosition = Vector3.zero;

        _semBola = false;
    }
    #endregion

    private IEnumerator gerarPontencia()
    {  
        while (true)
        {
             
            _potencia = Mathf.PingPong(Time.time/2, 1);

            _time += Time.deltaTime; 

            marcarPotencia?.Invoke(_potencia);

            yield return null;
        }
    }
}
