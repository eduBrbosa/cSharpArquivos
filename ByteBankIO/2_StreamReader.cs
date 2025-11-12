using ByteBankIO;
using System.Text;

partial class Program
{
    static void StreamReader()
    {
        var enderecoArquivo = "contas.txt";

        using (var fluxoArquivo = new FileStream(enderecoArquivo, FileMode.Open))
        {
            var leitor = new StreamReader(fluxoArquivo);

            //var linha = leitor.ReadLine();

            //var texto = leitor.ReadToEnd();

            //var numero = leitor.Read();

            while (!leitor.EndOfStream)
            {
                var linha = leitor.ReadLine();
                var contaCorrente = ConverterStringParaContaCorrente(linha);

                var msg = $"{contaCorrente.Titular.Nome}: " +
                          $"Número Conta: {contaCorrente.Numero}, " +
                          $"Agência: {contaCorrente.Agencia}, " +
                          $"Saldo: {contaCorrente.Saldo}";
                Console.WriteLine(msg);
            }
        }


        Console.ReadLine();
    }

    static ContaCorrente ConverterStringParaContaCorrente(string linha)
    {
        // 375 4644 2483.13 Jonatan
        var campos = linha.Split(',');

        var agencia = campos[0];
        var numero = campos[1];
        var saldo = campos[2].Replace('.', ',');
        var nomeTitular = campos[3];

        var agenciaInt = int.Parse(agencia);
        var numeroInt = int.Parse(numero);
        var saldoDouble = double.Parse(saldo);

        var titular = new Cliente();
        titular.Nome = nomeTitular;

        var resultado = new ContaCorrente(agenciaInt, numeroInt);
        resultado.Depositar(saldoDouble);
        resultado.Titular = titular;

        return resultado;
    }

}