﻿namespace Assets.Code.GameLogic
{
    using MonoBehaviours.Configuration;
    using Common;
    using Common.DataAccess;
    using IoC;

    public class ScoreLogic : LogicBase
    {
        public int CurrentScore { get; private set; }

        public ScoreLogic(IUnityContainer container, PrefabManager prefabManager, GlobalConfiguration config) : base(container, prefabManager, config)
        {
            CurrentScore = 0;
        }

        public void AddToScore(int toAdd)
        {
            CurrentScore += toAdd;
        }
    }
}
