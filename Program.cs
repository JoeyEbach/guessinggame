string response = null;
int number = 0;
bool validNumber = false;
Random random = new Random();
int secretNumber = random.Next(1, 101);
List<int> guesses = new List<int>(4);
int guess = -1;
int trys = 0;
int maxTrys = 0;


Console.WriteLine("Hello! Take a guess at the secret number!");
difficultyLevel();

void difficultyLevel()
{
    Console.WriteLine(@"Please select a difficulty level:
                            1. Easy - 8 guesses
                            2. Medium - 6 guesses
                            3. Hard - 4 guesses
                            4. Cheater - Unlimited guesses");

    response = Console.ReadLine().Trim();

    if (response == "1")
    {
        maxTrys = 8;
    }
    else if (response == "2")
    {
        maxTrys = 6;
    }
    else if (response == "3")
    {
        maxTrys = 4;
    }
    else if (response == "4")
    {
        maxTrys = 1000000000;
    }

    response = null;
    EnterNumber();
}

void EnterNumber()
{
    Console.WriteLine("Enter a number between 1 and 100.");


    while (response == null && trys <= (maxTrys - 1))
    {
        try
        {
            validNumber = int.TryParse(Console.ReadLine().Trim(), out number);
            if (validNumber == true && number >= 1 && number <= 100)
            {
                guess = number;
                trys += 1;
                if (guess == secretNumber)
                {
                    Console.WriteLine($"Congratulations! You guessed the secret number, {secretNumber}!");
                    Console.WriteLine("Thanks for playing, goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine($"Bummer! {number} is not the secret number.");
                    if (number < secretNumber)
                    {
                        Console.WriteLine("It's too low!");
                    }
                    else if (number > secretNumber)
                    {
                        Console.WriteLine("It's too high!");

                    }

                    if (trys < maxTrys)
                    {
                        guesses.Add(guess);
                        Console.WriteLine($"You have {maxTrys - trys} trys left! Try again!");
                        EnterNumber();
                    }
                    else if (trys == maxTrys)
                    {
                        Console.WriteLine($"Sorry, you're out of guesses! The secret number was {secretNumber}.");
                        Console.WriteLine("Thanks for playing, goodbye!");
                    }
                }
            }
            else
            {
                Console.WriteLine("You have entered an invalid number.");
                EnterNumber();
            }
        }
        catch
        {
            Console.WriteLine("You have entered an invalid number.");
            EnterNumber();
        }
    }
}

