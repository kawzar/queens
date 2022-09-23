using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardViewModel : MonoBehaviour, IPointerMoveHandler, IPointerUpHandler, IPointerDownHandler
{
   [SerializeField] private Image characterImage;
   [SerializeField] private TextMeshProUGUI text;
   [SerializeField] private float animationPositionThreshold = 20f;
   [SerializeField] private float animationRotationModule = 3.75f;
   [SerializeField] private float animationScale = 1.5f;

   private bool _isDragging = false;
   private Vector3 _initialScale;
   private Vector3 _initialPosition;
   
   
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
      transform.SetPositionAndRotation(_initialPosition, Quaternion.identity);
      transform.DOMove(_initialPosition, 0.25f);
      transform.DORotate(Vector3.zero, 0.25f);
      transform.DOScale(_initialScale, 0.25f);
      _isDragging = false;
   }

   public void OnPointerDown(PointerEventData eventData)
   {
      _isDragging = true;
      _initialPosition = transform.position;
      _initialScale = transform.localScale;
      transform.DOScale(_initialScale * animationScale, 0.25f);
   }
}
