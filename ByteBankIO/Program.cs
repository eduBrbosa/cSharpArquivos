using ByteBankIO;
using System.Text;

partial class Program
{
    static void Main(string[] args)
    {
        var enderecoArquivo = "contas.txt";

        using (var fluxoArquivo = new FileStream(enderecoArquivo, FileMode.Open))
        {
            var leitor = new StreamReader(fluxoArquivo);

            //var linha = leitor.ReadLine();

            //var texto = leitor.ReadToEnd();

            //var numero = leitor.Read();

            while(!leitor.EndOfStream)
            {
                var linha = leitor.ReadLine();
                Console.WriteLine(linha);
            }
        }


            Console.ReadLine();
    }

}