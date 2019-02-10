using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercicio01
{
    public class OS
    {
        public int Numero { get; set; }

        public DateTime DataAbertura { get; set; }

        public DateTime? DataEncerramento { get; set; }

        public string Responsavel { get; set; }

        public List<Areas> Areas;




        //public OS(DateTime _dataAbertura, DateTime? _dataEncerramento, string _responsavel)
        //{
        //    DataAbertura = _dataAbertura;
        //    DataEncerramento = _dataEncerramento;
        //    Responsavel = _responsavel;
        //    Numero = Interlocked.Increment(ref globalID);
        //}
    }

    public class Metodos
    {
        public static int globalID;

        public static int NextId { get; set; }

        public static void InserirOs(List<OS> _osList, OS ordemDeServico)
        {
            //recuperando OS que foi passada como parametro
            List<OS> _list = _osList;

            List<Areas> _areasList = new List<Areas>();

            //Adiconando nova OS na Lista
            _list.Add(ordemDeServico);

            //Carregando menu principal
            CarregarMenuPrincipal();

            //Guarda o valor digitado pelo usuario
            string _menu = Console.ReadLine().ToString();

            //Realiza ação de acorodo com a opção escolhida 
            MenuOpcoes(_osList, _menu, null);
        }

        public static void ListarOS(List<OS> _osList)
        {
            Console.WriteLine();
            Console.WriteLine("ID_OS\t\tData Abertura\t\tData Encerramento\t\tResponsável");

            int nextID = 1;
            for (int i = 0; i < _osList.Count; i++)
            {
                Console.WriteLine("{0}\t\t{1}\t{2}\t\t{3}",
                nextID++,
                _osList[i].DataAbertura,
                _osList[i].DataEncerramento,
                _osList[i].Responsavel
                );
            }

            CarregarMenuPrincipal();

            string _menu = Console.ReadLine().ToString();

            MenuOpcoes(_osList, _menu, null);
        }

        public static void MenuOpcoes(List<OS> _osList, string _menu, int? idOs)
        {
            DateTime? _dataEncerramento = null;
            DateTime _dataAbertura = new DateTime(0001, 01, 01);
            DateTime _validaData;
            string _nomeResponsavel = string.Empty;
            string validaLoop = string.Empty;
            string arquivo_OS = "C:\\Lista_OS.txt";
            string arquivo_Area = "C:\\Lista_Areas.txt";

            while (validaLoop == string.Empty)
            {
                while (_menu == string.Empty)
                {
                    Console.WriteLine("Digite uma opção válida!!!");
                    _menu = Console.ReadLine();
                }

                //_menu = Console.ReadLine();
                if (_menu.Equals("0") || _menu.Equals("1") || _menu.Equals("2") || _menu.Equals("3") || _menu.Equals("4"))
                {
                    switch (_menu)
                    {
                        case "0":
                            return;

                        case "1":

                            while (_dataAbertura == new DateTime(0001, 01, 01))
                            {
                                Console.WriteLine();
                                Console.WriteLine("Digite a Data de Abertura:");
                                DateTime.TryParse(Console.ReadLine(), out _dataAbertura);
                            }

                            Console.WriteLine();
                            Console.WriteLine("Digite a Data de Encerramento: ");
                            bool dataValidada = DateTime.TryParse(Console.ReadLine(), out _validaData);
                            if (dataValidada) _dataEncerramento = _validaData;

                            while (_nomeResponsavel == string.Empty)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Digite o Nome do Responsável:");
                                _nomeResponsavel = Console.ReadLine();
                            }
                            Console.WriteLine();
                            Console.WriteLine("Ordem de Serviço criada com sucesso!!!");

                            if (File.Exists(arquivo_OS))
                            {
                                try
                                {
                                    using (StreamWriter wr = new StreamWriter(arquivo_OS, true))
                                    {
                                        wr.WriteLine();
                                        wr.WriteLine("------------------------------------------------");
                                        wr.WriteLine("ID_OS: " + (NextId = Interlocked.Increment(ref globalID)));
                                        wr.WriteLine("Data Abertura: " + (_dataAbertura));
                                        wr.WriteLine("Data Encerramento: " + (_dataEncerramento));
                                        wr.WriteLine("Responsável: " + (_nomeResponsavel));
                                        wr.Close();
                                    }

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else
                            {
                                try
                                {
                                    using (StreamWriter wr = new StreamWriter(arquivo_OS, true))
                                    {
                                        wr.WriteLine("---------------------------------------------------------------------------------------------");
                                        wr.WriteLine("    Lista OS    ");
                                        wr.WriteLine("---------------------------------------------------------------------------------------------");
                                        wr.WriteLine("ID_OS: " + (NextId = Interlocked.Increment(ref globalID)));
                                        wr.WriteLine("Data Abertura: " + (_dataAbertura));
                                        wr.WriteLine("Data Encerramento: " + (_dataEncerramento));
                                        wr.WriteLine("Responsável: " + (_nomeResponsavel));
                                        wr.Close();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            CarregarMenuPrincipal();
                            _menu = Console.ReadLine().ToString();
                            MenuOpcoes(_osList, _menu, idOs);

                            //InserirOs(_osList, new OS(_dataAbertura, _dataEncerramento, _nomeResponsavel));                                                                         
                            break;

                        case "2":
                            //ListarOS(_osList);                      
                            if (File.Exists(arquivo_OS))
                            {
                                try
                                {
                                    using (StreamReader sr = new StreamReader(arquivo_OS))
                                    {
                                        String linha;
                                        while ((linha = sr.ReadLine()) != null)
                                        {
                                            Console.WriteLine(linha);

                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }

                            if (File.Exists(arquivo_Area))
                            {
                                try
                                {
                                    using (StreamReader sr = new StreamReader(arquivo_Area))
                                    {
                                        String linha;
                                        while ((linha = sr.ReadLine()) != null)
                                        {
                                            Console.WriteLine(linha);

                                        }

                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }

                            CarregarMenuPrincipal();
                            _menu = Console.ReadLine().ToString();
                            MenuOpcoes(_osList, _menu, null);
                            break;

                        case "3":                        
                           

                            break;

                        case "4":
                            decimal area = 0m;
                            decimal areaDigitada = 0m;
                            Console.WriteLine("Digite o  código da OS: ");
                            string pequisaOs = "ID_OS: " + Console.ReadLine();
                            string[] linhas = File.ReadAllLines(arquivo_OS);
                            using (StreamReader sr = new StreamReader(arquivo_OS))
                            {
                                foreach (var item in linhas)
                                {
                                    if (item.Equals(pequisaOs))
                                    {
                                        Console.WriteLine(pequisaOs);
                                        Console.WriteLine("Digite o Tamanho da área");
                                        decimal.TryParse(Console.ReadLine(), out areaDigitada);
                                        area = areaDigitada;
                                        Console.ReadLine();

                                    }
                                }

                      
                            }

                            if (File.Exists(arquivo_Area))
                            {
                                try
                                {
                                    using (StreamWriter wr = new StreamWriter(arquivo_Area, true))
                                    {
                                        wr.WriteLine();
                                        wr.WriteLine("------------------------------------------------");
                                        wr.WriteLine(pequisaOs);
                                        wr.WriteLine("ID_Area_OS: " + (NextId = Interlocked.Increment(ref globalID)));
                                        wr.WriteLine("Área da OS: " + (area));                                      
                                        wr.Close();
                                    }

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else
                            {
                                try
                                {
                                    using (StreamWriter wr = new StreamWriter(arquivo_Area, true))
                                    {
                                        wr.WriteLine("---------------------------------------------------------------------------------------------");
                                        wr.WriteLine("    Lista Áreas OS    ");
                                        wr.WriteLine("---------------------------------------------------------------------------------------------");
                                        wr.WriteLine(pequisaOs);
                                        wr.WriteLine("ID_Area_OS: " + (NextId = Interlocked.Increment(ref globalID)));
                                        wr.WriteLine("Área da OS: " + (area));
                                        wr.Close();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }

                            CarregarMenuPrincipal();
                            _menu = Console.ReadLine().ToString();
                            MenuOpcoes(_osList, _menu, idOs);

                            break;
                        default:

                            break;
                    }
                    validaLoop = "fim";
                }
                else
                {

                    validaLoop = string.Empty;
                    CarregarMenuPrincipal();

                }
            }


        }

        //Carregar MenuPrincipal
        public static void CarregarMenuPrincipal()
        {
            Console.WriteLine();
            Console.WriteLine("Escolha a operação a ser realizada\n" +
                              "0 - Sair do Programa\n" +
                              "1 - Criar nova OS\n" +
                              "2 - Listar todas as OS cadastradas\n" +
                              "3 - Encerrar uma OS\n" +
                              "4 - Incluir uma nova área na OS");
            Console.WriteLine();
        }

    }
}
