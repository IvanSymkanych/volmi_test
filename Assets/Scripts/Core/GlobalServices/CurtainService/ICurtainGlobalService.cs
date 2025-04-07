
namespace Core.GlobalServices.CurtainService
{
    public interface ICurtainGlobalService
    {
        void Initialize();
        void Show(bool animate = true);
        void Hide(bool animate = true);
    }
}