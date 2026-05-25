namespace ConnectFour.Components
{
    public class GameState
    {
        public enum WinState
        {
            None,
            Player1_Wins,
            Player2_Wins,
            Tie
        }

        private int[,] board = new int[6, 7];

        public int PlayerTurn { get; private set; } = 1;
        public int CurrentTurn { get; private set; } = 0;

        public void ResetBoard()
        {
            board = new int[6, 7];
            PlayerTurn = 1;
            CurrentTurn = 0;
        }

        public int PlayPiece(int col)
        {
            for (int row = 5; row >= 0; row--)
            {
                if (board[row, col] == 0)
                {
                    board[row, col] = PlayerTurn;

                    int landingRow = row;

                    PlayerTurn = PlayerTurn == 1 ? 2 : 1;
                    CurrentTurn++;

                    return landingRow + 1;
                }
            }

            return -1;
        }

        public WinState CheckForWin()
        {
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    int player = board[row, col];
                    if (player == 0) continue;

                    // Horizontal →
                    if (col + 3 < 7 &&
                        player == board[row, col + 1] &&
                        player == board[row, col + 2] &&
                        player == board[row, col + 3])
                    {
                        return player == 1 ? WinState.Player1_Wins : WinState.Player2_Wins;
                    }

                    // Vertical ↓
                    if (row + 3 < 6 &&
                        player == board[row + 1, col] &&
                        player == board[row + 2, col] &&
                        player == board[row + 3, col])
                    {
                        return player == 1 ? WinState.Player1_Wins : WinState.Player2_Wins;
                    }

                    // Diagonal ↘
                    if (row + 3 < 6 && col + 3 < 7 &&
                        player == board[row + 1, col + 1] &&
                        player == board[row + 2, col + 2] &&
                        player == board[row + 3, col + 3])
                    {
                        return player == 1 ? WinState.Player1_Wins : WinState.Player2_Wins;
                    }

                    // Diagonal ↙
                    if (row + 3 < 6 && col - 3 >= 0 &&
                        player == board[row + 1, col - 1] &&
                        player == board[row + 2, col - 2] &&
                        player == board[row + 3, col - 3])
                    {
                        return player == 1 ? WinState.Player1_Wins : WinState.Player2_Wins;
                    }
                }
            }

            if (CurrentTurn >= 42)
                return WinState.Tie;

            return WinState.None;
        }

        public bool IsColumnFull(int col)
{
    return board[0, col] != 0;
}
    }
}