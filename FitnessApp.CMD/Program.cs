using System;
using System.Globalization;
using System.Resources;
using FitnessApp.BL.Controller;
using FitnessApp.BL.Model;

namespace FitnessApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var culture = CultureInfo.CreateSpecificCulture("en_us");
            var resourceManager = new ResourceManager("FitnessApp.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));
            
            Console.WriteLine(resourceManager.GetString("UserName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            
            if (userController.IsNewUser)
            {
                Console.WriteLine(resourceManager.GetString("Gender", culture));
                var gender = Console.ReadLine();
                var dateOfBirth = ParseDate("date of birth");
                var weight = ParseDouble("weight");
                var height = ParseDouble("height");
                
                userController.SetNewUserData(gender, dateOfBirth, weight, height);
            }
            
            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine(resourceManager.GetString("YourAction", culture));
                Console.WriteLine(resourceManager.GetString("EKey", culture));
                Console.WriteLine(resourceManager.GetString("AKey", culture));
                Console.WriteLine(resourceManager.GetString("QKey", culture));
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();

                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise();

                        exerciseController.Add(exe.Activity, exe.Begin, exe.End);

                        foreach ( var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} from {item.Start.ToShortTimeString()} to {item.Finish.ToShortTimeString()}");

                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);

                        break;
                }
                Console.WriteLine();
            }
        }


        private static (Food Food, double Weight) EnterEating()
        {
            Console.WriteLine("Provide product name :");
            var food = Console.ReadLine();

            var calories = ParseDouble("Calories");
            var proteins = ParseDouble("Proteins");
            var fats = ParseDouble("Fats");
            var carbs = ParseDouble("Carbohydrates");


            var weight = ParseDouble("portion weight");
            var product = new Food(food, calories, proteins, fats, carbs);

            return (Food: product,Weight: weight);

        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.WriteLine("Enter exercise name : ");
            var name = Console.ReadLine();

            var energy = ParseDouble("energy consumption per minute");
            var begin = ParseDate("exercise start");
            var end = ParseDate("exercise end");

            var activity = new Activity(name, energy);

            return (begin, end, activity);
        }

        private static DateTime ParseDate(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine($"Enter {value} (mm.dd.yyyy)");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($" Wrong Format {value}");
                }
            }
            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Enter your {name}");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Wrong {name} format");
                }
            }
        }
    }
}