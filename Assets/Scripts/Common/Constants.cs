public class Constants
{
    public const string ServerURL = "http://localhost:3000";
    public const string GameServerURL = "ws://localhost:3000";

    public enum MultiplayManagerState
    {
        CreateRoom,     // 방 생성
        JoinRoom,       // 생성된 방에 참여
        StartGame,      // 생성한 방에 다른 유저가 참여해서 게임 시작
        ExitRoom,       // 자신이 방을 빠져 나왔을 때
        EndGame         // 상대방이 접속을 끊거나 방을 나갔을 때
    };
    
    public enum PlayerType { None, PlayerA, PlayerB }
    public enum GameType { SinglePlayer, DualPlayer, MultiPlayer }
}