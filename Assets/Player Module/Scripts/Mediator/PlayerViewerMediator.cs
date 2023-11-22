using Assets.Player_Module.Scripts.Health;
using Assets.Player_Module.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewerMediator : IDisposable
{
    private IPlayerHealthTaker _playerHealth;
    private IHealthViewer _healthViewer;

    public PlayerViewerMediator(IPlayerHealthTaker playerHealth, IHealthViewer floatViewer)
    {
        _playerHealth = playerHealth;
        _healthViewer = floatViewer;

        _playerHealth.HealthChanged += OnPlayerHealthChanged;
    }

    public void Dispose()
    {
        _playerHealth.HealthChanged += OnPlayerHealthChanged;
    }

    public void InitViewers()
    {
        _healthViewer.SetInitialHealthValue(_playerHealth.Health);
    }

    private void OnPlayerHealthChanged(float healthValue)
    {
        _healthViewer.OnHealthChanged(healthValue);
    }
}
