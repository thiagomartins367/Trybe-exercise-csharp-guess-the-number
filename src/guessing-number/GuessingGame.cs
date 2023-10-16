using System;

namespace guessing_number;

public class GuessNumber
{
    //In this way we are passing the random number generator by dependency injection
    private IRandomGenerator random;
    public GuessNumber() : this(new DefaultRandom()) { }
    public GuessNumber(IRandomGenerator obj)
    {
        this.random = obj;

        userValue = 0;
        randomValue = 0;
    }

    //user variables
    public int userValue;
    public int randomValue;

    public int maxAttempts = 5;
    public int currentAttempts;

    public int difficultyLevel = 1;

    public bool gameOver;

    //1 - Imprima uma mensagem de saudação
    public string Greet()
    {
        return "---Bem-vindo ao Guessing Game--- /n Para começar, tente adivinhar o número que eu pensei, entre -100 e 100!";
    }

    //2 - Receba a entrada da pessoa usuária e converta para Int
    //5 - Adicione um limite de tentativas
    public string ChooseNumber(string userEntry)
    {
        this.currentAttempts++;
        if (this.currentAttempts > this.maxAttempts)
        {
            this.gameOver = true;
            return "Você excedeu o número máximo de tentativas! Tente novamente.";
        }
        bool isNumber = Int32.TryParse(userEntry, out int value);
        if (!isNumber) return "Entrada inválida! Não é um número.";
        if (value < -100 || value > 100)
        {
            this.userValue = 0;
            return "Entrada inválida! Valor não está no range.";
        }
        this.userValue = value;
        return "Número escolhido!";
    }

    //3 - Gere um número aleatório
    public string RandomNumber()
    {
        int randomNumber = this.random.GetInt(-100, 100);
        this.randomValue = randomNumber;
        return "A máquina escolheu um número de -100 à 100!";
    }

    //6 - Adicione níveis de dificuldade
    public string RandomNumberWithDifficult()
    {
        switch (this.difficultyLevel)
        {
            case 2:
                this.randomValue = this.random.GetInt(-500, 500);
                return "A máquina escolheu um número de -500 à 500!";
            case 3:
                this.randomValue = this.random.GetInt(-1000, 1000);
                return "A máquina escolheu um número de -1000 à 1000!";
            default:
                return this.RandomNumber();
        }
    }

    //4 - Verifique a resposta da jogada
    public string AnalyzePlay()
    {
        if (this.gameOver) return "O jogo terminou. Deseja jogar novamente?";
        if (this.userValue < this.randomValue)
            return "Tente um número MAIOR";
        else if (this.userValue > this.randomValue)
            return "Tente um número MENOR";
        else
        {
            this.gameOver = true;
            return "ACERTOU!";
        }
    }

    //7 - Adicione uma opção para reiniciar o jogo
    public void RestartGame()
    {
        this.userValue = 0;
        this.randomValue = 0;
        this.maxAttempts = 5;
        this.currentAttempts = 0;
        this.difficultyLevel = 1;
        this.gameOver = false;
    }
}