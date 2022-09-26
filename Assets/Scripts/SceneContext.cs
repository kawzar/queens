using System;
using System.Collections;
using System.Collections.Generic;
using Kawzar.Queens.Model;
using Kawzar.Queens.Presenter;
using Kawzar.Queens.View;
using Model;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneContext : MonoBehaviour
{
    [SerializeField] private CardView _cardView;
    [SerializeField] private StatsView _statsView;

    [SerializeField] private CardModel _cardModel;
    [SerializeField] private StatsModel _statsModel;

    private CardPresenter _cardPresenter;
    private StatsPresenter _statsPresenter;

    public CardPresenter CardPresenter => _cardPresenter;
    public StatsPresenter StatsPresenter => _statsPresenter;

    public static SceneContext Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        _cardPresenter = new CardPresenter(_cardModel, _cardView);
        _statsPresenter = new StatsPresenter(_statsModel, _statsView);
    }
}
