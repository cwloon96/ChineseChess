using ChineseChess.Managers;
using ChineseChess.Requests;
using ChineseChess.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ChineseChess.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GameController : ControllerBase
    {
        private readonly GameManager _gameManager;

        public GameController(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        [HttpPost]
        public IActionResult InitGame()
        {
            return Ok(_gameManager.InitGame());
        }

        [HttpPost]
        public IActionResult Move(MoveRequest moveRequest)
        {
            return Ok(_gameManager.Move(moveRequest.From, moveRequest.To));
        }
    }
}