using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp_テトリス
{
    public partial class MainWindow : Window
    {
        // ゲーム定数
        const int Cols = 10;
        const int Rows = 20;
        const int CellSize = 30;

        // ゲーム状態
        int[,] board = new int[Rows, Cols];
        DispatcherTimer gameTimer;
        bool isRunning = false;
        bool isPaused = false;
        int score = 0;
        int level = 1;
        int lines = 0;

        // 現在のピース
        int[][] currentPiece;
        int currentX, currentY;
        int currentColor;

        // 次のピース
        int[][] nextPiece;
        int nextColor;

        // テトロミノ定義（7種類）
        static readonly int[][][] Tetrominos = new int[][][]
        {
            // I
            new int[][] { new int[]{1,1,1,1} },
            // O
            new int[][] { new int[]{1,1}, new int[]{1,1} },
            // T
            new int[][] { new int[]{0,1,0}, new int[]{1,1,1} },
            // S
            new int[][] { new int[]{0,1,1}, new int[]{1,1,0} },
            // Z
            new int[][] { new int[]{1,1,0}, new int[]{0,1,1} },
            // J
            new int[][] { new int[]{1,0,0}, new int[]{1,1,1} },
            // L
            new int[][] { new int[]{0,0,1}, new int[]{1,1,1} },
        };

        // ネオンカラー
        static readonly Color[] PieceColors = new Color[]
        {
            Color.FromRgb(0, 212, 255),   // シアン (I)
            Color.FromRgb(255, 214, 10),  // イエロー (O)
            Color.FromRgb(190, 0, 255),   // パープル (T)
            Color.FromRgb(0, 255, 128),   // グリーン (S)
            Color.FromRgb(255, 0, 110),   // ピンク (Z)
            Color.FromRgb(0, 100, 255),   // ブルー (J)
            Color.FromRgb(255, 120, 0),   // オレンジ (L)
        };

        Random rng = new Random();

        public MainWindow()
        {
            InitializeComponent();
            gameTimer = new DispatcherTimer();
            gameTimer.Tick += GameTick;
            gameTimer.Interval = TimeSpan.FromMilliseconds(500);

            GameCanvas.Focus();
            DrawGhost();
        }

        void StartButton_Click(object sender, RoutedEventArgs e)
        {
            ResetGame();
            isRunning = true;
            isPaused = false;
            gameTimer.Start();
            StartButton.Content = "🔄 RESTART";
            PauseButton.IsEnabled = true;
            GameCanvas.Focus();
        }

        void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isRunning) return;
            isPaused = !isPaused;
            if (isPaused)
            {
                gameTimer.Stop();
                PauseButton.Content = "▶ RESUME";
                DrawPauseOverlay();
            }
            else
            {
                gameTimer.Start();
                PauseButton.Content = "⏸ PAUSE";
                Render();
            }
            GameCanvas.Focus();
        }

        void ResetGame()
        {
            board = new int[Rows, Cols];
            score = 0;
            level = 1;
            lines = 0;
            UpdateUI();
            gameTimer.Interval = TimeSpan.FromMilliseconds(500);
            nextPiece = GetRandomPiece(out nextColor);
            SpawnPiece();
        }

        void GameTick(object sender, EventArgs e)
        {
            if (!MoveDown())
            {
                LockPiece();
                int cleared = ClearLines();
                UpdateScore(cleared);
                SpawnPiece();
                if (!IsValidPosition(currentPiece, currentX, currentY))
                {
                    GameOver();
                }
            }
            Render();
        }

        void SpawnPiece()
        {
            currentPiece = nextPiece;
            currentColor = nextColor;
            currentX = Cols / 2 - currentPiece[0].Length / 2;
            currentY = 0;
            nextPiece = GetRandomPiece(out nextColor);
            DrawNextPiece();
        }

        int[][] GetRandomPiece(out int colorIndex)
        {
            int idx = rng.Next(Tetrominos.Length);
            colorIndex = idx + 1;
            return ClonePiece(Tetrominos[idx]);
        }

        int[][] ClonePiece(int[][] piece)
        {
            var clone = new int[piece.Length][];
            for (int r = 0; r < piece.Length; r++)
            {
                clone[r] = (int[])piece[r].Clone();
            }
            return clone;
        }

        bool MoveDown()
        {
            if (IsValidPosition(currentPiece, currentX, currentY + 1))
            {
                currentY++;
                return true;
            }
            return false;
        }

        void MoveLeft()
        {
            if (IsValidPosition(currentPiece, currentX - 1, currentY))
                currentX--;
        }

        void MoveRight()
        {
            if (IsValidPosition(currentPiece, currentX + 1, currentY))
                currentX++;
        }

        void Rotate()
        {
            var rotated = RotatePiece(currentPiece);
            if (IsValidPosition(rotated, currentX, currentY))
                currentPiece = rotated;
            else if (IsValidPosition(rotated, currentX - 1, currentY))
            { currentPiece = rotated; currentX--; }
            else if (IsValidPosition(rotated, currentX + 1, currentY))
            { currentPiece = rotated; currentX++; }
        }

        void HardDrop()
        {
            while (MoveDown()) { score += 2; }
            LockPiece();
            int cleared = ClearLines();
            UpdateScore(cleared);
            SpawnPiece();
            if (!IsValidPosition(currentPiece, currentX, currentY))
                GameOver();
            Render();
        }

        int[][] RotatePiece(int[][] piece)
        {
            int rows = piece.Length;
            int cols = piece[0].Length;
            var rotated = new int[cols][];
            for (int c = 0; c < cols; c++)
            {
                rotated[c] = new int[rows];
                for (int r = 0; r < rows; r++)
                    rotated[c][r] = piece[rows - 1 - r][c];
            }
            return rotated;
        }

        bool IsValidPosition(int[][] piece, int px, int py)
        {
            for (int r = 0; r < piece.Length; r++)
                for (int c = 0; c < piece[r].Length; c++)
                    if (piece[r][c] != 0)
                    {
                        int nx = px + c, ny = py + r;
                        if (nx < 0 || nx >= Cols || ny >= Rows) return false;
                        if (ny >= 0 && board[ny, nx] != 0) return false;
                    }
            return true;
        }

        void LockPiece()
        {
            for (int r = 0; r < currentPiece.Length; r++)
                for (int c = 0; c < currentPiece[r].Length; c++)
                    if (currentPiece[r][c] != 0)
                    {
                        int ny = currentY + r, nx = currentX + c;
                        if (ny >= 0) board[ny, nx] = currentColor;
                    }
        }

        int ClearLines()
        {
            int cleared = 0;
            for (int r = Rows - 1; r >= 0; r--)
            {
                bool full = true;
                for (int c = 0; c < Cols; c++)
                    if (board[r, c] == 0) { full = false; break; }
                if (full)
                {
                    for (int row = r; row > 0; row--)
                        for (int c = 0; c < Cols; c++)
                            board[row, c] = board[row - 1, c];
                    for (int c = 0; c < Cols; c++) board[0, c] = 0;
                    cleared++;
                    r++;
                }
            }
            return cleared;
        }

        void UpdateScore(int cleared)
        {
            int[] bonus = { 0, 100, 300, 500, 800 };
            if (cleared > 0)
                score += bonus[Math.Min(cleared, 4)] * level;
            lines += cleared;
            level = lines / 10 + 1;
            gameTimer.Interval = TimeSpan.FromMilliseconds(Math.Max(100, 500 - (level - 1) * 40));
            UpdateUI();
        }

        void UpdateUI()
        {
            ScoreText.Text = score.ToString("N0");
            LevelText.Text = level.ToString();
            LinesText.Text = lines.ToString();
        }

        // ゴーストピースのY座標を計算
        int GetGhostY()
        {
            int gy = currentY;
            while (IsValidPosition(currentPiece, currentX, gy + 1)) gy++;
            return gy;
        }

        void GameOver()
        {
            isRunning = false;
            gameTimer.Stop();
            PauseButton.IsEnabled = false;

            var overlay = new Rectangle
            {
                Width = Cols * CellSize,
                Height = Rows * CellSize,
                Fill = new SolidColorBrush(Color.FromArgb(180, 0, 0, 0))
            };
            Canvas.SetLeft(overlay, 0);
            Canvas.SetTop(overlay, 0);
            GameCanvas.Children.Add(overlay);

            var text = new TextBlock
            {
                Text = "GAME OVER",
                FontSize = 28,
                FontWeight = FontWeights.Black,
                Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 110)),
                FontFamily = new FontFamily("Consolas")
            };
            text.Measure(new Size(300, 100));
            Canvas.SetLeft(text, (Cols * CellSize - 200) / 2);
            Canvas.SetTop(text, Rows * CellSize / 2 - 40);
            GameCanvas.Children.Add(text);

            var scoreText = new TextBlock
            {
                Text = $"SCORE: {score:N0}",
                FontSize = 14,
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(Color.FromRgb(0, 212, 255)),
                FontFamily = new FontFamily("Consolas")
            };
            Canvas.SetLeft(scoreText, (Cols * CellSize - 150) / 2);
            Canvas.SetTop(scoreText, Rows * CellSize / 2 + 10);
            GameCanvas.Children.Add(scoreText);
        }

        void DrawPauseOverlay()
        {
            var overlay = new Rectangle
            {
                Width = Cols * CellSize,
                Height = Rows * CellSize,
                Fill = new SolidColorBrush(Color.FromArgb(160, 0, 0, 0))
            };
            Canvas.SetLeft(overlay, 0);
            Canvas.SetTop(overlay, 0);
            GameCanvas.Children.Add(overlay);

            var text = new TextBlock
            {
                Text = "PAUSE",
                FontSize = 32,
                FontWeight = FontWeights.Black,
                Foreground = new SolidColorBrush(Color.FromRgb(255, 214, 10)),
                FontFamily = new FontFamily("Consolas")
            };
            Canvas.SetLeft(text, (Cols * CellSize - 130) / 2);
            Canvas.SetTop(text, Rows * CellSize / 2 - 25);
            GameCanvas.Children.Add(text);
        }

        void DrawGhost()
        {
            // 描画はRenderで行うので空
        }

        void Render()
        {
            GameCanvas.Children.Clear();

            // グリッド線
            for (int r = 0; r <= Rows; r++)
            {
                var line = new Line
                {
                    X1 = 0,
                    Y1 = r * CellSize,
                    X2 = Cols * CellSize,
                    Y2 = r * CellSize,
                    Stroke = new SolidColorBrush(Color.FromArgb(30, 255, 255, 255)),
                    StrokeThickness = 0.5
                };
                GameCanvas.Children.Add(line);
            }
            for (int c = 0; c <= Cols; c++)
            {
                var line = new Line
                {
                    X1 = c * CellSize,
                    Y1 = 0,
                    X2 = c * CellSize,
                    Y2 = Rows * CellSize,
                    Stroke = new SolidColorBrush(Color.FromArgb(30, 255, 255, 255)),
                    StrokeThickness = 0.5
                };
                GameCanvas.Children.Add(line);
            }

            // ボード描画
            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Cols; c++)
                    if (board[r, c] != 0)
                        DrawCell(c, r, PieceColors[board[r, c] - 1], 1.0);

            if (isRunning && currentPiece != null)
            {
                // ゴーストピース
                int gy = GetGhostY();
                if (gy != currentY)
                    for (int r = 0; r < currentPiece.Length; r++)
                        for (int c = 0; c < currentPiece[r].Length; c++)
                            if (currentPiece[r][c] != 0)
                                DrawGhostCell(currentX + c, gy + r, PieceColors[currentColor - 1]);

                // 現在のピース
                for (int r = 0; r < currentPiece.Length; r++)
                    for (int c = 0; c < currentPiece[r].Length; c++)
                        if (currentPiece[r][c] != 0)
                            DrawCell(currentX + c, currentY + r, PieceColors[currentColor - 1], 1.0);
            }
        }

        void DrawCell(int x, int y, Color color, double opacity)
        {
            var rect = new Rectangle
            {
                Width = CellSize - 2,
                Height = CellSize - 2,
                Fill = new SolidColorBrush(color) { Opacity = opacity },
                RadiusX = 3,
                RadiusY = 3
            };
            Canvas.SetLeft(rect, x * CellSize + 1);
            Canvas.SetTop(rect, y * CellSize + 1);
            GameCanvas.Children.Add(rect);

            // ハイライト
            var highlight = new Rectangle
            {
                Width = CellSize - 4,
                Height = 6,
                Fill = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255)),
                RadiusX = 2,
                RadiusY = 2
            };
            Canvas.SetLeft(highlight, x * CellSize + 2);
            Canvas.SetTop(highlight, y * CellSize + 2);
            GameCanvas.Children.Add(highlight);
        }

        void DrawGhostCell(int x, int y, Color color)
        {
            var rect = new Rectangle
            {
                Width = CellSize - 2,
                Height = CellSize - 2,
                Fill = new SolidColorBrush(Color.FromArgb(50, color.R, color.G, color.B)),
                Stroke = new SolidColorBrush(Color.FromArgb(120, color.R, color.G, color.B)),
                StrokeThickness = 1,
                RadiusX = 3,
                RadiusY = 3
            };
            Canvas.SetLeft(rect, x * CellSize + 1);
            Canvas.SetTop(rect, y * CellSize + 1);
            GameCanvas.Children.Add(rect);
        }

        void DrawNextPiece()
        {
            NextCanvas.Children.Clear();
            if (nextPiece == null) return;

            int pieceW = nextPiece[0].Length;
            int pieceH = nextPiece.Length;
            int cellSize = 16;
            double offsetX = (80 - pieceW * cellSize) / 2.0;
            double offsetY = (80 - pieceH * cellSize) / 2.0;

            for (int r = 0; r < pieceH; r++)
                for (int c = 0; c < pieceW; c++)
                    if (nextPiece[r][c] != 0)
                    {
                        var rect = new Rectangle
                        {
                            Width = cellSize - 2,
                            Height = cellSize - 2,
                            Fill = new SolidColorBrush(PieceColors[nextColor - 1]),
                            RadiusX = 2,
                            RadiusY = 2
                        };
                        Canvas.SetLeft(rect, offsetX + c * cellSize);
                        Canvas.SetTop(rect, offsetY + r * cellSize);
                        NextCanvas.Children.Add(rect);
                    }
        }

        void GameCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isRunning || isPaused) return;

            switch (e.Key)
            {
                case Key.Left: MoveLeft(); break;
                case Key.Right: MoveRight(); break;
                case Key.Down: if (MoveDown()) score++; UpdateUI(); break;
                case Key.Up: Rotate(); break;
                case Key.Space: HardDrop(); return;
            }
            Render();
        }
    }
}
