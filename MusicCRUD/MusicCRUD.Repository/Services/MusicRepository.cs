using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MusicCRUD.DataAccess.Entity;

namespace MusicCRUD.Repository.Services;

public class MusicRepository : IMusicRepository
{
    private readonly string _path;
    private List<Music> _music;
    public MusicRepository()
    {
        _path = Path.Combine(Directory.GetCurrentDirectory(), "Music.json");
        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }
        _music = GetAllMusic();
    }

    public Guid AddMusic(Music music)
    {
        _music.Add(music);
        SaveData();
        return music.Id;
    }

    public void DeleteMusic(Guid id)
    {
        var musicFromDb = GetMusicById(id);
        _music.Remove(musicFromDb);
        SaveData();
    }

    public List<Music> GetAllMusic()
    {
        var musicJson = File.ReadAllText(_path);
        var musicList = JsonSerializer.Deserialize<List<Music>>(musicJson);
        return musicList;
    }

    public Music GetMusicById(Guid id)
    {
        return _music.FirstOrDefault(x => x.Id == id) ?? throw new NullReferenceException();
    }

    public void UpdateMusic(Music music)
    {
        throw new NotImplementedException();
    }
    private void SaveData()
    {
        var musicJson = JsonSerializer.Serialize(_music);
        File.WriteAllText(_path, musicJson);

    }
}
