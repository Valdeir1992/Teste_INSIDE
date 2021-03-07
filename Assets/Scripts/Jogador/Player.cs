/*******************************************************************************
Copyright (c) 2021 INSIDE * All rights reserved. 
Programador: Valdeir Antonio do Nascimento
Data: 05/03/2021
Projeto: Teste INSIDE
*****************************************************************************/
 
using UnityEngine;

public delegate void MarcarPotencia(float potencia);
public delegate void MarcarTempo(float tempo);
public delegate void MarcarAngulo(float angulo);
public class Player : MonoBehaviour
{
    #region VARIAVEIS PRIVADAS

    private bool _arremesso;

    private float _potencia;

    public float _angulo = 30;

    private float _time;

    private Transform _tabela;

    [SerializeField] private Bola _bola;
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
    }

    void Update()
    {
        _time += Time.deltaTime;

        if (!_arremesso)
        {   
            _potencia = Mathf.PingPong(Time.time, 1); 
        }

        marcarTempo?.Invoke(_time);

        marcarPotencia?.Invoke(_potencia); 
    } 
    #endregion

    #region MÉTODOS PRÓPRIOS
    public void Arremessar()
    {
        Vector3 vetor = new Vector3(Mathf.Cos(_angulo * Mathf.Deg2Rad), Mathf.Sin(_angulo * Mathf.Deg2Rad), 0);

        _bola.RigidBody.isKinematic = false;

        _bola.RigidBody.AddForce(transform.InverseTransformDirection(vetor).normalized * _potencia * 12, ForceMode.Impulse);

        _arremesso = true;
    }
    public void AumentarAngulo()
    {
        if (_angulo >= 90) return;
        _angulo++;
        marcarAngulo?.Invoke(_angulo);
    }
    public void DiminuirAngulo()
    {
        if (_angulo <= 30) return; 
        _angulo--; 
        marcarAngulo?.Invoke(_angulo);
    }

    private void OlharParaTabela()
    {

        Vector3 direction = (_tabela.position - transform.position).normalized;

        Quaternion lookToward = Quaternion.LookRotation(direction,transform.up);

        transform.rotation = Quaternion.Euler(0, lookToward.eulerAngles.y,0);
    }
    #endregion
}
