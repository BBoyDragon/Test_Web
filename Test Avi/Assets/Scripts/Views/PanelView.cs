using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class PanelView : MonoBehaviour
{
   [SerializeField]
   private List<SpriteRenderer> _spriteRenderers;

   public void UpdateUi(SpriteAtlas spriteAtlas)
   {
      Sprite[] sprites = new Sprite[spriteAtlas.spriteCount];
      spriteAtlas.GetSprites(sprites);
      
      if (sprites.Length != _spriteRenderers.Count)
      {
         Debug.LogWarning("Количество спрайтов и SpriteRenderer не совпадает.");
         return;
      }
      
      _spriteRenderers.Zip(sprites, (renderer, sprite) => new { renderer, sprite })
         .ToList()
         .ForEach(pair => pair.renderer.sprite = pair.sprite);
   }
}
