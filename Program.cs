using System;
using System.Collections.Generic;

namespace AULA_17_08
{
    class Program
    {
        static void Main(string[] args)
        {
            Disciplina disciplina = new Disciplina("Back End 2", 777, 20) ;
            string entrada;
            Aluno aluno;
            do
            {
                Console.Clear();
                Console.WriteLine("Entre com a opção desejada: ");
                Console.WriteLine("1 - Cadastrar aluno");
                Console.WriteLine("2 - Lançar Nota");
                Console.WriteLine("3 - Lançar Falta");
                Console.WriteLine("4 - Consultar Nota ");
                Console.WriteLine("5 - Consultar falta ");
                Console.WriteLine("6 - Listar Nota ");
                Console.WriteLine("7 - Listar Falta ");
                Console.WriteLine("8 - Listar Aprovados/Reprovados ");
                Console.WriteLine("sair - Para encerrar o programa");
                entrada = Console.ReadLine();
                switch (entrada)
                {
                    case "1":
                        disciplina.CadastrarAlunoViaConsole();
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Entre com o nome ou matricula do aluno:");
                            aluno = disciplina.LocalizarAluno(Console.ReadLine());

                            Console.WriteLine("Entre com a nota da Prova 1:");
                            double n1 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Entre com a nota da Prova 2:");
                            double n2 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Entre com a nota do Trabalho:");
                            double t1 = Convert.ToDouble(Console.ReadLine());

                            disciplina.LancarNota(aluno, n1, n2, t1);
                            Console.WriteLine("Nota final: " + disciplina.MapaDeNotas[aluno]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Aluno invalido");
                            Console.ReadKey();
                        }
    
                        break;
                    case "3":
                        try
                        {
                            Console.WriteLine("Entre com o nome ou matricula do aluno:");
                            aluno = disciplina.LocalizarAluno(Console.ReadLine());
                            disciplina.LancarFalta(aluno);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Aluno invalido");
                            Console.ReadKey();
                        }

                        break;

                    
                    case "4":
                        try
                        {
                            Console.WriteLine("Entre com o nome ou matricula do aluno para consulta de nota: ");
                            aluno = disciplina.LocalizarAluno(Console.ReadLine());
                            Console.WriteLine("Nota Final: " + disciplina.MapaDeNotas[aluno]);
                            Console.ReadKey();

                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine("Aluno invalido");
                            Console.ReadKey();
                        }
                        break;
                    case "5":
                        try
                        {
                            Console.WriteLine("Entre com o nome ou matricula do aluno para consulta de falta: ");
                            aluno = disciplina.LocalizarAluno(Console.ReadLine());
                            Console.WriteLine("Qtd Falta: " + disciplina.MapaDeFalta[aluno]);
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Aluno invalido");
                            Console.ReadKey();
                        }

                        break;
                    case "6":
                        foreach (KeyValuePair<Aluno, double> alunoAtual in disciplina.MapaDeNotas)
                        {
                            Console.WriteLine("--------------------------------------------");
                            Console.WriteLine($"Matricula: { alunoAtual.Key.Matricula}");
                            Console.WriteLine($"Aluno: { alunoAtual.Key.Nome}");                            
                            Console.WriteLine($"Nota Final: {alunoAtual.Value}");
                        }
                        Console.ReadKey();
                        break;
                    case "7":
                        foreach (KeyValuePair<Aluno, int> alunoAtual in disciplina.MapaDeFalta)
                        {
                            Console.WriteLine("--------------------------------------------");
                            Console.WriteLine($"Matricula: { alunoAtual.Key.Matricula}");
                            Console.WriteLine($"Aluno: { alunoAtual.Key.Nome}");
                            Console.WriteLine($"Qtd Falta: {alunoAtual.Value}");
                        }
                        Console.ReadKey();
                        break;
                    case "8":
                        disciplina.Aprovado();                                      

                        Console.ReadKey();
                        break;
                    case "sair":
                        Console.WriteLine("Saindo ...");
                        break;
                    default:
                        Console.WriteLine("Opcao Invalida");
                        Console.ReadKey();
                        break;


                }
                
            } while (entrada != "sair");
        }
    }
}
