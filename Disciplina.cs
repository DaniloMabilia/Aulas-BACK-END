using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AULA_17_08
{
    public enum SituacaoAluno { Pendente, Aprovado,Reprovado,Exame }
    public class Disciplina
    {
        public String Nome { get; set; }
        
        public int Codigo { get; set; }
        public int CargaHoraria { get; set; }
        public List<Aluno> ListaAluno { get; set; }

        public Dictionary<Aluno,double> MapaDeNotas { get; set; }
        public Dictionary<Aluno, int> MapaDeFalta { get; set; }

        public Disciplina(string C_Nome, int C_Codigo, int C_CargaHoraria)
        {
            Nome = C_Nome;
            Codigo = C_Codigo;
            CargaHoraria = C_CargaHoraria;

            ListaAluno = new List<Aluno>();
            MapaDeNotas = new Dictionary<Aluno, double>();
            MapaDeFalta = new Dictionary<Aluno, int>();

        }

        public void LancarNota(Aluno aluno, double n1, double n2, double t1)
        {
            
            double NF = 0;
            NF = (n1 * 0.3) + (n2 * 0.3) + (t1 * 0.4);
            MapaDeNotas[aluno] = NF;
        }
        public void LancarFalta(Aluno aluno)
        {
            MapaDeFalta[aluno]++;
        }
        public Aluno LocalizarAluno(String strBusca)
        {
            strBusca = strBusca.ToUpper();
            bool isCod = false;
            int cod = -1;
            try
            {
                cod = Convert.ToInt32(strBusca);
                isCod = true;
            }
            catch
            {
                isCod = false;
            }

            if (isCod == true)
            {
                    return ListaAluno.First(o => o.Matricula == cod);
            }
     
            return ListaAluno.First(o => o.Nome.Equals(strBusca));          
        }
        public void CadastrarAlunoViaConsole()
        {
            Aluno novoAluno = new Aluno();
            novoAluno.CadastrarAlunoViaConsole();
            CadastrarAluno(novoAluno);
      
        }
        public bool CadastrarAluno(Aluno novoAluno)
        {
            novoAluno.Nome = novoAluno.Nome.ToUpper();
            for (int i = 0; i < ListaAluno.Count; i++)
            {
                if (ListaAluno[i].Nome.Equals(novoAluno.Nome))
                {
                    return false;
                }
            }

            ListaAluno.Add(novoAluno);
            MapaDeNotas.Add(novoAluno, 0);
            MapaDeFalta.Add(novoAluno, 0);

            return true;
        }
        public void Aprovado()
        {
            foreach (KeyValuePair<Aluno, int> alunoAtual1 in MapaDeFalta)
            {
                int corte = Convert.ToInt32(CargaHoraria / 5);
                if (alunoAtual1.Value <= corte)
                {
                    if (MapaDeNotas[alunoAtual1.Key] >= 6)
                    {
                        alunoAtual1.Key.Situacao = "Aprovado";
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine($"Matricula: { alunoAtual1.Key.Matricula}");
                        Console.WriteLine($"Aluno: { alunoAtual1.Key.Nome}");
                        Console.WriteLine($"Qtd Falta: {alunoAtual1.Value}");
                        Console.WriteLine($"Nota Final: {MapaDeNotas[alunoAtual1.Key]}");
                        Console.WriteLine($"Situação: { alunoAtual1.Key.Situacao}");

                    }
                    else 
                    {
                        alunoAtual1.Key.Situacao = "Reprovado";
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine($"Matricula: { alunoAtual1.Key.Matricula}");
                        Console.WriteLine($"Aluno: { alunoAtual1.Key.Nome}");
                        Console.WriteLine($"Qtd Falta: {alunoAtual1.Value}");
                        Console.WriteLine($"Nota Final: {MapaDeNotas[alunoAtual1.Key]}");
                        Console.WriteLine($"Situação: { alunoAtual1.Key.Situacao}");
                    }
                }
                else
                {
                    alunoAtual1.Key.Situacao = "Reprovado";
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine($"Matricula: { alunoAtual1.Key.Matricula}");
                    Console.WriteLine($"Aluno: { alunoAtual1.Key.Nome}");
                    Console.WriteLine($"Qtd Falta: {alunoAtual1.Value}");
                    Console.WriteLine($"Nota Final: {MapaDeNotas[alunoAtual1.Key]}");
                    Console.WriteLine($"Situação: { alunoAtual1.Key.Situacao}");
                }
            }
        }
    }


}
