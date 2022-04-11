using TMPro;
using UnityEngine;

namespace Game
{
    public class StatsManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText, comboText;

        private int _score, _combo;
    }
}
