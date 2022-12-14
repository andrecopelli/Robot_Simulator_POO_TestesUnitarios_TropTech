using System;
using System.Collections.Generic;
using System.Linq;
using RoboSimulator.Enuns;

namespace RoboSimulator
{
    public class RoboGrande : IRobo
    {
        private string _nomeRobo;

        public string NomeRobo
        {
            get { return _nomeRobo; }
            set { _nomeRobo = value; }
        }
        private Direcao _minhaDirecao;
        public Direcao MinhaDirecao
        {
            get { return _minhaDirecao; }
            set { _minhaDirecao = value; }
        }

        public int X { get; set; }

        public int Y { get; set; }

        public string MinhasCoordenadas()
        {
            return $"Direção: {MinhaDirecao}; Posição: ({X},{Y})";
        }

        public void Mover(string instrucao)
        {
            char[] Instrucoes = instrucao.ToCharArray();

            // foreach (var caracter in Instrucoes)
            // {
            //     if (caracter != 'a' || caracter != 'e' || caracter != 'd' ||
            //        caracter != 'A' || caracter != 'E' || caracter != 'D')
            //     {
            //         throw new SystemException("Existem instruções não aceitas pelo robô. Pressione qualquer tecla para voltar ao menu principal.");
            //     }           
            // }

            foreach (var caracter in Instrucoes)
            {
                if(caracter == 'a' || caracter == 'A')
                {
                    Avancar();
                }
                if(caracter == 'e' || caracter == 'E')
                {
                    VirarEsquerda();
                }
                if(caracter == 'd' || caracter == 'D')
                {
                    VirarDireita();
                }
            }
        }

        public void VirarDireita()
        {
            if (MinhaDirecao == Direcao.Norte)
            {
                MinhaDirecao = Direcao.Leste;
                
            }
            if (MinhaDirecao == Direcao.Sul)
            {
                MinhaDirecao = Direcao.Oeste;
                
            }
            if (MinhaDirecao == Direcao.Leste)
            {
                MinhaDirecao = Direcao.Sul;
                
            }
            if (MinhaDirecao == Direcao.Oeste)
            {
                MinhaDirecao = Direcao.Norte;
                
            }
        }

        public void Avancar()
        {
            if (MinhaDirecao == Direcao.Norte)
            {
                Y += 3;
            }
            if (MinhaDirecao == Direcao.Sul)
            {
                Y -= 3;
            }
            if (MinhaDirecao == Direcao.Leste)
            {
                X += 3;
            }
            if (MinhaDirecao == Direcao.Oeste)
            {
                X -= 3;
            }
        }

        public void VirarEsquerda()
        {
            if (MinhaDirecao == Direcao.Norte)
            {
                MinhaDirecao = Direcao.Oeste;
                
            }
            if (MinhaDirecao == Direcao.Sul)
            {
                MinhaDirecao = Direcao.Leste;
                
            }
            if (MinhaDirecao == Direcao.Leste)
            {
                MinhaDirecao = Direcao.Norte;
                
            }
            if (MinhaDirecao == Direcao.Oeste)
            {
                MinhaDirecao = Direcao.Sul;
                
            }
        }

        public string GerarNome()
        {
            var charsLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var charsNumbers = "0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(charsLetters, 2)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            result += new string(
                Enumerable.Repeat(charsNumbers, 3)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

            return result;
        }

        public string ValidarNome()
        {
            string nome = GerarNome();
            foreach (var item in FabricaDeRobo.listaRobos)
            {
                if (nome == item.MeuNome())
                {
                    nome = GerarNome();
                }
            }
            return nome;
        }

        public string MeuNome()
        {
            return NomeRobo;
        }

        public override string ToString()
        {
            return $" =============== \nNome:{MeuNome()} \nTipo: Grande \nPosicao:{X}, {Y} \nDireção: {MinhaDirecao}";
        }
    }
}