using System.Threading.Tasks;

namespace GameLogic.Abstractions
{
    public interface IPanelSpriteLoadingController
    {
        public Task LoadSprites();
        public void Cleanup();
    }
}