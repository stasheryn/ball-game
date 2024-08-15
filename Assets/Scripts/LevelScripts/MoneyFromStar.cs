using System;
using UnityEngine;

namespace LevelScripts
{
    public class MoneyFromStar : MonoBehaviour
    {
        public int moneyFromHit;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                //add money
                PosibleMoneyFromLevel.Instance.AddMoney(moneyFromHit);
                Destroy(gameObject);
            }
        }
    }
}
