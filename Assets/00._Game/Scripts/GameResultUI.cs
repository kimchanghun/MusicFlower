using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MF.Game
{
    public class GameResultUI : MonoBehaviour
    {
        [SerializeField]
        Text resultText;

        [SerializeField]
        GameObject resultPanel;

        private void Start()
        {
            resultPanel.SetActive(false);
            NoteManager.Instance.gameoverEvent.AddListener(GameOver);
        }

        void GameOver(NoteManager.GameResults result)
        {
            int successCount = NoteManager.Instance.SuccessCount;
            resultPanel.SetActive(true);
            switch (result)
            {
                case NoteManager.GameResults.Condition_A:
                    resultText.text = $"음악초는 매우만족하고 있다. {successCount}개";
                    break;
                case NoteManager.GameResults.Condition_B:
                    resultText.text = $"음악초는 만족하고 있다. {successCount}개";
                    break;
                case NoteManager.GameResults.Fail:
                    resultText.text = $"음악초는 실망하고 있다. {successCount}개";
                    break;
                default:
                    break;
            }
        }
    }

}