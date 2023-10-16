using System;

namespace guessing_number;

public class GuessNumber
{
    //In this way we are passing the random number generator by dependency injection
    private IRandomGenerator random;
    public GuessNumber() : this(new DefaultRandom()){}
    public GuessNumber(IRandomGenerator obj)
    {
        this.random = obj;

        userValue = 0;
        randomValue = 0;
    }

    //user variables
    public int userValue;
    public int randomValue;

    public int maxAttempts;
    public int currentAttempts;

    public int difficultyLevel;

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
        bool isNumber = Int32.TryParse(userEntry, out int value);
        if (!isNumber)
        {
            return "Entrada inválida! Não é um número.";
        }
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
        throw new NotImplementedException();
    }

    //4 - Verifique a resposta da jogada
    public string AnalyzePlay()
    {
        if (this.userValue < this.randomValue)
        {
            return "Tente um número MAIOR";
        }
        else if (this.userValue > this.randomValue)
        {
            return "Tente um número MENOR";
        }
        else
        {
            return "ACERTOU!";
        }
    }

    //7 - Adicione uma opção para reiniciar o jogo
    public void RestartGame()
    {
        throw new NotImplementedException();
    }
}