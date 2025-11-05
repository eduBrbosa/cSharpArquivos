using ByteBankIO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        var enderecoArquivo = "contas.txt";
        var numBytesLidos = -1;

        var fluxoDoArquivo = new FileStream(enderecoArquivo, FileMode.Open);
        var buffer = new byte[1024]; //1KB
        

        while(numBytesLidos != 0)
        {

            numBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
            EscreverBuffer(buffer);

        }

        Console.ReadLine();
    }

    static void EscreverBuffer(byte[] buffer)
    {
        var utf8 = new UTF8Encoding();

        var texto = utf8.GetString(buffer);
        Console.WriteLine(texto);
        /*foreach(var meuByte in buffer)
        {
            Console.Write(meuByte);
            Console.Write(" ");
        }*/
    }
}