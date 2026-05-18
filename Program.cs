using OOP.Entites;
using OOP.Items;
using OOP.SystemGame;
using OOP.Weapons;

Player player = new("Excel");
SummonEnemy summonEnemy = new();
DropItems dropItems = new();

Console.WriteLine("===Selamat Data di Prgatory===");
Console.WriteLine("Selesaikan 10 Ruangan untuk keluar dari sini");
player.ShowStatus();
Console.WriteLine("Jangan sampai sanity mu habis dan kamu kelaparan, Ingat Itu!!! ");

Console.Write("Sudah Siap Untuk Menjelajah? (Y) ");
string play = Console.ReadLine() ?? "";

if (play == "Y")
{
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine("Kamu mamsasuki ruangan");
        Enemy enemy = summonEnemy.SummoningEnemy();
        Console.WriteLine("Sesuatu Muncul!!");
        enemy.InfoEnemy();
        bool round = true;
        while (round)
        {
            if (enemy.Hp <= 0 || player.Hp <= 0 || player.Sanity <= 0) break;
            Console.WriteLine("--Action Menu--");
            Console.WriteLine("1. Lihat Status\n2. Lihat Inventory\n3. Serang");

            Console.Write("Pilih: ");
            string choise = Console.ReadLine() ?? "";

            switch (choise)
            {
                case "1":
                    player.ShowStatus();
                    break;
                case "2":
                    Torch torch = new();
                    BoneClub boneClub = new();
                    player.UseWeapon(boneClub);
                    player.Inventory!.Add(torch);
                    player.ShowInventory();
                    if (player.Inventory != null)
                    {
                        Console.Write("Pilih Item di inventory: ");
                        int choseItem = int.TryParse(Console.ReadLine(), out int itemChoice) ? itemChoice : -1;
                        choseItem -= 1;
                        if (choseItem >= 0 && choseItem < player.Inventory.Count)
                        {
                            Console.WriteLine($"Kamu memilih {player.Inventory[choseItem].Name}");
                            if (player.Inventory[choseItem] is Weapon weapon)
                            {
                                weapon.ShowInfo();
                                if (player.EquippedWeapon is null)
                                {
                                    Console.WriteLine("Gunakan Sebagi Senjata? (y/n) ");
                                }
                                else
                                {
                                    Console.Write($"Mau mengganti {player.EquippedWeapon.Name} dengan {weapon.Name}? (y/n)");
                                }
                                string useChoise = Console.ReadLine() ?? "";
                                if (useChoise == "y")
                                {
                                    player.UseWeapon(weapon);
                                    player.ShowStatus();
                                }
                                else if (useChoise == "n")
                                {
                                    Console.WriteLine("Kembali Ke menu...");
                                }
                                else
                                {
                                    Console.WriteLine("Input Tidak sesuai");
                                }
                            }
                            else if (player.Inventory[choseItem] is Item item)
                            {
                                item.ShowInfo();
                                Console.WriteLine("Gunakan Item Ini? (y/n) ");
                                string useChoise = Console.ReadLine() ?? "";
                                if (useChoise == "y")
                                {
                                    player.UseItem(choseItem + 1);
                                    player.ShowStatus();
                                }
                                else if (useChoise == "n")
                                {
                                    Console.WriteLine("Kembali Ke menu...");
                                }
                                else
                                {
                                    Console.WriteLine("Input Tidak sesuai");
                                }
                            }
                        }
                    }
                    break;
                case "3":
                    player.Attack(5);
                    break;
                default:
                    Console.WriteLine("Tidak ada pilihan itu");
                    break;
            }
        }
    }
}
else
{
    Console.WriteLine("Kamu terlalu lemah bahkan untuk memulai MATI SAJA SANA!!!💀💀");
}

