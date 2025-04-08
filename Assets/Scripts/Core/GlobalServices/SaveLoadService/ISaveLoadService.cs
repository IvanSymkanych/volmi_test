
namespace Core.GlobalServices.SaveLoadService
{
    public interface ISaveLoadService
    {
        GameSaveModel GameSaveModel { get; }
        void Save();
    }
}