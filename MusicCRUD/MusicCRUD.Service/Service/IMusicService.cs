using MusicCRUD.Service.DTOs;

namespace MusicCRUD.Service.Service;

public interface IMusicService
{
    Guid AddMusic(MusicDto music);
    void DeleteMusic(Guid id);
    List<MusicDto> GetAllMusic();
}