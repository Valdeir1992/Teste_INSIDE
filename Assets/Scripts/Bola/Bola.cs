/*******************************************************************************
Copyright (c) 2021 INSIDE * All rights reserved. 
Programador: Valdeir Antonio do Nascimento
Data: 05/03/2021
Projeto: Teste INSIDE
*****************************************************************************/

 
using UnityEngine;

[RequireComponent(typeof(SphereCollider),typeof(AudioSource))]
public abstract class Bola : MonoBehaviour
{
    #region VARIAVEIS PRIVADAS

    private Rigidbody _rigidBody;

    private AudioSource _audio;

    [SerializeField] protected BolaData _data;
    #endregion

    public Rigidbody RigidBody
    {
        get
        {
            return _rigidBody;
        }
    }
    #region MÉTODOS UNITY
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();

        _audio = GetComponent<AudioSource>();

        _rigidBody.isKinematic = true;
    }	
    public virtual void Start()
    {
        SetupBola();
    }
    private void OnCollisionEnter()
    {
        _audio.Play();
    }
    #endregion

    #region MÉTODOS PRÓPRIOS

    public virtual void SetupBola()
    {
        SphereCollider _mesh = GetComponent<SphereCollider>();

        _rigidBody.mass = _data.Peso; 

        _mesh.material = _data.MaterialBola;
    } 
    #endregion
}
