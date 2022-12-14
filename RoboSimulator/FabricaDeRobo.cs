using System;
using System.Collections.Generic;
using RoboSimulator.Enuns;

namespace RoboSimulator
{
    public class FabricaDeRobo
    {
        public static List<IRobo> listaRobos = new List<IRobo>();
        public void FabricarRobo(TipoRobo tipo)
        {
            switch (tipo)
            {
                case TipoRobo.Pequeno:
                RoboPequeno roboP = new RoboPequeno();
                roboP.MinhaDirecao = Direcao.Norte;
                roboP.NomeRobo = roboP.ValidarNome();
                listaRobos.Add(roboP);
                break;

                case TipoRobo.Grande:
                RoboGrande roboG = new RoboGrande();
                roboG.MinhaDirecao = Direcao.Leste;
                roboG.NomeRobo = roboG.ValidarNome();
                listaRobos.Add(roboG);
                break;
                
                default:
                throw new SystemException("Opção inválida. Pressione qualquer tecla para continuar.");
            }
            
        }
        public bool DestruirRobo(string nome)
        {
            var achouNome = false;
            foreach (var item in listaRobos)
            {                
                if (item.MeuNome() == nome)
                {
                    listaRobos.Remove(item);
                    return true;
                }                
            }
            return achouNome;
        }

        public void ListarRobos()    
        {
            foreach (var item in listaRobos)
            {
                System.Console.WriteLine(item.ToString());
            }
        }
    }
}