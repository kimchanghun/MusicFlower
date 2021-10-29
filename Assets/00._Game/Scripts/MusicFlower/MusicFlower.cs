using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace MF.Game
{
    public class MusicFlower : MonoBehaviour
    {

        Vector3[] waypoints = new[] {
            new Vector3(-0.9892469f, 4.498977f, 0f),
            new Vector3(-0.5503541f, 5.005903f, 0f),
            new Vector3(-1.217415f, 5.214707f, 0f),
            new Vector3(-0.4034771f, 5.97195f, 0f)
        };

        [SerializeField]
        GameObject ringPrefab;

        [SerializeField]
        GameObject skullPrefab;

        [SerializeField]
        GameObject heartPrefab;

        [SerializeField]
        Transform skullSpawnPoint;

        private void Start()
        {
            NoteManager.Instance.successEvent.AddListener(NoteSuccess);
        }

        void NoteSuccess(bool success)
        {
            if (success)
            {
                //노트 제대로 성공함.
                CreateRing();
                CreateHeart();
            }
            else
            {
                CreateSkull();
            }
        }

        void CreateRing()
        {
            GameObject ring = Instantiate(ringPrefab, transform);
            SpriteRenderer sr = ring.GetComponent<SpriteRenderer>();

            ring.transform.DOScale(1.5f, 0.5f);
            sr.DOFade(0f, 0.5f).OnComplete(() =>
            {
                Destroy(ring);
            });
        }

        void CreateSkull()
        {
            GameObject skull = Instantiate(skullPrefab, skullSpawnPoint);

            skull.transform.DOScale(0f, 0.5f).SetEase(Ease.InBack).OnComplete(() =>
            {
                Destroy(skull);
            });
        }

        void CreateHeart()
        {
            GameObject heart = Instantiate(heartPrefab, skullSpawnPoint);

            heart.transform.DOPath(waypoints, 2f, pathType: PathType.CatmullRom);

            heart.GetComponent<SpriteRenderer>().DOFade(0f, 2f).OnComplete(() =>
            {
                Destroy(heart);
            });
        }
    }
}
