namespace RoboSimulator
{
    public interface IRobo
    {
        public string MinhasCoordenadas();
        public string MeuNome();
        public void Mover(string instrucao);
    }
}