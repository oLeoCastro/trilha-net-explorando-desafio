namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {            
            if (hospedes == null || hospedes.Count == 0)
            {
                throw new ArgumentException("Número de hóspedes inválido, tente novamente.");
            }
            if (Suite == null)
                {
                    throw new InvalidOperationException("A suíte deve ser cadastrada antes de cadastrar hóspedes.");
                }

            if (hospedes.Count <= Suite.Capacidade)
            {                               
                Hospedes = hospedes;
            }
            else
            {                
                throw new ArgumentException("Capacidade da suíte é menor que o número de hóspedes.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            if (Hospedes == null)
            {
                return 0;
            }
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {            
            if (DiasReservados <= 0)
            {
                throw new ArgumentException("Número de dias reservados inválido, tente novamente.");
            }
            if (Suite == null)
            {
                throw new InvalidOperationException("A suíte deve ser cadastrada antes de calcular o valor da diária.");
            }
            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {
                valor *= 0.9M;
            }

            return valor;
        }
    }
}