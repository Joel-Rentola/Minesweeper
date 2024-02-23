namespace Minesweeper
{
    public partial class Minesweeper_mainprogram : Form
    {
        //Creating all needed variables
        public Point point = new Point(50, 100);
        int maximumXPosition;
        Tile[,] tiles;
        Random rnd = new Random();
        bool gameStarted;
        int timePast = 0;
        int numOfMines;
        int numOfAllTiles;
        int markedTiles = 0;
        string boardSize;
        Bitmap btmp = Properties.Resources.Bomb;
        Image flagImage = Properties.Resources.flag;
        System.Windows.Forms.Timer timer;

        //Creating timer that is used to see how much time has passed since game start
        public Minesweeper_mainprogram()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += TimerTick;
        }

        //Method for start button click where all the needed parameters are checked and then creating board
        private void StartButton_Click(object sender, EventArgs e)
        {
            if (gameStarted == true)
            {
                ResetGame();
                gameStarted = false;
            }
            if (DifficultySelectBox.Text == "Easy") 
            {
                numOfMines = 10;
                numOfAllTiles = 81;
                maximumXPosition = 365;
                boardSize = "9,9";
                tiles = new Tile[9, 9];
                GenerateBoard();
            }
            else if(DifficultySelectBox.Text == "Medium") 
            {
                numOfMines = 40;
                numOfAllTiles = 256;
                maximumXPosition = 610;
                boardSize = "16,16";
                tiles = new Tile[16, 16];
                GenerateBoard();
            }
            else if(DifficultySelectBox.Text == "Hard") 
            {
                numOfMines = 99;
                numOfAllTiles = 480;
                maximumXPosition = 1100;
                boardSize = "16,30";
                tiles = new Tile[16, 30];
                GenerateBoard();
            }
            else 
            {
                MessageBox.Show("You haven't chosen any difficulty!", "Note!");
            }
            UsedTime.Text = "Time: 0";
            MarkedTilesInfo.Text = "Marked tiles: " + "0/" + numOfMines;
        }

        //Method for generating board that calls drawboard function when board is generated
        void GenerateBoard()
        {
            int indexY = 0;
            int indexX = 0;
            for (int i = 0; i < int.Parse(boardSize.Split(",")[0].ToString()); i++)
            {
                for (int i2 = 0; i2 < int.Parse(boardSize.Split(",")[1].ToString()); i2++)
                {
                    Tile tile = new Tile();
                    tile.Name = indexY + "," + indexX;
                    tile.MouseDown += new MouseEventHandler(Tile_Mouse_Click);
                    tile.Click += Tile_Click;
                    tiles[indexY, indexX] = tile;
                    indexX++;
                }
                indexY++;
                indexX = 0;
            }
            int createdMinesIndex = 0;
            while (createdMinesIndex < numOfMines)
            {
                indexY = rnd.Next(0, int.Parse(boardSize.Split(",")[0].ToString()));
                indexX = rnd.Next(0, int.Parse(boardSize.Split(",")[1].ToString()));
                Tile mineTile = tiles[indexY, indexX];
                if (!mineTile.isMine)
                {
                    mineTile.isMine = true;
                    createdMinesIndex++;
                }
            }
            foreach (Tile tile in tiles)
            {
                GetMinesAroundCount(tile);
                if (tile.minesAroud == 0)
                {
                    tile.isEmpty = true;
                }
            }
            DrawBoard();
            gameStarted = true;
        }

        //Method for drawing the board to the screen and when the board is drawn the timer is started
        private void DrawBoard()
        {
            foreach (Tile tile in tiles)
            {
                while (true)
                {
                    if (point.X >= maximumXPosition)
                    {
                        point.X = 50;
                        point.Y += 35;
                    }
                    else
                    {
                        tile.Location = point;
                        this.Controls.Add(tile);
                        point.X += 35;
                        break;
                    }
                }
            }
            timer.Start();
        }

        //Method for checking how many mines are around a tile
        public void GetMinesAroundCount(object sender)
        {
            Tile senderTile = sender as Tile;
            int minesAround = 0;
            int tileIndexY = int.Parse(senderTile.Name.Split(",")[0].ToString());
            int tileIndexX = int.Parse(senderTile.Name.Split(",")[1].ToString());
            int indexY = tileIndexY - 1;
            int indexX = tileIndexX - 1;
            for (int k = 0; k < 9; k++)
            {
                if (indexX == tileIndexX + 2)
                {
                    indexX = tileIndexX - 1;
                    indexY++;
                }
                while (true)
                {
                    try
                    {
                        Tile neighbourTile = tiles[indexY, indexX];
                        if (neighbourTile.isMine == true)
                        {
                            minesAround++;
                            indexX++;
                        }
                        else
                        {
                            indexX++;
                        }
                        break;
                    }
                    catch (Exception)
                    {
                        indexX++;
                        break;
                    }
                }
            }
            senderTile.minesAroud = minesAround;
        }

        //Handling the flagging. If the tile is clicked with right mouse button the tile will be flagged/marked. If the tile
        //is already marked then this method will remove the marking/flagging
        private void Tile_Mouse_Click(object sender, MouseEventArgs e) 
        {
            Tile mouseClickedTile = sender as Tile;
            if (e.Button == MouseButtons.Right && mouseClickedTile.isMarked == false)
            {
                mouseClickedTile.isMarked = true;
                mouseClickedTile.BackgroundImage = flagImage;
                mouseClickedTile.BackgroundImageLayout = ImageLayout.Stretch;
                markedTiles++;
            }
            else if (e.Button == MouseButtons.Right && mouseClickedTile.isMarked == true) 
            {
                mouseClickedTile.isMarked = false;
                mouseClickedTile.BackgroundImage = null;
                markedTiles -= 1;
            }
            MarkedTilesInfo.Text = "Marked tiles: " + markedTiles + "/" + numOfMines;
        }
        //Handling the normal click
        //If the clicked tile is marked/flagged nothing will happen
        //This method also checks if the game is won and handles that
        void Tile_Click(object sender, EventArgs e)
        {
            Tile clickedTile = sender as Tile;
            if (clickedTile.isMarked) 
            {
                return;
            }
            if (clickedTile.isMine == true)
            {
                timer.Stop();
                clickedTile.isMarked = true;
                foreach (Tile mineTile in tiles)
                {
                    if (mineTile.isMine == true)
                    {
                        btmp.MakeTransparent();
                        mineTile.BackgroundImage = btmp;
                        mineTile.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
                var msgBox = MessageBox.Show("You hit a mine! Do you want to play a new game?","Note!",MessageBoxButtons.YesNo);
                if (msgBox == DialogResult.Yes) 
                {
                    StartButton.PerformClick();
                }
                else 
                {
                    Application.Exit();
                }
            }
            else
            {
                if (!clickedTile.isEmpty)
                {
                    clickedTile.Text = clickedTile.minesAroud.ToString();
                    clickedTile.BackColor = Color.White;
                    clickedTile.Enabled = false;
                }
                else
                {
                    FloodFill(clickedTile);
                }
            }
            if (CheckWin() == true)
            {
                timer.Stop();
                var msgBox = MessageBox.Show("You won!!!  Your time: " + timePast + "sec." + "\nDo you want to play a new game?", "Congratulations!", MessageBoxButtons.YesNo);
                if (msgBox == DialogResult.Yes) 
                {
                    StartButton.PerformClick();
                }
                else 
                {
                    Application.Exit();
                }
            }
        }

        //Removing all tiles from the screen and resetting all needed variables and lists
        private void ResetGame() 
        {
            foreach (Tile tile in tiles)
            {
                this.Controls.Remove(tile);
            }
            Array.Clear(tiles, 0, tiles.Length);
            timePast = 0;
            markedTiles = 0;
            point = new Point(50, 100);
        }
        
        //Checking if all possible tiles are revaled and if that's true the game is won
        private bool CheckWin() 
        {
            bool win = false;
            int revealedTiles = 0;
            foreach(Tile tile in tiles) 
            {
                if (tile.Enabled == false) 
                {
                    revealedTiles++;
                }
            }
            if(revealedTiles == numOfAllTiles - numOfMines) 
            {
                win = true;
            }
            return win;
        }

        //Method for timer tick and updating displayed time on every second
        void TimerTick(object sender, EventArgs e) 
        {
            timePast += 1;
            UsedTime.Text = "Time: " + timePast;
        }

        //Method for floodfilling when the clicked tile doesn't have any mines around it
        private void FloodFill(Tile senderTile)
        {
            int y = int.Parse(senderTile.Name.Split(",")[0].ToString());
            int x = int.Parse(senderTile.Name.Split(",")[1].ToString());
            senderTile.Enabled = false;
            senderTile.BackColor = Color.White;
            List<Tile> emptyTiles = new List<Tile>();
            for (int i = -1; i < 2; i++)
            {
                int column = y + i;
                for (int j = -1; j < 2; j++)
                {
                    int row = x + j;

                    if (column == -1 || row == -1 || column > int.Parse(boardSize.Split(",")[0].ToString()) - 1 || row > int.Parse(boardSize.Split(",")[1].ToString()) - 1)
                    {
                        continue;
                    }
                    if (column == y && row == x)
                    {
                        continue;
                    }
                    Tile neighbourTile = tiles[column, row];
                    int xNeighbour = int.Parse(neighbourTile.Name.Split(",")[1].ToString());
                    int yNeighbour = int.Parse(neighbourTile.Name.Split(",")[0].ToString());
                    if (tiles[yNeighbour, xNeighbour].minesAroud == 0)
                    {
                        if(neighbourTile.Enabled != false) 
                        {
                            neighbourTile.Text = string.Empty;
                            neighbourTile.BackColor = Color.White;
                            neighbourTile.Enabled = false;
                            emptyTiles.Add(neighbourTile);
                            if (neighbourTile.isMarked) 
                            {
                                neighbourTile.isMarked = false;
                                neighbourTile.BackgroundImage = null;
                            }
                        }
                        
                    }
                    else if (neighbourTile.isMine == false)
                    {
                        neighbourTile.PerformClick();
                    }

                }
            }
            foreach(var tile in emptyTiles) 
            {
                FloodFill(tile);
            }
        }
    }
}