using System.Collections;
using UnityEngine;
using static CookingEnums;

namespace Assets._game.script.Feature.cooking.domain.Egg
{
	public class EggEntity
	{
        public EggState CurrentState { get; private set; }
        public EggConfig Config { get; private set; }

        public EggEntity(EggConfig config)
        {
            Config = config;
            CurrentState = EggState.InBasket;
        }

        public void ChangeState(EggState newState)
        {
            CurrentState = newState;
        }
    }
}