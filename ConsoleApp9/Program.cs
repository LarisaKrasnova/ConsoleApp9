using System;
using System.Runtime.Remoting.Messaging;

namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)

        {
          var User = EnterUser();
        
        }

        static (string Name, string LastName, int Age,
                 bool IsPet, int NumberOfPets, string[] PetNames,
            int NumberOfFavoriteColors, string[] ColorNames) EnterUser()
        {
            (string Name, string LastName, int Age,
                 bool IsPet, int NumberOfPets, string[] PetNames,
            int NumberOfFavoriteColors, string[] ColorNames) User = default;

            Console.WriteLine("Введите имя");
            User.Name = Console.ReadLine();

            Console.WriteLine("Введите фамилию");
            User.LastName = Console.ReadLine();

            User.Age = GetValidatedNumber("Введите возраст");


            

            Console.WriteLine("У вас есть питомец? Да или Нет? ");
            var isPet = Console.ReadLine();
            switch (isPet)
            {

                case "Да":
                    User.IsPet = true;
                    break;
                default:
                    User.IsPet = false;
                    break;


            }
            if (User.IsPet)
            {

                User.NumberOfPets = GetValidatedNumber("Сколько у вас питомцев?");

               User.PetNames = GetNames(User.NumberOfPets, "Введите имя животного");
                
                

            }


            User.NumberOfFavoriteColors = GetValidatedNumber("Сколько у вас любимых цветов");

            User.ColorNames = GetNames(User.NumberOfFavoriteColors, "Введите любимый цвет");


            return User;
        }

        static string[] GetNames(int number, string message)
        {
            string[] names = new string[number];

            for (int i = 0; i < number; i++)
            {
                Console.WriteLine($"{message} #{i + 1}");
                names[i] = Console.ReadLine();
            }

            return names;
        }

        static bool IsNumCorrect(string age, out int intage)
        {
            intage = Convert.ToInt32(age);


            if (intage >= 1 && intage < 101)
            {
                return true;
            }
            return false;
        }

        static int GetValidatedNumber(string message) 
        {

            string stringNumber;
            int number;
            do
            {
                Console.WriteLine(message);
                stringNumber= Console.ReadLine();
            }
            while (!IsNumCorrect(stringNumber, out number));

            return number;

        }




    }
}
