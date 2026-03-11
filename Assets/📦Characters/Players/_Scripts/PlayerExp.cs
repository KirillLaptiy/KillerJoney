using UnityEngine;

namespace __Characters.Players._Scripts
{
    public class PlayerExp : MonoBehaviour
    {
        public double CurrentExp { get; private set; }
        public int CurrentLevel { get; private set; }
        public int MaxLevel { get; private set; }

        private double _remainExpForLvl;

        public void SetMaxLevel(int level)
        {
            MaxLevel = level;
        }

        public void AddExp(double exp)
        {
            if (CurrentLevel == MaxLevel) return;

            CurrentExp += exp;

            if (CurrentExp <= _remainExpForLvl) return;

            AddLevel(1);
        }

        private void AddLevel(int levels)
        {
            if (CurrentLevel == MaxLevel) return;
            CurrentLevel++;
            _remainExpForLvl = CurrentExp + 50 * CurrentLevel;
            
            // Update
            AddExp(0);
        }
    }
}