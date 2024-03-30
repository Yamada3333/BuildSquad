using System;
using BuildSquad.Scripts.Presenter.Interface;
using R3;
using UnityEngine;

namespace BuildSquad.Scripts.View.Implement.Object
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class GroupObject : MonoBehaviour, IGroupObject
    {
        public int layer;
        
        public void Initialize(int setLayer)
        {
            layer = setLayer;
            gameObject.layer = layer;
        }
        
        public void OnTriggerEnter2D(Collider2D other)
        {
            // レイヤーを取得
            var target = other.gameObject.GetComponent<GroupObject>();
            // レイヤーがこのオブジェクトと同じかチェック
            if (layer == target.layer)
            {
                // このオブジェクトを消す
                Destroy(gameObject);
            }
        }
    }
}
