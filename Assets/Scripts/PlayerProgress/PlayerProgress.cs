using UnityEngine;

namespace PlayerProgress
{
    public class PlayerProgress : MonoBehaviour
    {
        // how to save in and out of game


        public int currentMaxTargets;
        public int currentMaxRedirect;
        public int currentMaxForceMultiplier;

        private int currentMoneyCount;
        
        
        public static PlayerProgress Instance { get; private set; }

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

        public void AddMoney(int value)
        {
            currentMoneyCount += value;
        }
    }
}
