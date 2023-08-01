using System;
namespace CSharp
{
    public enum GameMode
    {
        None,
        Lobby,
        Town,
        Field
    }

    class Game
    {
        private GameMode mode = GameMode.Lobby;
        private Player player = null;
        private Monster monster = null;
        private Random rand = new Random();

        public void Process()
        {
            switch (mode)
            {
                case (GameMode.Lobby):
                    ProcessLobby();
                    break;
                case (GameMode.Town):
                    ProcessTown();
                    break;
                case (GameMode.Field):
                    ProcessField();
                    break;
            }
        }

        private void ProcessLobby()
        {
            Console.WriteLine("Choose one");
            Console.WriteLine("[1] Knight");
            Console.WriteLine("[2] Archer");
            Console.WriteLine("[3] Mage");

            string input = Console.ReadLine();
            switch (input)
            {
                case ("1"):
                    player = new Knight();
                    mode = GameMode.Town;
                    break;
                case ("2"):
                    player = new Archer();
                    mode = GameMode.Town;
                    break;
                case ("3"):
                    player = new Mage();
                    mode = GameMode.Town;
                    break;
            }

        }

        private void ProcessTown()
        {
            Console.WriteLine("Entered town");
            Console.WriteLine("[1]Go back to the field");
            Console.WriteLine("[2]Go back to the lobby");

            string input = Console.ReadLine();

            switch (input)
            {
                case ("1"):
                    mode = GameMode.Field;
                    break;
                case ("2"):
                    mode = GameMode.Lobby;
                    break;
            }

        }

        private void ProcessField()
        {
            Console.WriteLine("Entered field");
            Console.WriteLine("[1]fight");
            Console.WriteLine("[2]attempt to flee");

            CreateRandomMonster();

            string input = Console.ReadLine();

            switch(input)
            {
                case "1":
                    ProcessFight();
                    break;
                case "2":
                    TryEscape();
                    break;
            }
        }

        private void CreateRandomMonster()
        {
            int randValue = rand.Next(0, 3);
            switch (randValue)
            {
                case (0):
                    monster = new Slime();
                    Console.WriteLine("Slime created");
                    break;
                case (1):
                    monster = new Orc();
                    Console.WriteLine("Orc created");

                    break;
                case (2):
                    monster = new Skeleton();
                    Console.WriteLine("Skeleton created");
                    break;
            }
        }

        private void ProcessFight()
        {
            while(true)
            {
                int damage = player.GetAttack();
                monster.OnDamaged(damage);

                if (monster.isDead())
                {
                    Console.WriteLine("win");
                    Console.WriteLine($"remaining hp = {player.GetHp()}");
                    break;
                }

                damage = monster.GetAttack();
                player.OnDamaged(damage);

                if (player.isDead())
                {
                    Console.WriteLine("lose");
                    mode = GameMode.Lobby;
                    break;
                }

            }

        }

        private void TryEscape()
        {
            int randValue = rand.Next(0, 100);
            if (randValue < 33)
            {
                mode = GameMode.Town;
            }
            else
            {
                ProcessFight();
            }
        }

    }
}

