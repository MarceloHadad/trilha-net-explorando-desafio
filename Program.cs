using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
var hospedes = new List<Pessoa>();

bool sucesso;
int quantidadeHospedes;
int quantidadeDiasReservados;
int idSuiteEscolhida;
Suite suiteEscolhida;

do
{
    Console.WriteLine("Digite a quantidade de hóspedes:");
    sucesso = int.TryParse(Console.ReadLine(), out quantidadeHospedes);

    if (!sucesso)
    {
        Console.WriteLine("Quantidade inválida!");
    }
} while (!sucesso);

for (int i = 1; i <= quantidadeHospedes; i++)
{
    var novoHospede = new Pessoa(nome: $"Hóspede {i}");
    hospedes.Add(novoHospede);
}

do
{
    Console.WriteLine("Digite a quantidade de dias a serem reservados:");
    sucesso = int.TryParse(Console.ReadLine(), out quantidadeDiasReservados);

    if (!sucesso)
    {
        Console.WriteLine("Quantidade inválida!");
    }
} while (!sucesso);

// Cria a suíte
var suite1 = new Suite(tipoSuite: "Comum", capacidade: 1, valorDiaria: 10);
var suite2 = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);
var suite3 = new Suite(tipoSuite: "Master Plus Pro Max", capacidade: 2, valorDiaria: 98);

var suites = new List<Suite> { suite1, suite2, suite3 };

// Cria uma nova reserva, passando a suíte e os hóspedes
var reserva = new Reserva(diasReservados: quantidadeDiasReservados);

Console.WriteLine("Escolha a suíte desejada:");

int suiteId = 1;
foreach (var suite in suites)
{
    Console.WriteLine($"Opção: {suiteId} | Tipo: {suite.TipoSuite} | Capacidade: {suite.Capacidade} | Diária: {suite.ValorDiaria}");
    suiteId++;
}

do
{
    sucesso = int.TryParse(Console.ReadLine(), out idSuiteEscolhida);

    if (!sucesso || idSuiteEscolhida >= suiteId)
    {
        Console.WriteLine("Opção inválida!");
    }
    Console.WriteLine("Escolha a suíte desejada:");
} while (!sucesso || idSuiteEscolhida >= suiteId);

suiteEscolhida = suites[idSuiteEscolhida - 1];

reserva.CadastrarSuite(suiteEscolhida);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");