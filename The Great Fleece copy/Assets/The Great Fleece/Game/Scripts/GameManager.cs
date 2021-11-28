﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("GameManager is null!");
            }
            return _instance;

        }
    }

    public bool HasCard { get; set; }
    public PlayableDirector introCutScene;

    private void Awake()
    {
        _instance = this;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            introCutScene.time = 60.0f;
            AudioManager.Instance.PlayMusic();
        }
    }
}
