using Assets.Scripts.Levels.UI;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Levels
{
    public interface ILevelsFactory
    {
        public Level CreateLevel(Transform parent);
    }
}