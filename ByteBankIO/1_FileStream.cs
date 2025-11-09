using ByteBankIO;
using System.Text;

partial class Program
{
    static void FileStream()
    {
        var enderecoArquivo = "contas.txt";

        using (var fluxoDoArquivo = new FileStream(enderecoArquivo, FileMode.Open))
        {

            var numBytesLidos = -1;

            var buffer = new byte[1024]; //1KB


            while (numBytesLidos != 0)
            {

                numBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                Console.WriteLine($"Bytes lidos: {numBytesLidos} ");
                EscreverBuffer(buffer, numBytesLidos);

            }

            fluxoDoArquivo.Close();

            Console.ReadLine();
        }
    }

    static void EscreverBuffer(byte[] buffer, int bytesLidos)
    {
        var utf8 = new UTF8Encoding();

        var texto = utf8.GetString(buffer, 0, bytesLidos);

        //public virutal string GetString(byte[]) bytes, int index, int count);
        Console.WriteLine(texto);
        /*foreach(var meuByte in buffer)
        {
            Console.Write(meuByte);
            Console.Write(" ");
        }*/
    }
}