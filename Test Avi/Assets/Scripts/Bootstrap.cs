using System;
using System.Threading.Tasks;
using GameLogic;
using GameLogic.Abstractions;
using UnityEngine;

namespace DefaultNamespace
{
    public class Bootstrap: MonoBehaviour
    {
        [SerializeField] private ButtonView _buttonView;
        [SerializeField] private PanelView _panelView;
        private IPanelSpriteLoadingController _panelSpriteLoadingController;
        private Func<Task> handler;

        public void Start()
        {
            _panelSpriteLoadingController = new AddresablesPanelSpriteLoadingController(_panelView);
            handler = async () => await _panelSpriteLoadingController.LoadSprites();
            _buttonView.OnButtonPressed += handler;
        }

        public void OnDestroy()
        {
            _buttonView.OnButtonPressed -= handler;
        }
    }
}