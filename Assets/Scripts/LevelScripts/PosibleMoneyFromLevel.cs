using UnityEngine;

namespace LevelScripts
{
    public class PosibleMoneyFromLevel : MonoBehaviour
    {
        public int moneyFromLvl;
        public static PosibleMoneyFromLevel Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        public void AddMoney(int money)
        {
            moneyFromLvl += money;
        }

        public void OnGameWin()
        {
            PlayerProgress.PlayerProgress.Instance.AddMoney(moneyFromLvl);
        }
    }
}
