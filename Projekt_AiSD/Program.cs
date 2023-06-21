using Projekt_AiSD;
using Projekt_AiSD.DataBase;
using Projekt_AiSD.Player_Staff;


Console.WindowHeight = 45;
/*Player testPlayer = new Player("testmund");
DataBaseReader reader = new DataBaseReader(testPlayer);
Equipment equipment = new Equipment(testPlayer);
Equipment.AllPlayerItems = reader.weaponList;
while (true)
Equipment.DisplayEquipmentMenu();*/

Game game = new Game();
while (true)
    game.Start();

