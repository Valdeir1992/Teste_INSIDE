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
        
        _bola.Arremessar(_potencia * 15, vetor);

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
        if (_angulo <= 0) return; 
        _angulo--; 
        marcarAngulo?.Invoke(_angulo);
    }

    private void OlharParaTabela()
    {
        Vector2 tabela = new Vector2(_tabela.position.x,_tabela.position.z);

        Vector2 direction = tabela - new Vector2(transform.position.x, transform.position.z);

        direction = direction.normalized; 

        transform.Rotate(Vector3.up, Vector2.Angle(new Vector2(transform.right.x, transform.right.z), direction));  
    }
    #endregion
}
