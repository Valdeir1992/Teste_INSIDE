/*******************************************************************************
Copyright (c) 2021 INSIDE * All rights reserved. 
Programador: Valdeir Antonio do Nascimento
Data: 06/03/2021
Projeto: Teste INSIDE
*****************************************************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    #region VARIAVEIS PRIVADAS

    [SerializeField] private AudioSource _audio;

    [SerializeField] private AudioClip[] _audios;
    #endregion

    #region MÉTODOS UNITY
    private void Start()
    {
        PlayAudio(Audios.GamePlay01);
    }
    #endregion

    #region MÉTODOS PRÓPRIOS
    public void PlayAudio(Audios audio)
    {
        switch (audio)
        {
            case Audios.GamePlay01:
                _audio.clip = _audios[0];
                _audio.Play();
                break;
        }
    }
    #endregion
}
public enum Audios
{
    GamePlay01
}
