using System;
using UnityEngine;

namespace __Characters.Players._Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private int maxLevel = 1;
        
        public static Player Instance;
        
        public PlayerExp PlayerExp { get; private set; }

        private void Awake()
        {
            Instance = this;
            PlayerExp = GetComponent<PlayerExp>();
        }

        private void Start()
        {
            InitExp();
        }

        private void FixedUpdate()
        {
            print(PlayerExp.CurrentExp);
            print(PlayerExp.CurrentLevel);
        }

        private void InitExp()
        {
            PlayerExp.SetMaxLevel(maxLevel);
        }
    }
}
