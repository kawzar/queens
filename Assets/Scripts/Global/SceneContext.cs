using Kawzar.Queens.Model;
using Kawzar.Queens.Presenter;
using Kawzar.Queens.View;
using Model;
using UnityEngine;

namespace Kawzar.Queens.Global
{
    public class SceneContext : MonoBehaviour
    {
        [SerializeField] private CardView _cardViewPrefab;
        [SerializeField] private StatsView _statsView;

        [SerializeField] private StatsModel _statsModel;

        [SerializeField] private CardService _cardService;

        [SerializeField] private LevelView _levelView;
        [SerializeField] private LevelModel _levelModel;

        [SerializeField] private Canvas _mainCanvas;
        
        private StatsPresenter _statsPresenter;
        private LevelPresenter _levelPresenter;
        
        public CardService CardService => _cardService;
        public StatsPresenter StatsPresenter => _statsPresenter;
        public CardView CardViewPrefab => _cardViewPrefab;
        public Canvas MainCanvas => _mainCanvas;
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
            _statsPresenter = new StatsPresenter(_statsModel, _statsView);
            _levelPresenter = new LevelPresenter(_levelView, _levelModel, _cardService);
        }
    }
}