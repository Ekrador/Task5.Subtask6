namespace Program
{
    internal class Program
    {
        static (string Name, string Surname, int Age, bool HavingPet, string[] PetNames, string[] FavColors) UserInfo()
        {
            (string Name, string Surname, int Age, bool HavingPet, string[] PetNames, string[] FavColors) User;
            Console.WriteLine("Введите Ваше имя");
            User.Name = Console.ReadLine();

            Console.WriteLine("Введите Вашу фамилию");
            User.Surname = Console.ReadLine();

            string answerToInt;
            int correctInt;
            do
            {
                Console.WriteLine("Введите Ваш возраст");
                answerToInt = Console.ReadLine();

            } while (!IntCheck(answerToInt, out correctInt));

            User.Age = correctInt;

            string pet;
            do
            {
                Console.WriteLine("У Вас есть питомец? (\"Да/Нет\")");
                pet = Console.ReadLine();
            } while (!(pet.ToLower() == "да" || pet.ToLower() == "нет"));

            User.HavingPet = pet == "да" ? true : false;
            if (User.HavingPet)
            {
                do
                {
                    Console.WriteLine("Сколько у Вас питомцев?");
                    answerToInt = Console.ReadLine();
                } while (!IntCheck(answerToInt, out correctInt));
                User.PetNames = Pets(correctInt);

            }
            else User.PetNames = null;

            do
            {
                Console.WriteLine("Сколько у Вас любимых цветов?");
                answerToInt = Console.ReadLine();
            } while (!IntCheck(answerToInt, out correctInt));
            User.FavColors = Colors(correctInt);

            return User;
        }

        static bool IntCheck(string text, out int checkedInt)
        {
            return int.TryParse(text, out checkedInt) & (checkedInt >= 0);

        }

        static string[] Pets(int count)
        {
            string[] pets = new string[count];
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Как зовут {i + 1} питомца?");
                pets[i] = Console.ReadLine();
            }
            return pets;
        }

        static string[] Colors(int count)
        {
            string[] colors = new string[count];
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Какой {i + 1} любимый цвет?");
                colors[i] = Console.ReadLine();
            }
            return colors;
        }

        static void ShowUserInfo((string Name, string Surname, int Age, bool HavingPet, string[] PetNames, string[] FavColors) User)
        {
            Console.WriteLine();
            Console.WriteLine($"Имя пользователя {User.Name}");
            Console.WriteLine($"Фамилия пользователя {User.Surname}");
            Console.WriteLine($"Возраст пользователя {User.Age}");

            if (!User.HavingPet || User.PetNames.Length <= 0)
                Console.WriteLine("У пользователя нет питомцев");
            else if (User.PetNames.Length > 1 && User.PetNames.Length < 5)
                Console.WriteLine($"У пользователя {User.PetNames.Length} питомца, их зовут:");
            else if (User.PetNames.Length > 4)
                Console.WriteLine($"У пользователя {User.PetNames.Length} питомцев, их зовут:");
            else if (User.FavColors.Length == 1)
                Console.WriteLine("У пользователя есть питомец, его зовут:");
            foreach (var petName in User.PetNames)
            {
                Console.WriteLine($"-{petName}");
            }

            if (User.FavColors.Length <= 0)
                Console.WriteLine("У пользователя нет любимых цветов");
            else if (User.FavColors.Length == 1)
                Console.WriteLine($"У пользователя {User.FavColors.Length} любимых цвета:");
            else if (User.FavColors.Length > 1 && User.FavColors.Length < 5)
                Console.WriteLine($"У пользователя {User.FavColors.Length} любимых цвета:");
            else
                Console.WriteLine($"У пользователя {User.FavColors.Length} любимых цветов:");

            foreach (var color in User.FavColors)
            {
                Console.WriteLine($"-{color}");
            }
        }

        static void Main(string[] args)
        {
            var user = UserInfo();
            ShowUserInfo(user);
        }
    }
}