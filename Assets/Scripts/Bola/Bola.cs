/*******************************************************************************
Copyright (c) 2021 INSIDE * All rights reserved. 
Programador: Valdeir Antonio do Nascimento
Data: 05/03/2021
Projeto: Teste INSIDE
*****************************************************************************/

 
using UnityEngine;

[CreateAssetMenu(menuName ="Prototipo/Data/Bola")]
public abstract class Bola : MonoBehaviour
{
    #region VARIAVEIS PRIVADAS

    private Rigidbody _rigidBody;

    [SerializeField] protected BolaData _data;
    #endregion

    #region MÉTODOS UNITY
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.isKinematic = true;
    }	
    public virtual void Start()
    {
        SetupBola();
    }  
    #endregion

    #region MÉTODOS PRÓPRIOS
    
    public virtual void SetupBola()
    {
        SphereCollider _mesh = GetComponent<SphereCollider>();

        _rigidBody.mass = _data.Peso; 

        _mesh.material = _data.MaterialBola;
    }

    public void Arremessar(float forca, Vector3 direction)
    {
        _rigidBody.isKinematic = false;

        _rigidBody.AddForce(direction * forca, ForceMode.Impulse);
    }
    #endregion
}
