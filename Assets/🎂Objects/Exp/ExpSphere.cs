using __Characters.Players._Scripts;
using __Objects.Interfaces;
using UnityEngine;

namespace __Objects.Exp
{
    public class ExpSphere : MonoBehaviour, ICollectable
    {
        public double ExpAmount { get; private set; }
        
        public void SetExpAmount(double amount)
        {
            ExpAmount = amount;
        }

        public void Collect(GameObject collector)
        {
            if (!collector.GetComponent<PlayerExp>()) return;

            Player.Instance.PlayerExp.AddExp(ExpAmount);
            Destroy(gameObject);
        }
    }
}