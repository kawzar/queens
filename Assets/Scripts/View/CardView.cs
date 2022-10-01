using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Kawzar.Queens.View
{

   public class CardView : MonoBehaviour, IPointerMoveHandler, IPointerUpHandler, IPointerDownHandler
   {
      [SerializeField] private Image characterImage;
      [SerializeField] private TextMeshProUGUI text;
      [SerializeField] private float animationPositionThreshold = 20f;
      [SerializeField] private float animationRotationModule = 3.75f;
      [SerializeField] private float animationScale = 1.5f;
      [SerializeField] private float spawnAnimationEndValue = 255f;
      [SerializeField] private float spawnAnimationDuration = 1.25f;
      [SerializeField] private float swipeAnimationEndValue = 255f;
      [SerializeField] private float swipeAnimationDuration = 0.75f;

      private bool _isDragging = false;
      private Vector3 _initialScale;

      public event Action SwipeLeft;
      public event Action SwipeRight;

      public void Initialize(Sprite sprite, string text)
      {
         characterImage.sprite = sprite;
         this.text.SetText(text);
         transform.position = new Vector3(transform.position.x, 0, transform.position.z);
      }

      private void OnEnable()
      {
         transform.DOMoveY(spawnAnimationEndValue, spawnAnimationDuration)
            .SetEase(Ease.InBounce);
      }

      public void OnPointerMove(PointerEventData eventData)
      {
         if (_isDragging)
         {
            float xMovement = transform.position.x + eventData.delta.x;
            if (xMovement < transform.position.x + animationPositionThreshold &&
                xMovement > transform.position.x - animationPositionThreshold)
            {
               transform.DOMove(new Vector3(xMovement, transform.position.y, transform.position.z), 0.25f);
               transform.DORotate(new Vector3(transform.rotation.x, transform.rotation.y,
                  eventData.delta.x < 0 ? animationRotationModule : -animationRotationModule), 0.25f);
            }
         }
      }

      public void OnPointerUp(PointerEventData eventData)
      {
         float xMovement = transform.position.x + eventData.delta.x;
         if (xMovement >= transform.position.x + animationPositionThreshold)
         {
            SwipeRight?.Invoke();
            transform.DOMoveX(transform.position.x + swipeAnimationEndValue, swipeAnimationDuration)
               .SetEase(Ease.OutCubic)
               .OnComplete(() => Destroy(gameObject));
         }
         else if (xMovement <= transform.position.x - animationPositionThreshold)
         {
            SwipeLeft?.Invoke();
            transform.DOMoveX(transform.position.x - swipeAnimationEndValue, swipeAnimationDuration)
               .SetEase(Ease.OutCubic)
               .OnComplete(() => Destroy(gameObject));
         }
         
         _isDragging = false;
         transform.DOScale(_initialScale, 0.25f);
      }

      public void OnPointerDown(PointerEventData eventData)
      {
         _isDragging = true;
         _initialScale = transform.localScale;
         transform.DOScale(_initialScale * animationScale, 0.25f);
      }
   }
}