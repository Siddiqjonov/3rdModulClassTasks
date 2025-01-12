using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicCRUD.Service.DTOs;
using MusicCRUD.Service.Service;

namespace MusicCRUD.Server.Controllers;

[Route("api/music")]
[ApiController]
public class MusicController : ControllerBase
{

    private readonly IMusicService _musicService;
    public MusicController()
    {
        _musicService = new MusicService();
    }
    [HttpPost("addMusic")]
    public Guid AddMusic(MusicDto musicDto)
    {
        var id = _musicService.AddMusic(musicDto);
        return id;
    }
    [HttpGet("getAllMusic")]
    public List<MusicDto> GetAllMusic()
    {
        var musicList = _musicService.GetAllMusic();
        return musicList;
    }
}
