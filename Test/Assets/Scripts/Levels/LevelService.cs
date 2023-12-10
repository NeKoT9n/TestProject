using Assets.Scripts.AssetManagment;
using Assets.Scripts.Data;
using Assets.Scripts.Levels.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Levels
{
    public class LevelService : MonoBehaviour, Scripts.UI.Windows.IInitializable, IDisposable
    {
        [SerializeField] private Transform _parent;
        private List<Level> _levels;
        private int _currentLevelIndex = 0;
        private int _levelsCount = 20;

        private ILevelsFactory _levelsFactory;
        private IUserDataContainer _dataContainer;

        [Inject]
        public void Construct(ILevelsFactory levelsFactory, IUserDataContainer dataContainer)
        {
            _levelsFactory = levelsFactory; 
            _dataContainer = dataContainer;
        }

        public void Initialize()
        {
            _currentLevelIndex = _dataContainer.LevelsData.CurrentLevelIndex;
            _levels = new List<Level>(_levelsCount);

            for (int i = 0; i < _levelsCount; i++)
            {
                Level level = _levelsFactory.CreateLevel(_parent);
                level.Initialize();
                level.Complited += TryOpenNextLevel;
                level.SetOpen(i < _currentLevelIndex);
                _levels.Add(level);
            }

        }

        public void TryOpenNextLevel(Level level)
        {
            if(_levels.Contains(level) == false)
            {
                return;
            }

            int index = _levels.LastIndexOf(level) + 1;
            Level nextLevel = _levels[index];

            if(nextLevel == null)
            {
                return;
            }

            if(nextLevel.IsOpen == false)
            {
                nextLevel.SetOpen(true);
                _dataContainer.LevelsData.CurrentLevelIndex = index;
            }

        }

        public void Dispose()
        {
            foreach (var level in _levels)
            {
                level.Complited -= TryOpenNextLevel;
            }
        }



    }
}