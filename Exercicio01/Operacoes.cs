using System;

namespace Exercicio01
{
    public static class Operacoes
    {
        public static void TipoOperacoes()
        {
            decimal val1, val2, result = 0m;
            decimal valorConvertido = 0m;
            string oper = "";
            string validaLoop = "";
            string validaDigitacao;

            try
            {
                while (!validaLoop.Equals("fim"))
                {
                    while (valorConvertido <= 0)
                    {
                        Console.Write("Digite valor 1: ");
                        decimal.TryParse(Console.ReadLine(), out valorConvertido);
                    }

                    val1 = valorConvertido;
                    valorConvertido = 0;

                    while (valorConvertido <= 0)
                    {
                        Console.Write("Digite valor 2: ");
                        decimal.TryParse(Console.ReadLine(), out valorConvertido);
                    }

                    val2 = valorConvertido;
                    valorConvertido = 0;
                    validaDigitacao = "validar";

                    while (validaDigitacao == "validar")
                    {
                        Console.Write("Operação: ");
                        oper = Console.ReadLine();

                        if (oper == ".")
                        {
                            Console.WriteLine("A aplicação será encerrada!!!");
                            Console.ReadLine();
                            //validaLoop = "fim";
                            return;
                        }

                        if (oper.Equals("+") || oper.Equals("-") || oper.Equals("*") || oper.Equals("^") || oper.Equals("/") || oper.Equals("%"))
                        {
                            switch (oper)
                            {
                                case "+":
                                    result = Convert.ToDecimal(val1 + val2);
                                    break;
                                case "-":
                                    result = Convert.ToDecimal(val1 - val2);
                                    break;

                                case "*":
                                    result = Convert.ToDecimal(val1 * val2);
                                    break;

                                case "^":
                                    result = Convert.ToDecimal(Math.Pow(Convert.ToInt32(val1), Convert.ToInt32(val2)));
                                    break;

                                case "/":
                                    result = Convert.ToDecimal(val1 / val2);
                                    break;

                                case "%":
                                    result = Convert.ToDecimal(val1 % val2);
                                    break;


                                default:
                                    break;

                            }
                            validaDigitacao = "naoValidar";
                        }
                       else
                        {
                            validaDigitacao = "validar";
                        }
                       
                    }

                    Console.WriteLine("Resultado: " + result);
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro Sem Tratamento!!!");
                Console.WriteLine(ex.Message);
                Console.Read();
            }

        }
    }
}
