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
                    resultText.text = $"�����ʴ� �ſ츸���ϰ� �ִ�. {successCount}��";
                    break;
                case NoteManager.GameResults.Condition_B:
                    resultText.text = $"�����ʴ� �����ϰ� �ִ�. {successCount}��";
                    break;
                case NoteManager.GameResults.Fail:
                    resultText.text = $"�����ʴ� �Ǹ��ϰ� �ִ�. {successCount}��";
                    break;
                default:
                    break;
            }
        }
    }

}