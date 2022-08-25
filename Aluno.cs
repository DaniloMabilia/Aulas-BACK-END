using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AULA_17_08
{
    public class Aluno
    {
        public static int _matriculaBase = 1;
        public string Nome { get; set; }
        public int Matricula { get; set; }
        public string Curso { get; set; }
        public string Situacao { get; set; }

        public void CadastrarAlunoViaConsole()
        {
            Console.WriteLine("Entre com o nome do aluno: ");
            this.Nome = Console.ReadLine();
            this.Matricula = _matriculaBase;
            this.Situacao = "Pendente";
            _matriculaBase++;
        }

    }
}
