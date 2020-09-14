using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const float LeftBlockX = -1.5f;
    private const float CenterBlockX = 0;
    private const float RightBlockX = 1.5f;
    private const float BlockY = 0.2f;
    private const float BlockZ = 3.5f;

    [SerializeField] private UIManager _uiManager;
    [SerializeField] private Player _player;
    [SerializeField] private Ball _ball;
    [SerializeField] private Arrow _arrow;
    [SerializeField] private AI _ai;
    [SerializeField] private Block _block;
    [SerializeField] private Map _map;

    private Player _playerInstance;
    private Ball _ballInstance;
    private Arrow _arrowInstance;
    private AI _aiInstance;
    private Map _mapInstance;
    private List<Block> _blocks;
    
    private IInputable _inputable;
    private bool _isStartGame;
    private DifficultGame _difficultGame;
    private SaveState _saveState;
    private EntityTransform _entityTransform;

    public void Start()
    {
        _inputable = new MouseInput();                                                    
        _playerInstance = _player.CreatePlayer();
        _ballInstance = _ball.CreateBall(this);
        _arrowInstance = _arrow.CreateArrow();
        _aiInstance = _ai.CreateAI();
        _mapInstance = _map.CreateMap();
        _blocks = new List<Block>();
        _blocks.Add(_block.CreateBlock(new Vector3(LeftBlockX, BlockY, BlockZ)));
        _blocks.Add(_block.CreateBlock(new Vector3(CenterBlockX, BlockY, BlockZ)));
        _blocks.Add(_block.CreateBlock(new Vector3(RightBlockX, BlockY, BlockZ)));
        _entityTransform = new EntityTransform(Camera.main, _playerInstance, _ballInstance,
            _arrowInstance, _aiInstance);
        _difficultGame = new DifficultGame();
        _saveState = new SaveState(_ballInstance);
        _uiManager.GameManager = this;
        StartGame();
    }

    private void StartGame()
    {
        _aiInstance.GetComponent<AIBaseStats>().Speed = _difficultGame.Level;
        _isStartGame = true;
    }
    
    public void Update()
    {
        Game();
    }

    private void Game()
    {
        Vector2 target2D = _inputable.GetDataFromInputDevice();
        bool isRun = _inputable.IsKeyUp();
        if (!_isStartGame)
            isRun = false;
        _entityTransform.Run(target2D, isRun);
    }

    public void CheckCollider(Collider collider)
    {
        if ("AI".Equals(collider.tag))
            LoseGame();
        else if ("Block".Equals(collider.tag))
            KillBlock(collider.GetComponent<BlockBaseStats>());
    }
    
    private void LoseGame()
    {
        _entityTransform.ResetTransform();
    }

    private void KillBlock(BlockBaseStats block)
    {
        block.IsVisible = false;
        List<BlockBaseStats> blockBaseStatses = new List<BlockBaseStats>();
        int i = 0;
        
        foreach (Block vBlock in _blocks)
        {
            BlockBaseStats blockBaseStats = vBlock.GetComponent<BlockBaseStats>();
            blockBaseStatses.Add(blockBaseStats);
            if (!blockBaseStats.IsVisible)
                i++;
        }

        if (i == 3)
            WinGame(blockBaseStatses);
        _entityTransform.ResetTransform();
    }

    private void WinGame(List<BlockBaseStats> blockBaseStatses)
    {
        foreach (BlockBaseStats blockBaseStats in blockBaseStatses)
            blockBaseStats.IsVisible = true;
        int level = _difficultGame.LevelUpAndGet();
        _uiManager.UpdateLevelText(level);
        StartGame();
    }

    public void PauseGame()
    {
        _isStartGame = false;
        _saveState.Save();
    }

    public void ResumeGame()
    {
        _saveState.Load();
        _isStartGame = true;
    }
}