/*******************************************************************************
Copyright (c) 2021 INSIDE * All rights reserved. 
Programador: Valdeir Antonio do Nascimento
Data: 05/03/2021
Projeto: Teste INSIDE
*****************************************************************************/


using System.Collections;
using UnityEngine;
/// <summary>
/// Script base para criação de bolas no game.
/// </summary>
[RequireComponent(typeof(SphereCollider),typeof(AudioSource))]
public abstract class Bola : MonoBehaviour
{
    #region VARIAVEIS PRIVADAS

    private Rigidbody _rigidBody;

    private AudioSource _audio;

    [SerializeField] protected BolaData _data;
    #endregion

    #region PROPRIEDADES 

    public Rigidbody RigidBody
    {
        get
        {
            StartCoroutine(DesativarBola());
            return _rigidBody;
        }
    }
    #endregion 

    #region MÉTODOS UNITY

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();

        _audio = GetComponent<AudioSource>();

        _rigidBody.isKinematic = true;
    }
    public void OnEnable()
    {
        SetupBola();
    }
    private void OnCollisionEnter()
    {
        _audio.Play();
    }
    #endregion

    #region MÉTODOS PRÓPRIOS

    /// <summary>
    /// Método responsável por estabelecer as configurações da bola.
    /// </summary>
    public virtual void SetupBola()
    {
        SphereCollider _mesh = GetComponent<SphereCollider>();

        _rigidBody.mass = _data.Peso; 

        _mesh.material = _data.MaterialBola;

        _rigidBody.isKinematic = true;
    }
    #endregion

    #region ROTINAS

    /// <summary>
    /// Rotina responsável por desativar bola após ser lançada.
    /// </summary>
    /// <returns></returns>
    private IEnumerator DesativarBola()
    {
        yield return new WaitForSeconds(5);

        gameObject.SetActive(false);
    }
    #endregion
}
