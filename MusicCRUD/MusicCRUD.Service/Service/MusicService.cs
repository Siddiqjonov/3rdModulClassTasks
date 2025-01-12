using MusicCRUD.DataAccess.Entity;
using MusicCRUD.Repository.Services;
using MusicCRUD.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCRUD.Service.Service;

public class MusicService : IMusicService
{
    IMusicRepository _musicRepository;
    public MusicService()
    {
        _musicRepository = new MusicRepository();
    }

    public Guid AddMusic(MusicDto music)
    {
        //var musicEntity = ConvertToMusicEntity(music);
        //var musicId = _musicRepository.AddMusic(musicEntity);
        //return musicId;
        Guid id = _musicRepository.AddMusic(ConvertToMusicEntity(music));
        return id;
    }

    public void DeleteMusic(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<MusicDto> GetAllMusic()
    {
        var musicList = _musicRepository.GetAllMusic();
        var allMusic = musicList.Select(muz => ConvertToMusicDto(muz));
        return allMusic.ToList();
    }
    private Music ConvertToMusicEntity(MusicDto music)
    {
        return new Music
        {
            Id = music.Id ?? Guid.NewGuid(),
            Name = music.Name,
            MB = music.MB,
            AuthorName = music.AuthorName,
            Description = music.Description,
            QuentityLikes = music.QuentityLikes
        };
    }
    private MusicDto ConvertToMusicDto(Music music)
    {
        return new MusicDto
        {
            Id = music.Id,
            Name = music.Name,
            MB = music.MB,
            AuthorName = music.AuthorName,
            Description = music.Description,
            QuentityLikes = music.QuentityLikes
        };
    }

}

