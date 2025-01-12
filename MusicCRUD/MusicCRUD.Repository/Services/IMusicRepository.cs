using MusicCRUD.DataAccess.Entity;

namespace MusicCRUD.Repository.Services;

public interface IMusicRepository
{
    Guid AddMusic(Music music);
    void DeleteMusic(Guid id);
    List<Music> GetAllMusic();
    Music GetMusicById(Guid id);
    void UpdateMusic(Music music);
}