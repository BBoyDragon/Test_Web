using System;
using System.Collections;
using System.Threading.Tasks;
using GameLogic.Abstractions;
using UnityEngine.AddressableAssets;
using UnityEngine.U2D;

namespace GameLogic
{
    public class AddresablesPanelSpriteLoadingController: IPanelSpriteLoadingController
    {
        private PanelView _panelView;
        private SpriteAtlas _atlas;

        public AddresablesPanelSpriteLoadingController(PanelView panelView)
        {
            _panelView = panelView;
        }

        public async Task LoadSprites()
        {
            var handle = Addressables.LoadAssetAsync<SpriteAtlas>("Assets/Textures/Atlas.spriteatlasv2");
            _atlas = await handle.Task;
            if (_atlas == null)
            {
                throw new NullReferenceException("There is no Atlas in Addresables");
            }
            _panelView.UpdateUi(_atlas);
        }

        public void Cleanup()
        {
            if (_atlas == null)
            {
                return;
            }
            Addressables.Release(_atlas);
            _atlas = null;
        }
    }
}